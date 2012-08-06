namespace RSSFeedToBlog
{
    partial class Editor
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbFeedUrl = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLinkCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtStarredAfter = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.tbKnownCategories = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Starred Items Link: ";
            // 
            // tbFeedUrl
            // 
            this.tbFeedUrl.Location = new System.Drawing.Point(138, 55);
            this.tbFeedUrl.Name = "tbFeedUrl";
            this.tbFeedUrl.Size = new System.Drawing.Size(441, 20);
            this.tbFeedUrl.TabIndex = 1;
            this.tbFeedUrl.Text = "http://www.google.com/reader/atom/user/-/state/com.google/starred";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Generate HTML";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Google UserName";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(137, 89);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(161, 20);
            this.tbUserName.TabIndex = 4;
            this.tbUserName.Text = "sumantedla";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(138, 129);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(160, 20);
            this.tbPassword.TabIndex = 6;
            this.tbPassword.Text = "sudha21suman22";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Link Count";
            // 
            // tbLinkCount
            // 
            this.tbLinkCount.Location = new System.Drawing.Point(138, 162);
            this.tbLinkCount.Name = "tbLinkCount";
            this.tbLinkCount.Size = new System.Drawing.Size(100, 20);
            this.tbLinkCount.TabIndex = 10;
            this.tbLinkCount.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Starred After";
            // 
            // dtStarredAfter
            // 
            this.dtStarredAfter.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtStarredAfter.Location = new System.Drawing.Point(138, 194);
            this.dtStarredAfter.Name = "dtStarredAfter";
            this.dtStarredAfter.Size = new System.Drawing.Size(200, 20);
            this.dtStarredAfter.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Known Categories";
            // 
            // tbKnownCategories
            // 
            this.tbKnownCategories.Location = new System.Drawing.Point(138, 234);
            this.tbKnownCategories.Name = "tbKnownCategories";
            this.tbKnownCategories.Size = new System.Drawing.Size(441, 20);
            this.tbKnownCategories.TabIndex = 14;
            this.tbKnownCategories.Text = "C#, Asp.net, Windows Phone, Silverlight, WPF, WCF, Database, Windows 8, Azure, Vi" +
    "sual Studio, Miscellaneous, Client, Kinect, Testing, Videos, Articles";
            // 
            // Editor
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 364);
            this.Controls.Add(this.tbKnownCategories);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtStarredAfter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbLinkCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbFeedUrl);
            this.Controls.Add(this.label1);
            this.Name = "Editor";
            this.Text = "Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFeedUrl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLinkCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtStarredAfter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbKnownCategories;

    }
}