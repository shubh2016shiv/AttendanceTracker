namespace AttendanceTracker
{
    partial class AddCourseFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCourseFrm));
            this.CourseName = new MetroFramework.Controls.MetroLabel();
            this.CourseNameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.AddCourseNameButton = new MetroFramework.Controls.MetroTile();
            this.Cancel = new MetroFramework.Controls.MetroTile();
            this.RemoveCourseNameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CourseName
            // 
            this.CourseName.AutoSize = true;
            this.CourseName.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.CourseName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.CourseName.ForeColor = System.Drawing.Color.Silver;
            this.CourseName.Location = new System.Drawing.Point(24, 92);
            this.CourseName.Name = "CourseName";
            this.CourseName.Size = new System.Drawing.Size(131, 25);
            this.CourseName.TabIndex = 0;
            this.CourseName.Text = "Course Name";
            this.CourseName.UseCustomBackColor = true;
            this.CourseName.UseCustomForeColor = true;
            // 
            // CourseNameTextBox
            // 
            // 
            // 
            // 
            this.CourseNameTextBox.CustomButton.Image = null;
            this.CourseNameTextBox.CustomButton.Location = new System.Drawing.Point(180, 1);
            this.CourseNameTextBox.CustomButton.Name = "";
            this.CourseNameTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CourseNameTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CourseNameTextBox.CustomButton.TabIndex = 1;
            this.CourseNameTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CourseNameTextBox.CustomButton.UseSelectable = true;
            this.CourseNameTextBox.CustomButton.Visible = false;
            this.CourseNameTextBox.Lines = new string[0];
            this.CourseNameTextBox.Location = new System.Drawing.Point(176, 94);
            this.CourseNameTextBox.MaxLength = 32767;
            this.CourseNameTextBox.Name = "CourseNameTextBox";
            this.CourseNameTextBox.PasswordChar = '\0';
            this.CourseNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CourseNameTextBox.SelectedText = "";
            this.CourseNameTextBox.SelectionLength = 0;
            this.CourseNameTextBox.SelectionStart = 0;
            this.CourseNameTextBox.ShortcutsEnabled = true;
            this.CourseNameTextBox.Size = new System.Drawing.Size(202, 23);
            this.CourseNameTextBox.TabIndex = 1;
            this.CourseNameTextBox.UseSelectable = true;
            this.CourseNameTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CourseNameTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            
            // 
            // AddCourseNameButton
            // 
            this.AddCourseNameButton.ActiveControl = null;
            this.AddCourseNameButton.Location = new System.Drawing.Point(152, 156);
            this.AddCourseNameButton.Name = "AddCourseNameButton";
            this.AddCourseNameButton.Size = new System.Drawing.Size(99, 43);
            this.AddCourseNameButton.Style = MetroFramework.MetroColorStyle.Green;
            this.AddCourseNameButton.TabIndex = 2;
            this.AddCourseNameButton.Text = "Add";
            this.AddCourseNameButton.UseSelectable = true;
            this.AddCourseNameButton.Click += new System.EventHandler(this.AddCourseNameButton_Click);
            // 
            // Cancel
            // 
            this.Cancel.ActiveControl = null;
            this.Cancel.Location = new System.Drawing.Point(271, 156);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(99, 43);
            this.Cancel.Style = MetroFramework.MetroColorStyle.Red;
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseSelectable = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // RemoveCourseNameButton
            // 
            this.RemoveCourseNameButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RemoveCourseNameButton.BackgroundImage")));
            this.RemoveCourseNameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RemoveCourseNameButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RemoveCourseNameButton.Location = new System.Drawing.Point(375, 92);
            this.RemoveCourseNameButton.Name = "RemoveCourseNameButton";
            this.RemoveCourseNameButton.Size = new System.Drawing.Size(35, 25);
            this.RemoveCourseNameButton.TabIndex = 4;
            this.RemoveCourseNameButton.UseVisualStyleBackColor = true;
            this.RemoveCourseNameButton.Click += new System.EventHandler(this.RemoveCourseNameButton_Click);
            // 
            // AddCourseFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 227);
            this.Controls.Add(this.RemoveCourseNameButton);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.AddCourseNameButton);
            this.Controls.Add(this.CourseNameTextBox);
            this.Controls.Add(this.CourseName);
            this.MaximizeBox = false;
            this.Name = "AddCourseFrm";
            this.Resizable = false;
            this.Text = "Add Course";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel CourseName;
        private MetroFramework.Controls.MetroTextBox CourseNameTextBox;
        private MetroFramework.Controls.MetroTile AddCourseNameButton;
        private MetroFramework.Controls.MetroTile Cancel;
        private System.Windows.Forms.Button RemoveCourseNameButton;
    }
}