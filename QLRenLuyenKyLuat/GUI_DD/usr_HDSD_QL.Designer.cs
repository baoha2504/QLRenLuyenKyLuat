﻿namespace QLRenLuyenKyLuat.GUI_DD
{
    partial class usr_HDSD_QL
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
            this.txtNoiDung = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNoiDung.DefaultText = "";
            this.txtNoiDung.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNoiDung.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNoiDung.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNoiDung.DisabledState.Parent = this.txtNoiDung;
            this.txtNoiDung.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNoiDung.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNoiDung.FocusedState.Parent = this.txtNoiDung;
            this.txtNoiDung.Font = new System.Drawing.Font("Times New Roman", 13.8F);
            this.txtNoiDung.ForeColor = System.Drawing.Color.Black;
            this.txtNoiDung.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNoiDung.HoverState.Parent = this.txtNoiDung;
            this.txtNoiDung.Location = new System.Drawing.Point(0, 0);
            this.txtNoiDung.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.PasswordChar = '\0';
            this.txtNoiDung.PlaceholderText = "";
            this.txtNoiDung.ReadOnly = true;
            this.txtNoiDung.SelectedText = "";
            this.txtNoiDung.ShadowDecoration.Parent = this.txtNoiDung;
            this.txtNoiDung.Size = new System.Drawing.Size(1246, 729);
            this.txtNoiDung.TabIndex = 1;
            // 
            // usr_HDSD_QL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNoiDung);
            this.Name = "usr_HDSD_QL";
            this.Size = new System.Drawing.Size(1246, 729);
            this.Load += new System.EventHandler(this.usr_HDSD_QL_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtNoiDung;
    }
}
