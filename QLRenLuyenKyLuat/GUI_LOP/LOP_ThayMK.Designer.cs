
namespace QLRenLuyenKyLuat.GUI_LOP
{
    partial class LOP_ThayMK
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbox_curPass = new System.Windows.Forms.TextBox();
            this.txtBox_newPass = new System.Windows.Forms.TextBox();
            this.txtBox_rePass = new System.Windows.Forms.TextBox();
            this.btnChangePass = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(451, 302);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu hiện tại :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(451, 396);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mật khẩu mới :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(451, 507);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nhập lại mật khẩu mới :";
            // 
            // txtbox_curPass
            // 
            this.txtbox_curPass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_curPass.Location = new System.Drawing.Point(706, 297);
            this.txtbox_curPass.Margin = new System.Windows.Forms.Padding(5);
            this.txtbox_curPass.Name = "txtbox_curPass";
            this.txtbox_curPass.PasswordChar = '*';
            this.txtbox_curPass.Size = new System.Drawing.Size(480, 30);
            this.txtbox_curPass.TabIndex = 4;
            // 
            // txtBox_newPass
            // 
            this.txtBox_newPass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_newPass.Location = new System.Drawing.Point(706, 392);
            this.txtBox_newPass.Margin = new System.Windows.Forms.Padding(5);
            this.txtBox_newPass.Name = "txtBox_newPass";
            this.txtBox_newPass.PasswordChar = '*';
            this.txtBox_newPass.Size = new System.Drawing.Size(480, 30);
            this.txtBox_newPass.TabIndex = 5;
            // 
            // txtBox_rePass
            // 
            this.txtBox_rePass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_rePass.Location = new System.Drawing.Point(706, 503);
            this.txtBox_rePass.Margin = new System.Windows.Forms.Padding(5);
            this.txtBox_rePass.Name = "txtBox_rePass";
            this.txtBox_rePass.PasswordChar = '*';
            this.txtBox_rePass.Size = new System.Drawing.Size(480, 30);
            this.txtBox_rePass.TabIndex = 6;
            // 
            // btnChangePass
            // 
            this.btnChangePass.FillColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnChangePass.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePass.ForeColor = System.Drawing.Color.White;
            this.btnChangePass.Location = new System.Drawing.Point(1020, 608);
            this.btnChangePass.Margin = new System.Windows.Forms.Padding(5);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(166, 50);
            this.btnChangePass.TabIndex = 131;
            this.btnChangePass.Text = "Thay đổi";
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // LOP_ThayMK
            // 
            this.Appearance.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnChangePass);
            this.Controls.Add(this.txtBox_rePass);
            this.Controls.Add(this.txtBox_newPass);
            this.Controls.Add(this.txtbox_curPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "LOP_ThayMK";
            this.Size = new System.Drawing.Size(1511, 829);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbox_curPass;
        private System.Windows.Forms.TextBox txtBox_newPass;
        private System.Windows.Forms.TextBox txtBox_rePass;
        private Guna.UI2.WinForms.Guna2Button btnChangePass;
    }
}
