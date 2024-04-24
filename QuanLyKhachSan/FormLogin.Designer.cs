namespace QuanLyKhachSan
{
    partial class FormLogin
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.label_user = new System.Windows.Forms.Label();
            this.label_mk = new System.Windows.Forms.Label();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLogin.Location = new System.Drawing.Point(212, 221);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(133, 36);
            this.btnLogin.TabIndex = 23;
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_user.Location = new System.Drawing.Point(83, 75);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(86, 25);
            this.label_user.TabIndex = 3;
            this.label_user.Text = "Tài khoản";
            // 
            // label_mk
            // 
            this.label_mk.AutoSize = true;
            this.label_mk.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_mk.Location = new System.Drawing.Point(83, 135);
            this.label_mk.Name = "label_mk";
            this.label_mk.Size = new System.Drawing.Size(86, 25);
            this.label_mk.TabIndex = 5;
            this.label_mk.Text = "Mật khẩu";
            // 
            // txtTK
            // 
            this.txtTK.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTK.Location = new System.Drawing.Point(212, 69);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(186, 31);
            this.txtTK.TabIndex = 24;
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtPass.Location = new System.Drawing.Point(212, 132);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(186, 31);
            this.txtPass.TabIndex = 25;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 369);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtTK);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label_mk);
            this.Controls.Add(this.label_user);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.Label label_mk;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.TextBox txtPass;
    }
}