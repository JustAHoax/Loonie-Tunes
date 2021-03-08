using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Loonie_Tunes
{
    public class CsvParse
    {
        public List<string> Toks { get; set; } = new List<string>();
        public List<AuctionItem> AuctionItems { get; set; } = new List<AuctionItem>();

        public List<AuctionItem> ParseTSMRealm(string s, IProgress<int> progress, string realmName)
        {
            Toks.Clear();
            AuctionItems.Clear();
            const string qs = @"\\""|i:";
            var realmData = s.Split(new[] { realmName }, StringSplitOptions.None)[1];
            string searchValue = "data=";
            var auctionDataRaw = realmData.Split(new[] { searchValue }, StringSplitOptions.None)[1];
            searchValue = "--";
            auctionDataRaw = auctionDataRaw.Split(new[] { searchValue }, StringSplitOptions.None)[0];
            auctionDataRaw = auctionDataRaw.Replace("\"", "");
            string[] auctionData = Regex.Split(auctionDataRaw, qs + @"|(=)|(,)|(\[)|(\])|(\{)|(\})|(--[^\n\r]*)");
            foreach (string tok in auctionData)
            {
                if (tok.Trim().Length != 0 && !tok.StartsWith("{") && !tok.StartsWith(",") && !tok.StartsWith("}")
                    && !tok.StartsWith(")") && !tok.StartsWith("]"))
                {
                    Toks.Add(tok.Trim());
                }
            }

            int percentComplete;
            for (int i = 0; i < Toks.Count - 1; i++)
            {
                AuctionItems.Add(new AuctionItem
                {
                    ItemString = Toks[i],
                    MarketValue = Toks[i + 1],
                    MinBuyout = Toks[i + 2],
                    Historical = Toks[i + 3],
                    NumAuctions = Toks[i + 4]
                });
                i += 4;
                percentComplete = ((i * 100) / Toks.Count);
                progress.Report(percentComplete);
            }
            percentComplete = 100;
            progress.Report(percentComplete);
            return AuctionItems;
        }

        public List<AuctionItem> ParseTSMRegion(string s, IProgress<int> progress, string region)
        {
            Toks.Clear();
            AuctionItems.Clear();
            const string qs = @"\\""|i:";
            var realmData = s.Split(new[] { region }, StringSplitOptions.None)[1];
            string searchValue = "data=";
            var auctionDataRaw = realmData.Split(new[] { searchValue }, StringSplitOptions.None)[1];
            searchValue = "--";
            auctionDataRaw = auctionDataRaw.Split(new[] { searchValue }, StringSplitOptions.None)[0];
            auctionDataRaw = auctionDataRaw.Replace("\"", "");
            string[] auctionData = Regex.Split(auctionDataRaw, qs + @"|(=)|(,)|(\[)|(\])|(\{)|(\})|(--[^\n\r]*)");
            foreach (string tok in auctionData)
            {
                if (tok.Trim().Length != 0 && !tok.StartsWith("{") && !tok.StartsWith(",") && !tok.StartsWith("}")
                    && !tok.StartsWith(")") && !tok.StartsWith("]"))
                {
                    Toks.Add(tok.Trim());
                }
            }

            int percentComplete;
            for (int i = 0; i < Toks.Count - 3;)
            {
                AuctionItems.Add(new AuctionItem
                {
                    ItemString = Toks[i],
                    MarketValue = Toks[i + 1],
                    MinBuyout = Toks[i + 2],
                    Historical = Toks[i + 3],
                    NumAuctions = Toks[i + 4],
                    regionSoldPerDay = Toks[i + 5],
                    regionSalePerc = Toks[i + 6]
                });
                i += 7;
                percentComplete = ((i * 100) / Toks.Count);
                progress.Report(percentComplete);
            }
            percentComplete = 100;
            progress.Report(percentComplete);
            return AuctionItems;
        }

        public List<WoWItem> ReadWoWCSV(string resourcePath, IProgress<int> progress)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = resourcePath;
            int recordsLength = 0;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var wowItems = new WoWItem();
                var allRecords = csv.EnumerateRecords(wowItems);
                recordsLength = allRecords.Count<WoWItem>();
            }

            var iterator = 0;
            assembly = Assembly.GetExecutingAssembly();
            resourceName = resourcePath;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {

                csv.Read();
                csv.ReadHeader();

                var records = new List<WoWItem>();
                int percentComplete;
                while (csv.Read())
                {
                    var wowItemRecords = new WoWItem
                    {
                        Id = csv.GetField("Id"),
                        Name = csv.GetField("Name")
                    };
                    records.Add(wowItemRecords);
                    iterator++;
                    percentComplete = (iterator * 100) / recordsLength;
                    progress.Report(percentComplete);
                }
                percentComplete = 100;
                progress.Report(percentComplete);
                return records;
            }

        }

        //public List<AuctionItem> ReadAuctionCsv(string resourcePath, IProgress<int> progress)
        //{
        //    int recordsLength = 0;
        //    using (var reader = new StreamReader(resourcePath))
        //    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //    {
        //        var auctionItem = new AuctionItem();
        //        var allRecords = csv.EnumerateRecords(auctionItem);
        //        recordsLength = allRecords.Count<AuctionItem>();
        //    }

        //    var iterator = 0;
        //    using (var reader = new StreamReader(resourcePath))
        //    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //    {

        //        var auctionRecords = new List<AuctionItem>();
        //        csv.Read();
        //        csv.ReadHeader();


        //        int percentComplete;
        //        while (csv.Read())
        //        {
        //            var record = new AuctionItem
        //            {
        //                ItemString = csv.GetField("ItemString"),
        //                MarketValue = csv.GetField("MarketValue"),
        //                MinBuyout = csv.GetField("MinBuyout"),
        //                Historical = csv.GetField("Historical"),
        //                NumAuctions = csv.GetField("NumAuctions")
        //            };
        //            auctionRecords.Add(record);
        //            iterator++;
        //            percentComplete = (iterator * 100) / recordsLength;
        //            progress.Report(percentComplete);
        //        }
        //        percentComplete = 100;
        //        progress.Report(percentComplete);
        //        return auctionRecords;
        //    }
        //}

        public void ListToCSV(List<AuctionItem> tsmAuctionValues, string outputPath, IProgress<int> progress)
        {
            using (var writer = new StreamWriter(outputPath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(tsmAuctionValues);
                progress.Report(100);
            }
        }

        public void CombinedCSV(List<AuctionItem> auctionItems, List<WoWItem> wowItems, string output, IProgress<int> progress)
        {
            var percentComplete = 0;
            using (var writer = new StreamWriter(output))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                var i = 0;
                csv.WriteHeader<AuctionItem>();
                csv.NextRecord();
                foreach (var record in auctionItems)
                {
                    var wowItem = wowItems?.Where(x => x.Id == record.ItemString).FirstOrDefault();
                    if (wowItem != null)
                    {
                        record.Name = wowItem.Name;
                        csv.WriteRecord(record);
                        csv.NextRecord();
                    }
                    i++;
                    percentComplete = (i * 100) / auctionItems.Count;
                    progress.Report(percentComplete);
                }

                percentComplete = 100;
                progress.Report(percentComplete);
            }
        }
    }
}