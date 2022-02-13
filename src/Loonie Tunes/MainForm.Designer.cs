
namespace Loonie_Tunes
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProg = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.lblRefreshCSV = new System.Windows.Forms.Label();
            this.cmbRealmName = new System.Windows.Forms.ComboBox();
            this.cmbRegion = new System.Windows.Forms.ComboBox();
            this.btnAppData = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.tmrOld = new System.Windows.Forms.Timer(this.components);
            this.btnRegionCSV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCopy.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Location = new System.Drawing.Point(315, 380);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(186, 46);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "Copy Realm CSV to Clipboard";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Visible = false;
            this.btnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowse.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(327, 112);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(159, 53);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(86, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "Path:";
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtPath.Enabled = false;
            this.txtPath.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(134, 171);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(456, 27);
            this.txtPath.TabIndex = 18;
            this.txtPath.WordWrap = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(150, 37);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(500, 51);
            this.textBox1.TabIndex = 15;
            this.textBox1.Text = "Please read through the available README on the GITHUB page for instructions.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 413);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Created and Maintained by DigitalHoax 2022";
            // 
            // btnProg
            // 
            this.btnProg.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnProg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProg.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProg.Location = new System.Drawing.Point(329, 280);
            this.btnProg.Name = "btnProg";
            this.btnProg.Size = new System.Drawing.Size(159, 53);
            this.btnProg.TabIndex = 3;
            this.btnProg.Text = "Build CSV";
            this.btnProg.UseVisualStyleBackColor = false;
            this.btnProg.Visible = false;
            this.btnProg.Click += new System.EventHandler(this.BtnProg_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHelp.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(642, 365);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(127, 51);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.Text = "Need Help?";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(147, 227);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(84, 13);
            this.lblProgress.TabIndex = 23;
            this.lblProgress.Text = "Finding things....";
            this.lblProgress.Visible = false;
            // 
            // progBar
            // 
            this.progBar.Location = new System.Drawing.Point(150, 243);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(500, 23);
            this.progBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progBar.TabIndex = 22;
            this.progBar.Visible = false;
            // 
            // lblRefreshCSV
            // 
            this.lblRefreshCSV.AutoSize = true;
            this.lblRefreshCSV.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefreshCSV.ForeColor = System.Drawing.Color.DarkRed;
            this.lblRefreshCSV.Location = new System.Drawing.Point(284, 338);
            this.lblRefreshCSV.Name = "lblRefreshCSV";
            this.lblRefreshCSV.Size = new System.Drawing.Size(242, 19);
            this.lblRefreshCSV.TabIndex = 24;
            this.lblRefreshCSV.Text = "CSV File is Old, refresh the CSV File.";
            this.lblRefreshCSV.Visible = false;
            // 
            // cmbRealmName
            // 
            this.cmbRealmName.FormattingEnabled = true;
            this.cmbRealmName.Location = new System.Drawing.Point(315, 204);
            this.cmbRealmName.Name = "cmbRealmName";
            this.cmbRealmName.Size = new System.Drawing.Size(192, 21);
            this.cmbRealmName.TabIndex = 2;
            // 
            // cmbRegion
            // 
            this.cmbRegion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbRegion.FormattingEnabled = true;
            this.cmbRegion.Items.AddRange(new object[] {
            "US",
            "EU"});
            this.cmbRegion.Location = new System.Drawing.Point(610, 174);
            this.cmbRegion.Name = "cmbRegion";
            this.cmbRegion.Size = new System.Drawing.Size(40, 21);
            this.cmbRegion.TabIndex = 1;
            this.cmbRegion.Text = "US";
            // 
            // btnAppData
            // 
            this.btnAppData.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAppData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAppData.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppData.Location = new System.Drawing.Point(642, 282);
            this.btnAppData.Name = "btnAppData";
            this.btnAppData.Size = new System.Drawing.Size(127, 51);
            this.btnAppData.TabIndex = 5;
            this.btnAppData.Text = "Open CSV File Location";
            this.btnAppData.UseVisualStyleBackColor = false;
            this.btnAppData.Click += new System.EventHandler(this.BtnAppData_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(697, 428);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(72, 13);
            this.lblVersion.TabIndex = 28;
            this.lblVersion.Text = "Version: 1.3.1";
            // 
            // tmrOld
            // 
            this.tmrOld.Enabled = true;
            this.tmrOld.Interval = 5000;
            this.tmrOld.Tick += new System.EventHandler(this.TmrOld_Tick);
            // 
            // btnRegionCSV
            // 
            this.btnRegionCSV.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnRegionCSV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegionCSV.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegionCSV.Location = new System.Drawing.Point(12, 280);
            this.btnRegionCSV.Name = "btnRegionCSV";
            this.btnRegionCSV.Size = new System.Drawing.Size(134, 53);
            this.btnRegionCSV.TabIndex = 7;
            this.btnRegionCSV.Text = "Build Region CSV";
            this.btnRegionCSV.UseVisualStyleBackColor = false;
            this.btnRegionCSV.Click += new System.EventHandler(this.btnRegionCSV_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRegionCSV);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnAppData);
            this.Controls.Add(this.cmbRegion);
            this.Controls.Add(this.cmbRealmName);
            this.Controls.Add(this.lblRefreshCSV);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progBar);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProg);
            this.Controls.Add(this.btnHelp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSV Pricing Tool";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProg;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar progBar;
        private System.Windows.Forms.Label lblRefreshCSV;
        private System.Windows.Forms.ComboBox cmbRealmName;
        private System.Windows.Forms.ComboBox cmbRegion;
        private System.Windows.Forms.Button btnAppData;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Timer tmrOld;
        private System.Windows.Forms.Button btnRegionCSV;
    }
}