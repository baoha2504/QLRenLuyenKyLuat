
namespace QLRenLuyenKyLuat.GUI_LOP
{
    partial class DSHocvien
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeNghi = new System.Windows.Forms.Button();
            this.datagridDSHV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtBoxCurDay = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.datagridDSHV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(492, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH HỌC VIÊN";
            // 
            // btnDeNghi
            // 
            this.btnDeNghi.BackColor = System.Drawing.Color.White;
            this.btnDeNghi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeNghi.ForeColor = System.Drawing.Color.Green;
            this.btnDeNghi.Location = new System.Drawing.Point(50, 63);
            this.btnDeNghi.Name = "btnDeNghi";
            this.btnDeNghi.Size = new System.Drawing.Size(97, 38);
            this.btnDeNghi.TabIndex = 1;
            this.btnDeNghi.Text = "Đề Nghị";
            this.btnDeNghi.UseVisualStyleBackColor = false;
            this.btnDeNghi.Click += new System.EventHandler(this.btnDeNghi_Click);
            // 
            // datagridDSHV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.datagridDSHV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridDSHV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.datagridDSHV.ColumnHeadersHeight = 40;
            this.datagridDSHV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.datagridDSHV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEdit,
            this.colCheck});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(186)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridDSHV.DefaultCellStyle = dataGridViewCellStyle3;
            this.datagridDSHV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.datagridDSHV.Location = new System.Drawing.Point(59, 132);
            this.datagridDSHV.Name = "datagridDSHV";
            this.datagridDSHV.RowHeadersVisible = false;
            this.datagridDSHV.RowHeadersWidth = 51;
            this.datagridDSHV.RowTemplate.Height = 35;
            this.datagridDSHV.Size = new System.Drawing.Size(1223, 747);
            this.datagridDSHV.TabIndex = 3;
            this.datagridDSHV.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.FeterRiver;
            this.datagridDSHV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.datagridDSHV.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.datagridDSHV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.datagridDSHV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.datagridDSHV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.datagridDSHV.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.datagridDSHV.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.datagridDSHV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.datagridDSHV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.datagridDSHV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.datagridDSHV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.datagridDSHV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.datagridDSHV.ThemeStyle.HeaderStyle.Height = 40;
            this.datagridDSHV.ThemeStyle.ReadOnly = false;
            this.datagridDSHV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(247)))));
            this.datagridDSHV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.datagridDSHV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.datagridDSHV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.datagridDSHV.ThemeStyle.RowsStyle.Height = 35;
            this.datagridDSHV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(186)))), ((int)(((byte)(231)))));
            this.datagridDSHV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.datagridDSHV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridDSHV_CellContentClick);
            // 
            // colEdit
            // 
            this.colEdit.FillWeight = 1.821917F;
            this.colEdit.HeaderText = "Edit";
            this.colEdit.MinimumWidth = 6;
            this.colEdit.Name = "colEdit";
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEdit.Text = ". . .";
            this.colEdit.UseColumnTextForButtonValue = true;
            // 
            // colCheck
            // 
            this.colCheck.FillWeight = 32.24794F;
            this.colCheck.HeaderText = "Check";
            this.colCheck.MinimumWidth = 6;
            this.colCheck.Name = "colCheck";
            // 
            // txtBoxCurDay
            // 
            this.txtBoxCurDay.BorderColor = System.Drawing.Color.White;
            this.txtBoxCurDay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxCurDay.DefaultText = "";
            this.txtBoxCurDay.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBoxCurDay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBoxCurDay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxCurDay.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxCurDay.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxCurDay.Font = new System.Drawing.Font("Times New Roman", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxCurDay.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxCurDay.Location = new System.Drawing.Point(1141, 94);
            this.txtBoxCurDay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBoxCurDay.Name = "txtBoxCurDay";
            this.txtBoxCurDay.PasswordChar = '\0';
            this.txtBoxCurDay.PlaceholderText = "";
            this.txtBoxCurDay.SelectedText = "";
            this.txtBoxCurDay.Size = new System.Drawing.Size(170, 32);
            this.txtBoxCurDay.TabIndex = 4;
            // 
            // DSHocvien
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtBoxCurDay);
            this.Controls.Add(this.datagridDSHV);
            this.Controls.Add(this.btnDeNghi);
            this.Controls.Add(this.label1);
            this.Name = "DSHocvien";
            this.Size = new System.Drawing.Size(1369, 979);
            this.Load += new System.EventHandler(this.DSHocvien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridDSHV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnDeNghi;
        public Guna.UI2.WinForms.Guna2DataGridView datagridDSHV;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxCurDay;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
    }
}
