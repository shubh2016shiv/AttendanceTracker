using MetroFramework;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AttendanceTracker
{
    public partial class OpenFolders : MetroFramework.Forms.MetroForm
    {
        public OpenFolders()
        {
            InitializeComponent();
            
        }
        
        private void OpenQRCodeFolder_Click(object sender, System.EventArgs e)
        {
            
            if (Directory.Exists(System.IO.Directory.GetCurrentDirectory() + "\\QR Codes"))
            {
                Process.Start(Directory.GetCurrentDirectory() + "\\QR Codes");
            }
            else
            {
                MetroMessageBox.Show(this, "QR Codes Folder does not exist", "Folder not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            
        }

        private void OpenPhotosFolder_Click(object sender, System.EventArgs e)
        {
            if (Directory.Exists(System.IO.Directory.GetCurrentDirectory() + "\\Photos"))
            {
                Process.Start(Directory.GetCurrentDirectory() + "\\Photos");
            }
            else
            {
                MetroMessageBox.Show(this, "Photos Folder does not exist", "Folder not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OpenAllRecordsFolder_Click(object sender, System.EventArgs e)
        {
            if (Directory.Exists(System.IO.Directory.GetCurrentDirectory() + "\\Saved Records"))
            {
                Process.Start(Directory.GetCurrentDirectory() + "\\Saved Records");

            }
            else
            {
                MetroMessageBox.Show(this, "Folder containing all records does not exist", "Folder not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void CancelOpenFolders_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
