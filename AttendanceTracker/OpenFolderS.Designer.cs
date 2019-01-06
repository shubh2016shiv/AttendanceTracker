namespace AttendanceTracker
{
    partial class OpenFolders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenFolders));
            this.OpenPhotosFolder = new MetroFramework.Controls.MetroTile();
            this.OpenAllRecordsFolder = new MetroFramework.Controls.MetroTile();
            this.CancelOpenFolders = new MetroFramework.Controls.MetroTile();
            this.OpenQRCodeFolder = new MetroFramework.Controls.MetroTile();
            this.MessageBoxText = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // OpenPhotosFolder
            // 
            this.OpenPhotosFolder.ActiveControl = null;
            this.OpenPhotosFolder.Location = new System.Drawing.Point(184, 100);
            this.OpenPhotosFolder.Name = "OpenPhotosFolder";
            this.OpenPhotosFolder.Size = new System.Drawing.Size(117, 69);
            this.OpenPhotosFolder.TabIndex = 1;
            this.OpenPhotosFolder.Text = "Photos";
            this.OpenPhotosFolder.UseSelectable = true;
            this.OpenPhotosFolder.Click += new System.EventHandler(this.OpenPhotosFolder_Click);
            // 
            // OpenAllRecordsFolder
            // 
            this.OpenAllRecordsFolder.ActiveControl = null;
            this.OpenAllRecordsFolder.Location = new System.Drawing.Point(352, 100);
            this.OpenAllRecordsFolder.Name = "OpenAllRecordsFolder";
            this.OpenAllRecordsFolder.Size = new System.Drawing.Size(118, 69);
            this.OpenAllRecordsFolder.TabIndex = 2;
            this.OpenAllRecordsFolder.Text = "All Records";
            this.OpenAllRecordsFolder.UseSelectable = true;
            this.OpenAllRecordsFolder.Click += new System.EventHandler(this.OpenAllRecordsFolder_Click);
            // 
            // CancelOpenFolders
            // 
            this.CancelOpenFolders.ActiveControl = null;
            this.CancelOpenFolders.Location = new System.Drawing.Point(417, 192);
            this.CancelOpenFolders.Name = "CancelOpenFolders";
            this.CancelOpenFolders.Size = new System.Drawing.Size(88, 44);
            this.CancelOpenFolders.Style = MetroFramework.MetroColorStyle.Red;
            this.CancelOpenFolders.TabIndex = 3;
            this.CancelOpenFolders.Text = "Cancel";
            this.CancelOpenFolders.UseSelectable = true;
            this.CancelOpenFolders.Click += new System.EventHandler(this.CancelOpenFolders_Click);
            // 
            // OpenQRCodeFolder
            // 
            this.OpenQRCodeFolder.ActiveControl = null;
            this.OpenQRCodeFolder.Location = new System.Drawing.Point(23, 100);
            this.OpenQRCodeFolder.Name = "OpenQRCodeFolder";
            this.OpenQRCodeFolder.Size = new System.Drawing.Size(115, 69);
            this.OpenQRCodeFolder.TabIndex = 0;
            this.OpenQRCodeFolder.Text = "QR Codes";
            this.OpenQRCodeFolder.TileImage = ((System.Drawing.Image)(resources.GetObject("OpenQRCodeFolder.TileImage")));
            this.OpenQRCodeFolder.TileImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.OpenQRCodeFolder.UseSelectable = true;
            this.OpenQRCodeFolder.Click += new System.EventHandler(this.OpenQRCodeFolder_Click);
            // 
            // MessageBoxText
            // 
            this.MessageBoxText.AutoSize = true;
            this.MessageBoxText.Location = new System.Drawing.Point(24, 64);
            this.MessageBoxText.Name = "MessageBoxText";
            this.MessageBoxText.Size = new System.Drawing.Size(0, 0);
            this.MessageBoxText.TabIndex = 4;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 64);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(283, 20);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "OPEN THE FOLDERS DIRECTLY FROM HERE";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // MessageBoxOpenFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 250);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.MessageBoxText);
            this.Controls.Add(this.CancelOpenFolders);
            this.Controls.Add(this.OpenAllRecordsFolder);
            this.Controls.Add(this.OpenPhotosFolder);
            this.Controls.Add(this.OpenQRCodeFolder);
            this.Name = "MessageBoxOpenFolder";
            this.Text = "Open Folders";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile OpenPhotosFolder;
        private MetroFramework.Controls.MetroTile OpenAllRecordsFolder;
        private MetroFramework.Controls.MetroTile CancelOpenFolders;
        private MetroFramework.Controls.MetroTile OpenQRCodeFolder;
        private MetroFramework.Controls.MetroLabel MessageBoxText;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}