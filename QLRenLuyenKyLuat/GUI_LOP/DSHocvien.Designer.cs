
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDeNghi = new System.Windows.Forms.Button();
            this.datagridDSHV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtBoxCurDay = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxNgDG = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBoxXepLoai = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBoxSum = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBoxDiemHT = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBoxDiemLS = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtboxDiemKL = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBoxTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtboxMaHV = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBox_NhanXet = new Guna.UI2.WinForms.Guna2TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.datagridDSHV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeNghi
            // 
            this.btnDeNghi.BackColor = System.Drawing.Color.White;
            this.btnDeNghi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeNghi.ForeColor = System.Drawing.Color.Green;
            this.btnDeNghi.Location = new System.Drawing.Point(784, 132);
            this.btnDeNghi.Name = "btnDeNghi";
            this.btnDeNghi.Size = new System.Drawing.Size(97, 38);
            this.btnDeNghi.TabIndex = 1;
            this.btnDeNghi.Text = "Đề Nghị";
            this.btnDeNghi.UseVisualStyleBackColor = false;
            this.btnDeNghi.Click += new System.EventHandler(this.btnDeNghi_Click);
            // 
            // datagridDSHV
            // 
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(244)))));
            this.datagridDSHV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle28;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle29.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridDSHV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.datagridDSHV.ColumnHeadersHeight = 40;
            this.datagridDSHV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.datagridDSHV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck});
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(234)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle30.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(186)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridDSHV.DefaultCellStyle = dataGridViewCellStyle30;
            this.datagridDSHV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(220)))), ((int)(((byte)(242)))));
            this.datagridDSHV.Location = new System.Drawing.Point(59, 132);
            this.datagridDSHV.Name = "datagridDSHV";
            this.datagridDSHV.RowHeadersVisible = false;
            this.datagridDSHV.RowHeadersWidth = 51;
            this.datagridDSHV.RowTemplate.Height = 35;
            this.datagridDSHV.Size = new System.Drawing.Size(664, 690);
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
            this.txtBoxCurDay.Font = new System.Drawing.Font("Times New Roman", 13.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.txtBoxCurDay.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxCurDay.Location = new System.Drawing.Point(1208, 50);
            this.txtBoxCurDay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBoxCurDay.Name = "txtBoxCurDay";
            this.txtBoxCurDay.PasswordChar = '\0';
            this.txtBoxCurDay.PlaceholderText = "";
            this.txtBoxCurDay.SelectedText = "";
            this.txtBoxCurDay.Size = new System.Drawing.Size(170, 32);
            this.txtBoxCurDay.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(382, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(729, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "NHẬP KẾT QUẢ RÈN LUYỆN KỶ LUẬT THEO THÁNG";
            // 
            // txtBoxNgDG
            // 
            this.txtBoxNgDG.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxNgDG.DefaultText = "";
            this.txtBoxNgDG.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBoxNgDG.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBoxNgDG.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxNgDG.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxNgDG.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxNgDG.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxNgDG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtBoxNgDG.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxNgDG.Location = new System.Drawing.Point(941, 882);
            this.txtBoxNgDG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBoxNgDG.Name = "txtBoxNgDG";
            this.txtBoxNgDG.PasswordChar = '\0';
            this.txtBoxNgDG.PlaceholderText = "";
            this.txtBoxNgDG.ReadOnly = true;
            this.txtBoxNgDG.SelectedText = "";
            this.txtBoxNgDG.Size = new System.Drawing.Size(242, 45);
            this.txtBoxNgDG.TabIndex = 55;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(784, 895);
            this.label8.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 21);
            this.label8.TabIndex = 54;
            this.label8.Text = "Người đánh giá: ";
            // 
            // txtBoxXepLoai
            // 
            this.txtBoxXepLoai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxXepLoai.DefaultText = "";
            this.txtBoxXepLoai.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBoxXepLoai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBoxXepLoai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxXepLoai.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxXepLoai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxXepLoai.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxXepLoai.ForeColor = System.Drawing.Color.Red;
            this.txtBoxXepLoai.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxXepLoai.Location = new System.Drawing.Point(1217, 809);
            this.txtBoxXepLoai.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBoxXepLoai.Name = "txtBoxXepLoai";
            this.txtBoxXepLoai.PasswordChar = '\0';
            this.txtBoxXepLoai.PlaceholderText = "";
            this.txtBoxXepLoai.ReadOnly = true;
            this.txtBoxXepLoai.SelectedText = "";
            this.txtBoxXepLoai.Size = new System.Drawing.Size(81, 45);
            this.txtBoxXepLoai.TabIndex = 53;
            // 
            // txtBoxSum
            // 
            this.txtBoxSum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxSum.DefaultText = "";
            this.txtBoxSum.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBoxSum.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBoxSum.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxSum.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxSum.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxSum.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSum.ForeColor = System.Drawing.Color.Black;
            this.txtBoxSum.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxSum.Location = new System.Drawing.Point(941, 809);
            this.txtBoxSum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBoxSum.Name = "txtBoxSum";
            this.txtBoxSum.PasswordChar = '\0';
            this.txtBoxSum.PlaceholderText = "";
            this.txtBoxSum.ReadOnly = true;
            this.txtBoxSum.SelectedText = "";
            this.txtBoxSum.Size = new System.Drawing.Size(81, 45);
            this.txtBoxSum.TabIndex = 52;
            this.txtBoxSum.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtBoxSum_MouseClick);
            // 
            // txtBoxDiemHT
            // 
            this.txtBoxDiemHT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxDiemHT.DefaultText = "";
            this.txtBoxDiemHT.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBoxDiemHT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBoxDiemHT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxDiemHT.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxDiemHT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxDiemHT.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDiemHT.ForeColor = System.Drawing.Color.Black;
            this.txtBoxDiemHT.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxDiemHT.Location = new System.Drawing.Point(941, 570);
            this.txtBoxDiemHT.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBoxDiemHT.Name = "txtBoxDiemHT";
            this.txtBoxDiemHT.PasswordChar = '\0';
            this.txtBoxDiemHT.PlaceholderText = "";
            this.txtBoxDiemHT.SelectedText = "";
            this.txtBoxDiemHT.Size = new System.Drawing.Size(81, 45);
            this.txtBoxDiemHT.TabIndex = 51;
            this.txtBoxDiemHT.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxDiemHT_Validating);
            // 
            // txtBoxDiemLS
            // 
            this.txtBoxDiemLS.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxDiemLS.DefaultText = "";
            this.txtBoxDiemLS.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBoxDiemLS.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBoxDiemLS.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxDiemLS.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxDiemLS.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxDiemLS.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDiemLS.ForeColor = System.Drawing.Color.Black;
            this.txtBoxDiemLS.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxDiemLS.Location = new System.Drawing.Point(941, 483);
            this.txtBoxDiemLS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBoxDiemLS.Name = "txtBoxDiemLS";
            this.txtBoxDiemLS.PasswordChar = '\0';
            this.txtBoxDiemLS.PlaceholderText = "";
            this.txtBoxDiemLS.SelectedText = "";
            this.txtBoxDiemLS.Size = new System.Drawing.Size(81, 45);
            this.txtBoxDiemLS.TabIndex = 50;
            this.txtBoxDiemLS.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxDiemLS_Validating);
            // 
            // txtboxDiemKL
            // 
            this.txtboxDiemKL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtboxDiemKL.DefaultText = "";
            this.txtboxDiemKL.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtboxDiemKL.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtboxDiemKL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtboxDiemKL.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtboxDiemKL.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtboxDiemKL.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxDiemKL.ForeColor = System.Drawing.Color.Black;
            this.txtboxDiemKL.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtboxDiemKL.Location = new System.Drawing.Point(941, 399);
            this.txtboxDiemKL.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtboxDiemKL.Name = "txtboxDiemKL";
            this.txtboxDiemKL.PasswordChar = '\0';
            this.txtboxDiemKL.PlaceholderText = "";
            this.txtboxDiemKL.SelectedText = "";
            this.txtboxDiemKL.Size = new System.Drawing.Size(81, 45);
            this.txtboxDiemKL.TabIndex = 49;
            this.txtboxDiemKL.Validating += new System.ComponentModel.CancelEventHandler(this.txtboxDiemKL_Validating);
            // 
            // txtBoxTen
            // 
            this.txtBoxTen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxTen.DefaultText = "";
            this.txtBoxTen.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBoxTen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBoxTen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxTen.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxTen.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxTen.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxTen.ForeColor = System.Drawing.Color.Black;
            this.txtBoxTen.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxTen.Location = new System.Drawing.Point(941, 320);
            this.txtBoxTen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBoxTen.Name = "txtBoxTen";
            this.txtBoxTen.PasswordChar = '\0';
            this.txtBoxTen.PlaceholderText = "";
            this.txtBoxTen.ReadOnly = true;
            this.txtBoxTen.SelectedText = "";
            this.txtBoxTen.Size = new System.Drawing.Size(242, 45);
            this.txtBoxTen.TabIndex = 48;
            // 
            // txtboxMaHV
            // 
            this.txtboxMaHV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtboxMaHV.DefaultText = "";
            this.txtboxMaHV.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtboxMaHV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtboxMaHV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtboxMaHV.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtboxMaHV.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtboxMaHV.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxMaHV.ForeColor = System.Drawing.Color.Black;
            this.txtboxMaHV.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtboxMaHV.Location = new System.Drawing.Point(941, 228);
            this.txtboxMaHV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtboxMaHV.Multiline = true;
            this.txtboxMaHV.Name = "txtboxMaHV";
            this.txtboxMaHV.PasswordChar = '\0';
            this.txtboxMaHV.PlaceholderText = "";
            this.txtboxMaHV.ReadOnly = true;
            this.txtboxMaHV.SelectedText = "";
            this.txtboxMaHV.Size = new System.Drawing.Size(242, 45);
            this.txtboxMaHV.TabIndex = 47;
            // 
            // txtBox_NhanXet
            // 
            this.txtBox_NhanXet.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBox_NhanXet.DefaultText = "";
            this.txtBox_NhanXet.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBox_NhanXet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBox_NhanXet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBox_NhanXet.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBox_NhanXet.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBox_NhanXet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_NhanXet.ForeColor = System.Drawing.Color.Black;
            this.txtBox_NhanXet.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBox_NhanXet.Location = new System.Drawing.Point(941, 634);
            this.txtBox_NhanXet.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBox_NhanXet.Multiline = true;
            this.txtBox_NhanXet.Name = "txtBox_NhanXet";
            this.txtBox_NhanXet.PasswordChar = '\0';
            this.txtBox_NhanXet.PlaceholderText = "";
            this.txtBox_NhanXet.SelectedText = "";
            this.txtBox_NhanXet.Size = new System.Drawing.Size(362, 159);
            this.txtBox_NhanXet.TabIndex = 46;
            this.txtBox_NhanXet.Validating += new System.ComponentModel.CancelEventHandler(this.txtBox_NhanXet_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1129, 824);
            this.label12.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 21);
            this.label12.TabIndex = 45;
            this.label12.Text = "Xếp loại :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(784, 824);
            this.label11.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 21);
            this.label11.TabIndex = 44;
            this.label11.Text = "Tổng điểm :";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1274, 886);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 41);
            this.btnSave.TabIndex = 43;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(784, 668);
            this.label7.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 21);
            this.label7.TabIndex = 42;
            this.label7.Text = "Nhận xét :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(781, 507);
            this.label6.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 21);
            this.label6.TabIndex = 41;
            this.label6.Text = "Điểm lối sống :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(784, 594);
            this.label5.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 21);
            this.label5.TabIndex = 40;
            this.label5.Text = "Điểm học tập :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(781, 423);
            this.label4.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 21);
            this.label4.TabIndex = 39;
            this.label4.Text = "Điểm kỷ luật :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(781, 344);
            this.label3.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 21);
            this.label3.TabIndex = 38;
            this.label3.Text = "Họ và tên :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(780, 252);
            this.label1.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 21);
            this.label1.TabIndex = 37;
            this.label1.Text = "Mã học viên :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DSHocvien
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtBoxNgDG);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBoxXepLoai);
            this.Controls.Add(this.txtBoxSum);
            this.Controls.Add(this.txtBoxDiemHT);
            this.Controls.Add(this.txtBoxDiemLS);
            this.Controls.Add(this.txtboxDiemKL);
            this.Controls.Add(this.txtBoxTen);
            this.Controls.Add(this.txtboxMaHV);
            this.Controls.Add(this.txtBox_NhanXet);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBoxCurDay);
            this.Controls.Add(this.datagridDSHV);
            this.Controls.Add(this.btnDeNghi);
            this.Name = "DSHocvien";
            this.Size = new System.Drawing.Size(1694, 979);
            this.Load += new System.EventHandler(this.DSHocvien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridDSHV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button btnDeNghi;
        public Guna.UI2.WinForms.Guna2DataGridView datagridDSHV;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxCurDay;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxNgDG;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxXepLoai;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxSum;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxDiemHT;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxDiemLS;
        private Guna.UI2.WinForms.Guna2TextBox txtboxDiemKL;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxTen;
        private Guna.UI2.WinForms.Guna2TextBox txtboxMaHV;
        private Guna.UI2.WinForms.Guna2TextBox txtBox_NhanXet;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
