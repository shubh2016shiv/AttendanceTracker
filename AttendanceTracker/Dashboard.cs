using QRCoder;
using System;
using System.Drawing;
using Emgu.CV;
using System.Windows.Forms;
using MetroFramework;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace AttendanceTracker
{
    public partial class DashBoard : MetroFramework.Forms.MetroForm
    {
        public static string studentRollNumber;
        string name;
        private EnrollInformationObject enrollInformationObject;
        private OpenFolders messageBoxOpenFolder;
     
       
        public static List<string> courseList;

        public DashBoard()
        {
            InitializeComponent();
            
            IntializeWithOtherConditions();
            
        }

         

        private void IntializeWithOtherConditions()
        {
            this.DetailPanel.Visible = true;
            this.EnrollStudentPanel.Visible = false;
            if (!File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\QR Codes"))
            {
                Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + "\\QR Codes");
            }
            if (!File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\Photos"))
            {
                Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + "\\Photos");
            }

            string currentDirectory = System.IO.Directory.GetCurrentDirectory() + "\\Saved Records";
            if (File.Exists(currentDirectory + "\\Records.json"))
            {
                Console.WriteLine("Record file found in location: " + System.IO.Directory.GetCurrentDirectory() + "\\Saved Records");
                Console.WriteLine("Start deserializing...");
                List<EnrollInformationObject> savedEnrollInformationObjects = JSON_Deserialize_Serialize.DeSerialize(currentDirectory + "\\Records.json");
                PopulateDataGrid(savedEnrollInformationObjects);
                JSON_Deserialize_Serialize.EnrollInformationObjectsList.AddRange(savedEnrollInformationObjects);

            }
            else
            {
                Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + "\\Saved Records");

            }
            courseList = new List<string>();

           
            


        }

        private void PopulateDataGrid(List<EnrollInformationObject> savedEnrollInformationObjects)
        {
           foreach(EnrollInformationObject savedInfo in savedEnrollInformationObjects)
            {
                Object[] infoArray = new Object[recordsGrid.ColumnCount];
                
                infoArray[0] = savedInfo.FirstName + " " + savedInfo.MiddleName + " " + savedInfo.LastName;
                infoArray[1] = savedInfo.RollNumber;
                infoArray[2] = savedInfo.AssignedCourse;
                infoArray[3] = savedInfo.AssignedTeacher;
                infoArray[4] = savedInfo.ContactNumber;
                infoArray[5] = savedInfo.EnrollmentDate;

                recordsGrid.Rows.Add(infoArray);

            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EnrollStudent_Click(object sender, EventArgs e)
        {
            this.EnrollStudentPanel.Visible = true;
            Program._capture = new VideoCapture();
            CourseComboBox.Items.Clear();
            if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\Course_Data.dat"))
            {
                StreamReader reader = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "\\Course_Data.dat");
                string strAllFile = reader.ReadToEnd();
                string[] coursesInDatFile = strAllFile.Split(',');
                foreach (string courseInDatFile in coursesInDatFile)
                {
                    CourseComboBox.Items.Add(courseInDatFile);
                }
            }

        }

        

        private void GenerateRollNumber_Click(object sender, EventArgs e)
        {
            try
            {
                name = FirstNameTextBox.Text + " " + LastNameTextBox.Text;
                studentRollNumber = CreateRollNumber(FirstNameTextBox.Text, LastNameTextBox.Text, CourseComboBox.Text);
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

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.EnrollStudentPanel.Visible = false;
            Application.Idle -= Streaming;
            Program._capture = null;
        }

        private void Streaming(object sender, System.EventArgs e)
        {
            try
            {
                WebcamViewer.BackgroundImageLayout = ImageLayout.Tile;
                var img = Program._capture.QueryFrame().ToImage<Emgu.CV.Structure.Bgr, byte>();
                
                var bmp = img.ToBitmap();
                WebcamViewer.Image = bmp;

            }
            catch (Exception ex)
            {
                if(ex is NullReferenceException)
                {
                    Console.WriteLine("Video Streaming interrupted due to :" + ex.Message);
                    MetroMessageBox.Show(this,"Error","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                
            }


        }
        
        private void CameraOnOff_CheckedChanged(object sender, EventArgs e)
        {
            if (CameraOnOff.Checked == true)
            {
                panelOverWebcam.Visible = false;
                Application.Idle += Streaming;
                Console.WriteLine("Webcam started");
            }
            else if(CameraOnOff.Checked == false)
            {
                panelOverWebcam.Visible = true;
                Application.Idle -= Streaming;
                Console.WriteLine("Webcam stopped");
            }
        }

        private void CapturePhoto_Click(object sender, EventArgs e)
        {
            if (CameraOnOff.Checked == true)
            {
                Image image = WebcamViewer.Image;
                Application.Idle -= Streaming;
                panelOverWebcam.Visible = true;
                CapturedPhoto.Image = image;
                CameraOnOff.Checked = false;
            }
            else
            {
                MetroMessageBox.Show(this, "First Turn ON the camera", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void SavePhoto_Click(object sender, EventArgs e)
        {
            try
            {
                CapturedPhoto.Image.Save(System.IO.Directory.GetCurrentDirectory() + "\\Photos\\" + studentRollNumber + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                CapturedPhoto.Image = null; 
                CapturedPhoto.BackgroundImage = null;
                MetroMessageBox.Show(this, "Successfully saved", "Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                if(ex is NullReferenceException)
                MetroMessageBox.Show(this, "Error in saving photo. Please check is camera is ON and you have clicked the photo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveEnrollInfo_Click(object sender, EventArgs e)
        {

            DialogResult dr = MetroMessageBox.Show(this,"Have you saved QR code and Photo of student?","Continue?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {   //getting all the values
                    string firstName = FirstNameTextBox.Text;
                    string lastName = LastNameTextBox.Text;
                    string middleName = MiddleNameTextBox.Text;
                    

                    if(firstName.Contains(" ") || lastName.Contains(" ") || middleName.Contains(" "))
                    {
                       MetroMessageBox.Show(this, "First name, Last name or Middle Name contains space(s). Please re-enter information without giving spaces in any of these.", "Spaces not allowed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                    }
                    else {
                        string assignedCourse = CourseComboBox.Text;
                        string rollNumber = studentRollNumber;
                        string assignedTeacher = AssignTeacherTextBox.Text;
                        string contactNumber = PhoneNumberTextBox.Text;
                        string enrollmentDate = DateTime.Now.ToString("d/MM/yyyy");
                        //Serialize them into JSON
                        enrollInformationObject = new EnrollInformationObject(firstName, lastName, middleName, enrollmentDate, assignedCourse, rollNumber, assignedTeacher, contactNumber);
                        JSON_Deserialize_Serialize.EnrollInformationObjectsList.Add(enrollInformationObject);
                        Console.WriteLine("Serializing Started!");
                        JSON_Deserialize_Serialize.Serialize(JSON_Deserialize_Serialize.EnrollInformationObjectsList);
                        //Reset the values
                        FirstNameTextBox.Text = "";
                        LastNameTextBox.Text = "";
                        MiddleNameTextBox.Text = "";
                        CourseComboBox.Text = "";
                        RollNumberTextBox.Text = "";
                        AssignTeacherTextBox.Text = "";
                        PhoneNumberTextBox.Text = "";
                        QRCodePictureBox.BackgroundImage = null;
                        QRCodePictureBox.Image = null;

                        //Saving Course List to dat file
                        //SaveToDatFile("Course_Data", System.IO.Directory.GetCurrentDirectory(), courseList);
                        SaveCourseListInCSV();
                        MetroMessageBox.Show(this, name + "'s record is successfully saved", "Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    

                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, "Error saving " + name + "'s record, Reason: " + ex.Message, "Save Unsuccessfull", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else return;
           
        }
        
        private void OpenAllFoldersButton_Click(object sender, EventArgs e)
        {
            messageBoxOpenFolder = new OpenFolders();
            messageBoxOpenFolder.ShowDialog();
        }

        private void DownloadQRCode_Click(object sender, EventArgs e)
        {
            try
            {
                QRCodePictureBox.BackgroundImage.Save(System.IO.Directory.GetCurrentDirectory() + "\\QR Codes\\" + studentRollNumber + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                MetroMessageBox.Show(this, "Successfully saved", "Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if(ex is NullReferenceException)
                {
                    MetroMessageBox.Show(this, "QR Code is not generated. Click on 'Genarate' button first.", "Error in saving QR Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MetroMessageBox.Show(this, "Error in saving QR code due to: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            DetailPanel.Visible = true;
            EnrollStudentPanel.Visible = false;
        }

       
        //Reseting the whole program and refresh the Data Grid
        public void Refresh_Click(object sender, EventArgs e)
        {
            
            //Reseting Fields in 'Enroll Students'
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            MiddleNameTextBox.Text = "";
            CourseComboBox.Text = "";
            RollNumberTextBox.Text = "";
            AssignTeacherTextBox.Text = "";
            PhoneNumberTextBox.Text = "";

            //Resetting QR code picture box
            QRCodePictureBox.BackgroundImage = null;
            QRCodePictureBox.Image = null;
            
            //Stopping the streaming from webcam
            Application.Idle -= Streaming;
            
            //resetting photo in Photo Booth
            CapturedPhoto.Image = null;
            CapturedPhoto.BackgroundImage = null;

            //refresh datagrid
            
            recordsGrid.Rows.Clear();
            PopulateDataGrid(JSON_Deserialize_Serialize.EnrollInformationObjectsList);
            
        }

        private void AddCourseListButton_Click(object sender, EventArgs e)
        {
            string givenCourseName = CourseComboBox.Text;
                courseList.Add(givenCourseName);
                foreach(string course in courseList)
                {if (!CourseComboBox.Items.Contains(course))
                    CourseComboBox.Items.Add(course);
                else { MetroMessageBox.Show(this, "This Course is already present in List. Please select from list instead.", "Duplicate found!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); break; }
                }
          
        }

        //public bool SaveToDatFile(string FileName, string FilePath, List<string> CourseContents)
        //{
        //    bool Result = false;
        //    try
        //    {
        //        FileStream myFile = File.Create(FilePath + "\\" +  FileName + ".dat");
        //        BinaryWriter binaryfile = new BinaryWriter(myFile);
        //        foreach(string course in CourseContents)
        //        {
        //            binaryfile.Write(course + "\\");
        //        }
                
        //        binaryfile.Close();
        //        myFile.Close();
        //        Result = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        Result = false;
        //    }
        //    return Result;
        //}

        public void SaveCourseListInCSV()
        {
            try
            {
                TextWriter tw = new StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\Course_Data.dat");
                tw.WriteLine(String.Join(",", courseList));
                tw.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

    }
}
