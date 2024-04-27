namespace QuanLyKhachSan
{
    partial class fdanhgia
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
            this.tbDanhGia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.cbbRate = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbDanhGia
            // 
            this.tbDanhGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDanhGia.ForeColor = System.Drawing.Color.Black;
            this.tbDanhGia.Location = new System.Drawing.Point(51, 107);
            this.tbDanhGia.Multiline = true;
            this.tbDanhGia.Name = "tbDanhGia";
            this.tbDanhGia.Size = new System.Drawing.Size(571, 211);
            this.tbDanhGia.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 28);
            this.label1.TabIndex = 28;
            this.label1.Text = "Đánh giá:";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.Location = new System.Drawing.Point(518, 335);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(104, 36);
            this.btnXacNhan.TabIndex = 31;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // cbbRate
            // 
            this.cbbRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbRate.FormattingEnabled = true;
            this.cbbRate.Items.AddRange(new object[] {
            "1 sao",
            "2 sao",
            "3 sao",
            "4 sao",
            "5 sao"});
            this.cbbRate.Location = new System.Drawing.Point(194, 39);
            this.cbbRate.Name = "cbbRate";
            this.cbbRate.Size = new System.Drawing.Size(230, 33);
            this.cbbRate.TabIndex = 33;
            // 
            // fdanhgia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 398);
            this.Controls.Add(this.cbbRate);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.tbDanhGia);
            this.Controls.Add(this.label1);
            this.Name = "fdanhgia";
            this.Text = "fdanhgia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDanhGia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.ComboBox cbbRate;
    }
}