namespace Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbIpDest = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.tbDirData = new System.Windows.Forms.TextBox();
            this.tbPortDest = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbIpDest
            // 
            this.tbIpDest.Location = new System.Drawing.Point(49, 35);
            this.tbIpDest.Name = "tbIpDest";
            this.tbIpDest.Size = new System.Drawing.Size(122, 23);
            this.tbIpDest.TabIndex = 1;
            this.tbIpDest.Text = "http://localhost";
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(154, 115);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 23);
            this.btSend.TabIndex = 6;
            this.btSend.Text = "Отправить";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // tbDirData
            // 
            this.tbDirData.Location = new System.Drawing.Point(47, 72);
            this.tbDirData.Name = "tbDirData";
            this.tbDirData.Size = new System.Drawing.Size(181, 23);
            this.tbDirData.TabIndex = 5;
            this.tbDirData.Text = "voyna-i-mir.txt";
            // 
            // tbPortDest
            // 
            this.tbPortDest.Location = new System.Drawing.Point(188, 35);
            this.tbPortDest.Name = "tbPortDest";
            this.tbPortDest.Size = new System.Drawing.Size(41, 23);
            this.tbPortDest.TabIndex = 4;
            this.tbPortDest.Text = "5220";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 231);
            this.Controls.Add(this.btSend);
            this.Controls.Add(this.tbDirData);
            this.Controls.Add(this.tbPortDest);
            this.Controls.Add(this.tbIpDest);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbIpDest;
        private Button btSend;
        private TextBox tbDirData;
        private TextBox tbPortDest;
    }
}