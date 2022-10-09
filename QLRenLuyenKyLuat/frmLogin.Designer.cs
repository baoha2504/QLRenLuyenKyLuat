namespace QLRenLuyenKyLuat
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
            this.GuiCB = new Guna.UI2.WinForms.Guna2Button();
            this.GuiLT = new Guna.UI2.WinForms.Guna2Button();
            this.GuiHV = new Guna.UI2.WinForms.Guna2Button();
            this.GuiAdmin = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // GuiCB
            // 
            this.GuiCB.CheckedState.Parent = this.GuiCB;
            this.GuiCB.CustomImages.Parent = this.GuiCB;
            this.GuiCB.FillColor = System.Drawing.Color.Blue;
            this.GuiCB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GuiCB.ForeColor = System.Drawing.Color.White;
            this.GuiCB.HoverState.Parent = this.GuiCB;
            this.GuiCB.Location = new System.Drawing.Point(98, 482);
            this.GuiCB.Name = "GuiCB";
            this.GuiCB.ShadowDecoration.Parent = this.GuiCB;
            this.GuiCB.Size = new System.Drawing.Size(185, 51);
            this.GuiCB.TabIndex = 0;
            this.GuiCB.Text = "Vào GUI Cán bộ";
            this.GuiCB.Click += new System.EventHandler(this.GuiCB_Click);
            // 
            // GuiLT
            // 
            this.GuiLT.CheckedState.Parent = this.GuiLT;
            this.GuiLT.CustomImages.Parent = this.GuiLT;
            this.GuiLT.FillColor = System.Drawing.Color.Blue;
            this.GuiLT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GuiLT.ForeColor = System.Drawing.Color.White;
            this.GuiLT.HoverState.Parent = this.GuiLT;
            this.GuiLT.Location = new System.Drawing.Point(411, 482);
            this.GuiLT.Name = "GuiLT";
            this.GuiLT.ShadowDecoration.Parent = this.GuiLT;
            this.GuiLT.Size = new System.Drawing.Size(185, 51);
            this.GuiLT.TabIndex = 1;
            this.GuiLT.Text = "Vào GUI Lớp trưởng";
            this.GuiLT.Click += new System.EventHandler(this.GuiLT_Click);
            // 
            // GuiHV
            // 
            this.GuiHV.CheckedState.Parent = this.GuiHV;
            this.GuiHV.CustomImages.Parent = this.GuiHV;
            this.GuiHV.FillColor = System.Drawing.Color.Blue;
            this.GuiHV.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GuiHV.ForeColor = System.Drawing.Color.White;
            this.GuiHV.HoverState.Parent = this.GuiHV;
            this.GuiHV.Location = new System.Drawing.Point(716, 482);
            this.GuiHV.Name = "GuiHV";
            this.GuiHV.ShadowDecoration.Parent = this.GuiHV;
            this.GuiHV.Size = new System.Drawing.Size(185, 51);
            this.GuiHV.TabIndex = 2;
            this.GuiHV.Text = "Vào GUI Học viên";
            this.GuiHV.Click += new System.EventHandler(this.GuiHV_Click);
            // 
            // GuiAdmin
            // 
            this.GuiAdmin.CheckedState.Parent = this.GuiAdmin;
            this.GuiAdmin.CustomImages.Parent = this.GuiAdmin;
            this.GuiAdmin.FillColor = System.Drawing.Color.Blue;
            this.GuiAdmin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GuiAdmin.ForeColor = System.Drawing.Color.White;
            this.GuiAdmin.HoverState.Parent = this.GuiAdmin;
            this.GuiAdmin.Location = new System.Drawing.Point(411, 269);
            this.GuiAdmin.Name = "GuiAdmin";
            this.GuiAdmin.ShadowDecoration.Parent = this.GuiAdmin;
            this.GuiAdmin.Size = new System.Drawing.Size(185, 51);
            this.GuiAdmin.TabIndex = 3;
            this.GuiAdmin.Text = "Vào GUI Admin";
            this.GuiAdmin.Click += new System.EventHandler(this.GuiAdmin_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 614);
            this.Controls.Add(this.GuiAdmin);
            this.Controls.Add(this.GuiHV);
            this.Controls.Add(this.GuiLT);
            this.Controls.Add(this.GuiCB);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button GuiCB;
        private Guna.UI2.WinForms.Guna2Button GuiLT;
        private Guna.UI2.WinForms.Guna2Button GuiHV;
        private Guna.UI2.WinForms.Guna2Button GuiAdmin;
    }
}

