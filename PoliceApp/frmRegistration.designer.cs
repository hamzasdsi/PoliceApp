namespace PoliceApp
{
    partial class frmRegistration
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistration));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.cmbUserType = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Azure;
            this.Panel1.Controls.Add(this.Panel4);
            this.Panel1.Controls.Add(this.Panel3);
            this.Panel1.Controls.Add(this.dgw);
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Location = new System.Drawing.Point(9, 16);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(918, 559);
            this.Panel1.TabIndex = 3;
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.Color.White;
            this.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel4.Controls.Add(this.button1);
            this.Panel4.Controls.Add(this.Label7);
            this.Panel4.Controls.Add(this.Label5);
            this.Panel4.Controls.Add(this.txtContactNo);
            this.Panel4.Controls.Add(this.txtName);
            this.Panel4.Controls.Add(this.txtPassword);
            this.Panel4.Controls.Add(this.Label4);
            this.Panel4.Controls.Add(this.Label2);
            this.Panel4.Controls.Add(this.cmbUserType);
            this.Panel4.Controls.Add(this.Label3);
            this.Panel4.Controls.Add(this.txtUserID);
            this.Panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel4.Location = new System.Drawing.Point(9, 321);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(449, 225);
            this.Panel4.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.button1.Location = new System.Drawing.Point(325, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Valider";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(58, 129);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(68, 18);
            this.Label7.TabIndex = 13;
            this.Label7.Text = "Contact :";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(75, 99);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(49, 18);
            this.Label5.TabIndex = 11;
            this.Label5.Text = "Nom :";
            // 
            // txtContactNo
            // 
            this.txtContactNo.BackColor = System.Drawing.Color.White;
            this.txtContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactNo.Location = new System.Drawing.Point(145, 135);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(157, 24);
            this.txtContactNo.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(145, 104);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(157, 24);
            this.txtName.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(145, 76);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '♠';
            this.txtPassword.Size = new System.Drawing.Size(157, 24);
            this.txtPassword.TabIndex = 2;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(30, 74);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(102, 18);
            this.Label4.TabIndex = 6;
            this.Label4.Text = "Mot de passe:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(8, 49);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(125, 18);
            this.Label2.TabIndex = 5;
            this.Label2.Text = "Type d\'utilisateur :";
            // 
            // cmbUserType
            // 
            this.cmbUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserType.FormattingEnabled = true;
            this.cmbUserType.Items.AddRange(new object[] {
            "Admin",
            "Agent saisie"});
            this.cmbUserType.Location = new System.Drawing.Point(145, 46);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Size = new System.Drawing.Size(157, 26);
            this.cmbUserType.TabIndex = 1;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(45, 24);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(81, 18);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Utilisateur :";
            // 
            // txtUserID
            // 
            this.txtUserID.BackColor = System.Drawing.Color.White;
            this.txtUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Location = new System.Drawing.Point(145, 17);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(157, 24);
            this.txtUserID.TabIndex = 0;
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.Color.White;
            this.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel3.Controls.Add(this.btnDelete);
            this.Panel3.Controls.Add(this.btnUpdate);
            this.Panel3.Controls.Add(this.btnSave);
            this.Panel3.Controls.Add(this.btnNew);
            this.Panel3.Location = new System.Drawing.Point(762, 75);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(124, 174);
            this.Panel3.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.btnDelete.Location = new System.Drawing.Point(12, 119);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 28);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Supprimer";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.btnUpdate.Location = new System.Drawing.Point(12, 88);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(97, 28);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Modifier";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.btnSave.Location = new System.Drawing.Point(12, 57);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Enregistrer";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.btnNew.Location = new System.Drawing.Point(12, 26);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(97, 28);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Nouveau";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite;
            this.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgw.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dgw.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgw.ColumnHeadersHeight = 35;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Description,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6});
            this.dgw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgw.EnableHeadersVisualStyles = false;
            this.dgw.GridColor = System.Drawing.Color.White;
            this.dgw.Location = new System.Drawing.Point(9, 77);
            this.dgw.MultiSelect = false;
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(115)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(115)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgw.RowHeadersWidth = 25;
            this.dgw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(115)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgw.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgw.RowTemplate.Height = 18;
            this.dgw.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(747, 235);
            this.dgw.TabIndex = 1;
            this.dgw.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgw_RowPostPaint);
            this.dgw.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgw_MouseClick);
            // 
            // Description
            // 
            this.Description.HeaderText = "Utilisateur";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Type utilisateur";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Mot de passe";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Nom";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Contact ";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = " Date enregistré";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Location = new System.Drawing.Point(9, 7);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(903, 62);
            this.Panel2.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.Label1.Location = new System.Drawing.Point(294, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(392, 29);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Liste des utilisateurs enregistrés";
            // 
            // frmRegistration
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(941, 587);
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistration";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "Gestion des utilisateurs";
            this.Load += new System.EventHandler(this.frmRegistration_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtContactNo;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cmbUserType;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtUserID;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnUpdate;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.DataGridView dgw;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;

    }
}

