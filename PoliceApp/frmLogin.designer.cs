namespace PoliceApp
{
    partial class frmLogin
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
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.button15 = new System.Windows.Forms.Button();
            this.Password = new MetroFramework.Controls.MetroTextBox();
            this.passwordLabel = new MetroFramework.Controls.MetroLabel();
            this.usernameLabel = new MetroFramework.Controls.MetroLabel();
            this.UserID = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel2
            // 
            this.metroPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(39)))), ((int)(((byte)(80)))));
            this.metroPanel2.Controls.Add(this.button15);
            this.metroPanel2.Controls.Add(this.Password);
            this.metroPanel2.Controls.Add(this.passwordLabel);
            this.metroPanel2.Controls.Add(this.usernameLabel);
            this.metroPanel2.Controls.Add(this.UserID);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(23, 33);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(322, 501);
            this.metroPanel2.TabIndex = 31;
            this.metroPanel2.UseCustomBackColor = true;
            this.metroPanel2.UseCustomForeColor = true;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(24)))), ((int)(((byte)(69)))));
            this.button15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(98)))));
            this.button15.Location = new System.Drawing.Point(31, 288);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(255, 34);
            this.button15.TabIndex = 29;
            this.button15.Text = "Connexion";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button3_Click);
            // 
            // Password
            // 
            this.Password.BackColor = System.Drawing.Color.White;
            this.Password.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.Password.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.Password.Lines = new string[0];
            this.Password.Location = new System.Drawing.Point(33, 204);
            this.Password.Margin = new System.Windows.Forms.Padding(4);
            this.Password.MaxLength = 32767;
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.PromptText = "Mot de passe";
            this.Password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Password.SelectedText = "";
            this.Password.Size = new System.Drawing.Size(253, 36);
            this.Password.Style = MetroFramework.MetroColorStyle.Purple;
            this.Password.TabIndex = 1;
            this.Password.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Password.UseCustomBackColor = true;
            this.Password.UseCustomForeColor = true;
            this.Password.UseSelectable = true;
            this.Password.UseStyleColors = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.BackColor = System.Drawing.Color.Transparent;
            this.passwordLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.passwordLabel.ForeColor = System.Drawing.Color.White;
            this.passwordLabel.Location = new System.Drawing.Point(31, 180);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(98, 20);
            this.passwordLabel.Style = MetroFramework.MetroColorStyle.White;
            this.passwordLabel.TabIndex = 10;
            this.passwordLabel.Text = "Mot de passe";
            this.passwordLabel.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passwordLabel.UseCustomBackColor = true;
            this.passwordLabel.UseCustomForeColor = true;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.BackColor = System.Drawing.Color.Transparent;
            this.usernameLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.usernameLabel.ForeColor = System.Drawing.Color.White;
            this.usernameLabel.Location = new System.Drawing.Point(31, 106);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(76, 20);
            this.usernameLabel.Style = MetroFramework.MetroColorStyle.White;
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Utilisateur";
            this.usernameLabel.Theme = MetroFramework.MetroThemeStyle.Light;
            this.usernameLabel.UseCustomBackColor = true;
            this.usernameLabel.UseCustomForeColor = true;
            // 
            // UserID
            // 
            this.UserID.BackColor = System.Drawing.Color.White;
            this.UserID.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.UserID.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.UserID.Lines = new string[0];
            this.UserID.Location = new System.Drawing.Point(33, 135);
            this.UserID.Margin = new System.Windows.Forms.Padding(4);
            this.UserID.MaxLength = 32767;
            this.UserID.Name = "UserID";
            this.UserID.PasswordChar = '\0';
            this.UserID.PromptText = "Utilisateur";
            this.UserID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.UserID.SelectedText = "";
            this.UserID.Size = new System.Drawing.Size(253, 36);
            this.UserID.Style = MetroFramework.MetroColorStyle.Purple;
            this.UserID.TabIndex = 0;
            this.UserID.Theme = MetroFramework.MetroThemeStyle.Light;
            this.UserID.UseCustomBackColor = true;
            this.UserID.UseCustomForeColor = true;
            this.UserID.UseSelectable = true;
            this.UserID.UseStyleColors = true;
            // 
            // frmLogin
            // 
            this.BackgroundImage = global::PoliceApp.Properties.Resources.images__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackImage = global::PoliceApp.Properties.Resources.images__1_;
            this.ClientSize = new System.Drawing.Size(371, 550);
            this.Controls.Add(this.metroPanel2);
            this.Name = "frmLogin";
            this.Opacity = 0.99D;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ProgressBar ProgressBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        internal System.Windows.Forms.Button button15;
        public MetroFramework.Controls.MetroTextBox Password;
        private MetroFramework.Controls.MetroLabel passwordLabel;
        private MetroFramework.Controls.MetroLabel usernameLabel;
        public MetroFramework.Controls.MetroTextBox UserID;
    }
}