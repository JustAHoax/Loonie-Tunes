using Loonie_Tunes.Functions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loonie_Tunes
{
    public partial class MainForm : Form
    {
        private const string V = "txt files (*.txt)|*.Lua|All files (*.*)|*.*";
        private static CsvParse csvParse;
        private static ClipBoard clipBoard;
        private static StringStuff stringStuff;
        private BindingSource bindingSource;
        private string rootDir;
        public string fileContent;
        private Assembly assembly;
        private string wowItemCsv;
        private Progress<int> progressBar;

        public MainForm()
        {
            InitializeComponent();
        }
        private async void BtnProg_Click(object sender, EventArgs e)
        {
            if (appDataFileCheck())
            {
                loadBar();
                progBar.Value = 0;
                lblProgress.Text = "Reading TSM File...";
                var appDataFile = File.ReadAllText(txtPath.Text);
                var realmName = cmbRealmName.Text;
                var region = cmbRegion.Text;
                List<AuctionItem> tsmParseRealm = await Task.Run(() => csvParse.ParseTSMRealm(appDataFile, progressBar, realmName));
                lblProgress.Text = "Reading TSM File...Done";

                lblProgress.Text = "Parsing TSM AppData...";
                await Task.Run(() => csvParse.ListToCSV(tsmParseRealm, rootDir + @"\\TSMParse.csv", progressBar));
                lblProgress.Text = "Parsing TSM AppData...Done";

                lblProgress.Text = "Reading known Item Entries...";
                List<WoWItem> wowItemParse = await Task.Run(() => csvParse.ReadWoWCSV(wowItemCsv, progressBar));
                lblProgress.Text = "Reading known Item Entries...";

                //lblProgress.Text = "Reading Auction Price Data...";
                //List<AuctionItem> auctionItemParse = await Task.Run(() => csvParse.ReadAuctionCsv(rootDir + @"\\TSMParse.csv", progressBar));
                //lblProgress.Text = "Reading Auction price data...Done";

                lblProgress.Text = "Linking Item Entries with Auction Price Data...";
                await Task.Run(() => csvParse.CombinedCSV(tsmParseRealm, wowItemParse, rootDir + @"\\" + realmName + "Final.csv", progressBar));
                lblProgress.Text = "Linking Item Entries with Auction Price Data...Done";
                MessageBox.Show("Complete!");
                btnCopy.Visible = true;
            }
        }

        private Boolean appDataFileCheck()
        {
            if (txtPath.Text?.Length == 0 || txtPath.Text.IndexOf("tradeskillmaster_apphelper\\appdata.lua", StringComparison.OrdinalIgnoreCase) < 0)
            {
                MessageBox.Show("You have Selected a wrong or invalid file. Please try again.");
                return false;
            }
            return true;
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I'd love to help, please visit https://github.com/JustAHoax/LoonieTunes for the README containing the instructions.");
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            btnCopy.Visible = false;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = V;
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    string filePath = openFileDialog.FileName;
                    txtPath.Text = filePath;
                    btnProg.Visible = true;
                    PopulateDropDown();
                }
            }
        }
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            var realmName = cmbRealmName.Text;
            clipBoard.SwapClipboardText(File.ReadAllText(rootDir + @"\\" + realmName + "Final.csv"));
        }
        public void UpdateProgress(int progress)
        {
            progBar.Value = progress;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            stringStuff = new StringStuff();
            csvParse = new CsvParse();
            clipBoard = new ClipBoard();
            txtPath.Text = Properties.Settings.Default.appDataPath;
            assembly = Assembly.GetExecutingAssembly();
            wowItemCsv = "Loonie_Tunes.Resources.AuctionItemNames.csv";
            var roamingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            rootDir = Path.Combine(roamingDirectory, "LoonieTunes");
            Directory.CreateDirectory(rootDir);
            if (!string.IsNullOrEmpty(txtPath.Text))
                btnProg.Visible = true;
            if (!string.IsNullOrWhiteSpace(txtPath.Text))
            {
                btnCopy.Visible = true;
                PopulateDropDown();
                cmbRealmName.Text = Properties.Settings.Default.realmSelection;
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Update appDataPath setting
            Properties.Settings.Default.appDataPath = txtPath.Text;
            Properties.Settings.Default.realmSelection = cmbRealmName.Text;
            Properties.Settings.Default.Save();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (!IsAboveThreshhold(rootDir + @"\\Final.csv", 2))
                lblRefreshCSV.Visible = true;
        }

        private bool IsAboveThreshhold(string fileName, int hours)
        {
            var threshhold = DateTime.Now.AddHours(-hours);
            return File.GetCreationTime(fileName) <= threshhold;
        }

        private void PopulateDropDown()
        {
            cmbRealmName.DataSource = null;
            try
            {
                var appDataFile = File.ReadAllText(txtPath.Text);
                var realmList = stringStuff.BuildStringArrayContains(appDataFile, cmbRegion.Text);
                if (realmList != null)
                {
                    bindingSource = new BindingSource();
                    bindingSource.DataSource = realmList;
                    cmbRealmName.DataSource = bindingSource.DataSource;
                    cmbRealmName.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not populate Realm List drop down");
            }
        }

        private void BtnAppData_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", string.Format("/open,\"{0}\"", rootDir));
        }

        private void TmrOld_Tick(object sender, EventArgs e)
        {
            lblRefreshCSV.Visible = !IsAboveThreshhold(rootDir + @"\\Final.csv", 2);
        }

        private void loadBar()
        {
            lblProgress.Visible = true;
            progBar.Visible = true;
            progressBar = new Progress<int>(value =>
            {
                progBar.Value = value;
            });
        }

        private async void btnRegionCSV_Click(object sender, EventArgs e)
        {
            if (appDataFileCheck())
            {
                loadBar();
                progBar.Value = 0;
                lblProgress.Text = "Reading TSM File...";
                var appDataFile = File.ReadAllText(txtPath.Text);
                var region = cmbRegion.Text;
                List<AuctionItem> tsmParseRegion = await Task.Run(() => csvParse.ParseTSMRegion(appDataFile, progressBar, region));
                lblProgress.Text = "Reading TSM File...Done";

                lblProgress.Text = "Parsing TSM AppData...";
                await Task.Run(() => csvParse.ListToCSV(tsmParseRegion, rootDir + @"\\TSMParse.csv", progressBar));
                lblProgress.Text = "Parsing TSM AppData...Done";

                lblProgress.Text = "Reading known Item Entries...";
                List<WoWItem> wowItemParse = await Task.Run(() => csvParse.ReadWoWCSV(wowItemCsv, progressBar));
                lblProgress.Text = "Reading known Item Entries...";

                //lblProgress.Text = "Reading Auction Price Data...";
                //List<AuctionItem> auctionItemParse = await Task.Run(() => csvParse.ReadAuctionCsv(rootDir + @"\\TSMParse.csv", progressBar));
                //lblProgress.Text = "Reading Auction price data...Done";

                lblProgress.Text = "Linking Item Entries with Auction Price Data...";
                await Task.Run(() => csvParse.CombinedCSV(tsmParseRegion, wowItemParse, rootDir + @"\\" + region + "Final.csv", progressBar));
                lblProgress.Text = "Linking Item Entries with Auction Price Data...Done";
                MessageBox.Show("Complete!");
                btnCopy.Visible = true;
            }

        }
    }
}
