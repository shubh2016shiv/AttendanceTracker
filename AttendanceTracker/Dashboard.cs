using QRCoder;
using System;
using System.Drawing;
using Emgu.CV;
using System.Windows.Forms;
using MetroFramework;
using System.IO;

namespace AttendanceTracker
{
    public partial class DashBoard : MetroFramework.Forms.MetroForm
    {
        VideoCapture _capture;
        Image qrCodeDefaultImage;
        public static string studentRollNumber;
        public DashBoard()
        {
            InitializeComponent();
            this.DetailPanel.Visible = true;
            this.EnrollStudentPanel.Visible = false;
            qrCodeDefaultImage = QRCodePictureBox.BackgroundImage;
            if (!File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\QR Codes"))
            {
                System.IO.Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + "\\QR Codes");
            }
            
                
        }
        
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EnrollStudent_Click(object sender, EventArgs e)
        {
            this.EnrollStudentPanel.Visible = true;
            _capture = new VideoCapture();
        }

        private void GenerateRollNumber_Click(object sender, EventArgs e)
        {
            try
            {
                studentRollNumber = CreateRollNumber(this.FirstNameTextBox.Text, this.LastNameTextBox.Text, this.CourseAssigned.Name);
                QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
                QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(studentRollNumber, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qRCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(5);
                QRCodePictureBox.BackgroundImage = qrCodeImage;
                RollNumberTextBox.Text = studentRollNumber;
                SaveEnrollInfo.Enabled = true;
            }
            catch (Exception exception)
            {
                if(exception is IndexOutOfRangeException)
                {
                    MetroMessageBox.Show(this, "Insufficient information given !","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            
        }

        private string CreateRollNumber(string firstName, string lastName, string course)
        {
            
            string nameInitials = firstName[0].ToString() + lastName[0].ToString();
            string courseInitials = course.Substring(0, 3);
            Random rand = new Random();
            int fourDigitRandNum = rand.Next(1000, 9999);
            return (nameInitials + courseInitials + fourDigitRandNum.ToString());
            
        }

        private void StartWebcamCircularButton_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Idle += Streaming;
                Console.WriteLine("Webcam started");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          
        }

        

        private void CapturePhotoCircularButton_Click(object sender, EventArgs e)
        {
            
            
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.EnrollStudentPanel.Visible = false;
            this.DetailPanel.Visible = true;
            _capture = null;
        }

        private void Streaming(object sender, System.EventArgs e)
        {
            try
            {
                PhotoPictureBox.BackgroundImageLayout = ImageLayout.Tile;
                var img = _capture.QueryFrame().ToImage<Emgu.CV.Structure.Bgr, byte>();
                
                var bmp = img.ToBitmap();
                PhotoPictureBox.Image = bmp;

            }
            catch (Exception ex)
            {
                if(ex is NullReferenceException)
                {
                    this.Close();
                    Console.WriteLine("Video Streaming interrupted due to :" + ex.Message);
                    MetroMessageBox.Show(this,"Error","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    
                }
                
            }


        }

        private void DownloadQRCode_Click(object sender, EventArgs e)
        {
           
        QRCodePictureBox.Image.Save(System.IO.Directory.GetCurrentDirectory() + "\\QR Codes\\" + studentRollNumber + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            
        }
        
    }
}
