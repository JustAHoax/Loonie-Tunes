using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Loonie_Tunes.Functions
{
    public class StringStuff
    {
        string usRealms = "Loonie_Tunes.Resources.US-RealmList.txt";
        string euRealms = "Loonie_Tunes.Resources.EU-RealmList.txt";
        public List<string> BuildStringArrayContains(string text, string region)
        {
            var realmList = new List<string>();
            if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(region))
            {
                if (region.Contains("US"))
                {
                    using (Stream stream = Assembly.GetEntryAssembly().GetManifestResourceStream(usRealms))
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var realms = EnumerateLines(reader).ToList();
                        foreach (var realm in realms)
                        {
                            if (text.Contains(realm))
                                realmList.Add(realm);
                        }
                    }
                }
                if (region.Contains("EU"))
                {
                    using (Stream stream = Assembly.GetEntryAssembly().GetManifestResourceStream(euRealms))
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var realms = EnumerateLines(reader).ToList();

                        foreach (var realm in realms)
                        {
                            if (text.Contains(realm))
                                realmList.Add(realm);
                        }
                    }
                }
                return realmList;
            }
            return null;
        }

        private IEnumerable<string> EnumerateLines(TextReader reader)
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
