namespace PST_Sorting_App
{
    partial class Form1
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
            this.OrginalPST_textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StoreCount_label = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FolderCount_label = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StoreName_label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RootFolderName_label = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Browse_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OrginalPST_textBox
            // 
            this.OrginalPST_textBox.Location = new System.Drawing.Point(13, 32);
            this.OrginalPST_textBox.Name = "OrginalPST_textBox";
            this.OrginalPST_textBox.Size = new System.Drawing.Size(137, 20);
            this.OrginalPST_textBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Get Info";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(302, 72);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(302, 177);
            this.textBox3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Original PST path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Stores:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RootFolderName_label);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.StoreName_label);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.FolderCount_label);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.StoreCount_label);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 177);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information of PST";
            // 
            // StoreCount_label
            // 
            this.StoreCount_label.AutoSize = true;
            this.StoreCount_label.Location = new System.Drawing.Point(55, 81);
            this.StoreCount_label.Name = "StoreCount_label";
            this.StoreCount_label.Size = new System.Drawing.Size(27, 13);
            this.StoreCount_label.TabIndex = 6;
            this.StoreCount_label.Text = "N/A";
            this.StoreCount_label.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Folders:";
            // 
            // FolderCount_label
            // 
            this.FolderCount_label.AutoSize = true;
            this.FolderCount_label.Location = new System.Drawing.Point(55, 104);
            this.FolderCount_label.Name = "FolderCount_label";
            this.FolderCount_label.Size = new System.Drawing.Size(27, 13);
            this.FolderCount_label.TabIndex = 8;
            this.FolderCount_label.Text = "N/A";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(302, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(180, 20);
            this.textBox2.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(299, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Create Copy of PST:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Store Name:";
            // 
            // StoreName_label
            // 
            this.StoreName_label.AutoSize = true;
            this.StoreName_label.Location = new System.Drawing.Point(78, 25);
            this.StoreName_label.Name = "StoreName_label";
            this.StoreName_label.Size = new System.Drawing.Size(27, 13);
            this.StoreName_label.TabIndex = 10;
            this.StoreName_label.Text = "N/A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Root Folder Name:";
            // 
            // RootFolderName_label
            // 
            this.RootFolderName_label.AutoSize = true;
            this.RootFolderName_label.Location = new System.Drawing.Point(108, 46);
            this.RootFolderName_label.Name = "RootFolderName_label";
            this.RootFolderName_label.Size = new System.Drawing.Size(27, 13);
            this.RootFolderName_label.TabIndex = 12;
            this.RootFolderName_label.Text = "N/A";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Browse_button
            // 
            this.Browse_button.Location = new System.Drawing.Point(156, 32);
            this.Browse_button.Name = "Browse_button";
            this.Browse_button.Size = new System.Drawing.Size(37, 23);
            this.Browse_button.TabIndex = 9;
            this.Browse_button.Text = "...";
            this.Browse_button.UseVisualStyleBackColor = true;
            this.Browse_button.Click += new System.EventHandler(this.Browse_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 261);
            this.Controls.Add(this.Browse_button);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OrginalPST_textBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OrginalPST_textBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label FolderCount_label;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label StoreCount_label;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label RootFolderName_label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label StoreName_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Browse_button;
    }
}

