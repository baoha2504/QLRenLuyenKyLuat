namespace QLRenLuyenKyLuat.GUI_HV
{
    partial class frmHocVien
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
            this.components = new System.ComponentModel.Container();
            this.mainContainer = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.aceTrangChu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_TuDanhGia = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_KQKL = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_KQKL_Thang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_KQKL_Ky = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_KQKL_Nam = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_KQTL = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_KQTL_Quy = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_KQTL_Nam = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_HDSD = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement13 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement14 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ace_TK = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement15 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement16 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.time = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.position = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.name = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem5 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem6 = new DevExpress.XtraBars.BarStaticItem();
            this.lblTieuDe = new DevExpress.XtraBars.BarStaticItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(334, 35);
            this.mainContainer.Margin = new System.Windows.Forms.Padding(4);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(958, 702);
            this.mainContainer.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceTrangChu,
            this.ace_TuDanhGia,
            this.ace_KQKL,
            this.ace_KQTL,
            this.ace_HDSD,
            this.ace_TK});
            this.accordionControl1.Location = new System.Drawing.Point(0, 35);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(4);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(334, 702);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // aceTrangChu
            // 
            this.aceTrangChu.Expanded = true;
            this.aceTrangChu.Name = "aceTrangChu";
            this.aceTrangChu.Text = "Trang chủ";
            this.aceTrangChu.Click += new System.EventHandler(this.aceTrangChu_Click);
            // 
            // ace_TuDanhGia
            // 
            this.ace_TuDanhGia.Expanded = true;
            this.ace_TuDanhGia.Name = "ace_TuDanhGia";
            this.ace_TuDanhGia.Text = "Tự đánh giá";
            this.ace_TuDanhGia.Click += new System.EventHandler(this.ace_TuDanhGia_Click);
            // 
            // ace_KQKL
            // 
            this.ace_KQKL.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ace_KQKL_Thang,
            this.ace_KQKL_Ky,
            this.ace_KQKL_Nam});
            this.ace_KQKL.Expanded = true;
            this.ace_KQKL.Name = "ace_KQKL";
            this.ace_KQKL.Text = "Kết quả kỷ luật";
            // 
            // ace_KQKL_Thang
            // 
            this.ace_KQKL_Thang.Name = "ace_KQKL_Thang";
            this.ace_KQKL_Thang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ace_KQKL_Thang.Text = "Kết quả kỷ luật tháng";
            this.ace_KQKL_Thang.Click += new System.EventHandler(this.ace_KQKL_Thang_Click);
            // 
            // ace_KQKL_Ky
            // 
            this.ace_KQKL_Ky.Name = "ace_KQKL_Ky";
            this.ace_KQKL_Ky.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ace_KQKL_Ky.Text = "Kết quả kỷ luật học kỳ";
            this.ace_KQKL_Ky.Click += new System.EventHandler(this.ace_KQKL_Ky_Click);
            // 
            // ace_KQKL_Nam
            // 
            this.ace_KQKL_Nam.Name = "ace_KQKL_Nam";
            this.ace_KQKL_Nam.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ace_KQKL_Nam.Text = "Kết quả kỷ luật năm";
            this.ace_KQKL_Nam.Click += new System.EventHandler(this.ace_KQKL_Nam_Click);
            // 
            // ace_KQTL
            // 
            this.ace_KQTL.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ace_KQTL_Quy,
            this.ace_KQTL_Nam});
            this.ace_KQTL.Expanded = true;
            this.ace_KQTL.Name = "ace_KQTL";
            this.ace_KQTL.Text = "Kết quả thể lực";
            // 
            // ace_KQTL_Quy
            // 
            this.ace_KQTL_Quy.Name = "ace_KQTL_Quy";
            this.ace_KQTL_Quy.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ace_KQTL_Quy.Text = "Kết quả thể lực qúy";
            this.ace_KQTL_Quy.Click += new System.EventHandler(this.ace_KQTL_Quy_Click);
            // 
            // ace_KQTL_Nam
            // 
            this.ace_KQTL_Nam.Name = "ace_KQTL_Nam";
            this.ace_KQTL_Nam.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ace_KQTL_Nam.Text = "Kết quả thể lực năm";
            this.ace_KQTL_Nam.Click += new System.EventHandler(this.ace_KQTL_Nam_Click);
            // 
            // ace_HDSD
            // 
            this.ace_HDSD.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement13,
            this.accordionControlElement14});
            this.ace_HDSD.Expanded = true;
            this.ace_HDSD.Name = "ace_HDSD";
            this.ace_HDSD.Text = "Hướng dẫn sử dụng";
            // 
            // accordionControlElement13
            // 
            this.accordionControlElement13.Name = "accordionControlElement13";
            this.accordionControlElement13.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement13.Text = "Chức năng quản lý kỷ luât";
            // 
            // accordionControlElement14
            // 
            this.accordionControlElement14.Name = "accordionControlElement14";
            this.accordionControlElement14.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement14.Text = "Chức năng quản lý thể lực";
            // 
            // ace_TK
            // 
            this.ace_TK.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement15,
            this.accordionControlElement16});
            this.ace_TK.Expanded = true;
            this.ace_TK.Name = "ace_TK";
            this.ace_TK.Text = "Tài khoản";
            // 
            // accordionControlElement15
            // 
            this.accordionControlElement15.Name = "accordionControlElement15";
            this.accordionControlElement15.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement15.Text = "Thay đổi mật khẩu";
            // 
            // accordionControlElement16
            // 
            this.accordionControlElement16.Name = "accordionControlElement16";
            this.accordionControlElement16.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement16.Text = "Đăng xuất";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.time,
            this.barStaticItem1,
            this.position,
            this.barStaticItem3,
            this.name,
            this.barStaticItem5,
            this.barStaticItem6,
            this.lblTieuDe});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(4);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1292, 35);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.time);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barStaticItem1);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.position);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barStaticItem3);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.name);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barStaticItem5);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.barStaticItem6);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.lblTieuDe);
            this.fluentDesignFormControl1.Click += new System.EventHandler(this.fluentDesignFormControl1_Click);
            // 
            // time
            // 
            this.time.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.time.Caption = "time";
            this.time.Id = 0;
            this.time.Name = "time";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem1.Caption = "Thời gian:";
            this.barStaticItem1.Id = 1;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // position
            // 
            this.position.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.position.Caption = "position";
            this.position.Id = 2;
            this.position.Name = "position";
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem3.Caption = "Chức vụ:";
            this.barStaticItem3.Id = 3;
            this.barStaticItem3.Name = "barStaticItem3";
            // 
            // name
            // 
            this.name.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.name.Caption = "name";
            this.name.Id = 4;
            this.name.Name = "name";
            // 
            // barStaticItem5
            // 
            this.barStaticItem5.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem5.Caption = "Họ tên:";
            this.barStaticItem5.Id = 5;
            this.barStaticItem5.Name = "barStaticItem5";
            // 
            // barStaticItem6
            // 
            this.barStaticItem6.Caption = "barStaticItem6";
            this.barStaticItem6.Id = 6;
            this.barStaticItem6.Name = "barStaticItem6";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Caption = "TieuDe";
            this.lblTieuDe.Id = 7;
            this.lblTieuDe.Name = "lblTieuDe";
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.time,
            this.barStaticItem1,
            this.position,
            this.barStaticItem3,
            this.name,
            this.barStaticItem5,
            this.barStaticItem6,
            this.lblTieuDe});
            this.fluentFormDefaultManager1.MaxItemId = 8;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Element1";
            this.accordionControlElement1.Click += new System.EventHandler(this.accordionControlElement1_Click);
            // 
            // frmHocVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 737);
            this.ControlContainer = this.mainContainer;
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHocVien";
            this.NavigationControl = this.accordionControl1;
            this.Text = "frmHocVien";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHocVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer mainContainer;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceTrangChu;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_TuDanhGia;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_KQKL;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_KQTL;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_HDSD;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_TK;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_KQKL_Thang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_KQKL_Ky;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_KQKL_Nam;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_KQTL_Quy;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement13;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement14;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement15;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement16;
        private DevExpress.XtraBars.BarStaticItem time;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem position;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarStaticItem name;
        private DevExpress.XtraBars.BarStaticItem barStaticItem5;
        private DevExpress.XtraBars.BarStaticItem barStaticItem6;
        private DevExpress.XtraBars.BarStaticItem lblTieuDe;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ace_KQTL_Nam;
    }
}