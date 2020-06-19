namespace Taskmanagement.Views
{
    partial class frmTaskManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaskManager));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnsFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsTaoSuKien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tslNextEvent = new System.Windows.Forms.ToolStripLabel();
            this.tspNote = new System.Windows.Forms.ToolStripProgressBar();
            this.tscTimeSpan = new System.Windows.Forms.ToolStripComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.lstSearchUsername = new System.Windows.Forms.ListBox();
            this.txtSearchUsername = new System.Windows.Forms.TextBox();
            this.btnDeleteEvent = new System.Windows.Forms.Button();
            this.btnUpdateEvent = new System.Windows.Forms.Button();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.dtpKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dtpBatDau = new System.Windows.Forms.DateTimePicker();
            this.rtbMoTa = new System.Windows.Forms.RichTextBox();
            this.txtTieuDe = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblKetThuc = new System.Windows.Forms.Label();
            this.lblBatDau = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lstEvent = new System.Windows.Forms.ListView();
            this.clmID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmBatDau = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmKetThuc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmMoTa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.ptbDraw = new System.Windows.Forms.PictureBox();
            this.btnTaoNoteMoi = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tmrNote = new System.Windows.Forms.Timer(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDraw)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1073, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnsFile
            // 
            this.mnsFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsTaoSuKien,
            this.mnsThoat});
            this.mnsFile.Name = "mnsFile";
            this.mnsFile.Size = new System.Drawing.Size(46, 24);
            this.mnsFile.Text = "File";
            // 
            // mnsTaoSuKien
            // 
            this.mnsTaoSuKien.Name = "mnsTaoSuKien";
            this.mnsTaoSuKien.Size = new System.Drawing.Size(167, 26);
            this.mnsTaoSuKien.Text = "Tạo sự kiện";
            this.mnsTaoSuKien.Click += new System.EventHandler(this.mnsTaoSuKien_Click);
            // 
            // mnsThoat
            // 
            this.mnsThoat.Name = "mnsThoat";
            this.mnsThoat.Size = new System.Drawing.Size(167, 26);
            this.mnsThoat.Text = "Thoát";
            this.mnsThoat.Click += new System.EventHandler(this.mnsThoat_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1073, 492);
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 31);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(1073, 550);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslNextEvent,
            this.tspNote,
            this.tscTimeSpan});
            this.toolStrip2.Location = new System.Drawing.Point(4, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(433, 31);
            this.toolStrip2.TabIndex = 0;
            // 
            // tslNextEvent
            // 
            this.tslNextEvent.Name = "tslNextEvent";
            this.tslNextEvent.Size = new System.Drawing.Size(195, 28);
            this.tslNextEvent.Text = "Next Event: [Name of Event]";
            // 
            // tspNote
            // 
            this.tspNote.Name = "tspNote";
            this.tspNote.Size = new System.Drawing.Size(100, 28);
            // 
            // tscTimeSpan
            // 
            this.tscTimeSpan.Items.AddRange(new object[] {
            "Day",
            "Hour",
            "Minute"});
            this.tscTimeSpan.Name = "tscTimeSpan";
            this.tscTimeSpan.Size = new System.Drawing.Size(121, 31);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstUsers);
            this.splitContainer1.Panel1.Controls.Add(this.lstSearchUsername);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearchUsername);
            this.splitContainer1.Panel1.Controls.Add(this.btnDeleteEvent);
            this.splitContainer1.Panel1.Controls.Add(this.btnUpdateEvent);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddEvent);
            this.splitContainer1.Panel1.Controls.Add(this.dtpKetThuc);
            this.splitContainer1.Panel1.Controls.Add(this.dtpBatDau);
            this.splitContainer1.Panel1.Controls.Add(this.rtbMoTa);
            this.splitContainer1.Panel1.Controls.Add(this.txtTieuDe);
            this.splitContainer1.Panel1.Controls.Add(this.lblMoTa);
            this.splitContainer1.Panel1.Controls.Add(this.lblKetThuc);
            this.splitContainer1.Panel1.Controls.Add(this.lblBatDau);
            this.splitContainer1.Panel1.Controls.Add(this.lblTieuDe);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1073, 492);
            this.splitContainer1.SplitterDistance = 195;
            this.splitContainer1.TabIndex = 0;
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 16;
            this.lstUsers.Location = new System.Drawing.Point(772, 18);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(120, 84);
            this.lstUsers.TabIndex = 6;
            this.lstUsers.DoubleClick += new System.EventHandler(this.lstUsers_DoubleClick);
            // 
            // lstSearchUsername
            // 
            this.lstSearchUsername.FormattingEnabled = true;
            this.lstSearchUsername.ItemHeight = 16;
            this.lstSearchUsername.Location = new System.Drawing.Point(937, 46);
            this.lstSearchUsername.Name = "lstSearchUsername";
            this.lstSearchUsername.Size = new System.Drawing.Size(120, 84);
            this.lstSearchUsername.TabIndex = 6;
            this.lstSearchUsername.Visible = false;
            this.lstSearchUsername.DoubleClick += new System.EventHandler(this.lstSearchUsername_DoubleClick);
            // 
            // txtSearchUsername
            // 
            this.txtSearchUsername.Location = new System.Drawing.Point(937, 18);
            this.txtSearchUsername.Name = "txtSearchUsername";
            this.txtSearchUsername.Size = new System.Drawing.Size(124, 22);
            this.txtSearchUsername.TabIndex = 5;
            this.txtSearchUsername.TextChanged += new System.EventHandler(this.txtSearchUsername_TextChanged);
            // 
            // btnDeleteEvent
            // 
            this.btnDeleteEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteEvent.Location = new System.Drawing.Point(368, 138);
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.Size = new System.Drawing.Size(117, 34);
            this.btnDeleteEvent.TabIndex = 4;
            this.btnDeleteEvent.Text = "Xóa sự kiện";
            this.btnDeleteEvent.UseVisualStyleBackColor = true;
            this.btnDeleteEvent.Click += new System.EventHandler(this.btnDeleteEvent_Click);
            // 
            // btnUpdateEvent
            // 
            this.btnUpdateEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateEvent.Location = new System.Drawing.Point(230, 138);
            this.btnUpdateEvent.Name = "btnUpdateEvent";
            this.btnUpdateEvent.Size = new System.Drawing.Size(117, 34);
            this.btnUpdateEvent.TabIndex = 4;
            this.btnUpdateEvent.Text = "Sửa sự kiện";
            this.btnUpdateEvent.UseVisualStyleBackColor = true;
            this.btnUpdateEvent.Click += new System.EventHandler(this.btnUpdateEvent_Click);
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEvent.Location = new System.Drawing.Point(85, 138);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(117, 34);
            this.btnAddEvent.TabIndex = 4;
            this.btnAddEvent.Text = "Thêm sự kiện";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // dtpKetThuc
            // 
            this.dtpKetThuc.CustomFormat = "dd/MM/yyyy HH:mm:ss tt";
            this.dtpKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpKetThuc.Location = new System.Drawing.Point(485, 67);
            this.dtpKetThuc.Name = "dtpKetThuc";
            this.dtpKetThuc.Size = new System.Drawing.Size(261, 22);
            this.dtpKetThuc.TabIndex = 3;
            // 
            // dtpBatDau
            // 
            this.dtpBatDau.CustomFormat = "dd/MM/yyyy HH:mm:ss tt";
            this.dtpBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBatDau.Location = new System.Drawing.Point(485, 19);
            this.dtpBatDau.Name = "dtpBatDau";
            this.dtpBatDau.Size = new System.Drawing.Size(261, 22);
            this.dtpBatDau.TabIndex = 3;
            // 
            // rtbMoTa
            // 
            this.rtbMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMoTa.Location = new System.Drawing.Point(85, 72);
            this.rtbMoTa.Name = "rtbMoTa";
            this.rtbMoTa.Size = new System.Drawing.Size(262, 58);
            this.rtbMoTa.TabIndex = 2;
            this.rtbMoTa.Text = "";
            // 
            // txtTieuDe
            // 
            this.txtTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTieuDe.Location = new System.Drawing.Point(85, 18);
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.Size = new System.Drawing.Size(262, 22);
            this.txtTieuDe.TabIndex = 1;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.Location = new System.Drawing.Point(22, 72);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(43, 17);
            this.lblMoTa.TabIndex = 0;
            this.lblMoTa.Text = "Mô tả";
            // 
            // lblKetThuc
            // 
            this.lblKetThuc.AutoSize = true;
            this.lblKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKetThuc.Location = new System.Drawing.Point(403, 72);
            this.lblKetThuc.Name = "lblKetThuc";
            this.lblKetThuc.Size = new System.Drawing.Size(60, 17);
            this.lblKetThuc.TabIndex = 0;
            this.lblKetThuc.Text = "Kết thúc";
            // 
            // lblBatDau
            // 
            this.lblBatDau.AutoSize = true;
            this.lblBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatDau.Location = new System.Drawing.Point(403, 24);
            this.lblBatDau.Name = "lblBatDau";
            this.lblBatDau.Size = new System.Drawing.Size(57, 17);
            this.lblBatDau.TabIndex = 0;
            this.lblBatDau.Text = "Bắt đầu";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(22, 24);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(56, 17);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Tiêu đề";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lstEvent);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1073, 293);
            this.splitContainer2.SplitterDistance = 733;
            this.splitContainer2.TabIndex = 0;
            // 
            // lstEvent
            // 
            this.lstEvent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmID,
            this.clmTitle,
            this.clmBatDau,
            this.clmKetThuc,
            this.clmMoTa,
            this.clmUser});
            this.lstEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEvent.HideSelection = false;
            this.lstEvent.Location = new System.Drawing.Point(0, 0);
            this.lstEvent.Name = "lstEvent";
            this.lstEvent.Size = new System.Drawing.Size(733, 293);
            this.lstEvent.TabIndex = 0;
            this.lstEvent.UseCompatibleStateImageBehavior = false;
            this.lstEvent.View = System.Windows.Forms.View.Details;
            this.lstEvent.Click += new System.EventHandler(this.lstEvent_Click);
            // 
            // clmID
            // 
            this.clmID.Text = "ID";
            // 
            // clmTitle
            // 
            this.clmTitle.Text = "Tiêu đề";
            // 
            // clmBatDau
            // 
            this.clmBatDau.Text = "Bắt đầu";
            // 
            // clmKetThuc
            // 
            this.clmKetThuc.Text = "Kết Thúc";
            this.clmKetThuc.Width = 63;
            // 
            // clmMoTa
            // 
            this.clmMoTa.Text = "Mô tả";
            // 
            // clmUser
            // 
            this.clmUser.Text = "User";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.ptbDraw);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnTaoNoteMoi);
            this.splitContainer3.Size = new System.Drawing.Size(336, 293);
            this.splitContainer3.SplitterDistance = 225;
            this.splitContainer3.TabIndex = 0;
            // 
            // ptbDraw
            // 
            this.ptbDraw.BackColor = System.Drawing.Color.White;
            this.ptbDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbDraw.Location = new System.Drawing.Point(0, 0);
            this.ptbDraw.Name = "ptbDraw";
            this.ptbDraw.Size = new System.Drawing.Size(336, 225);
            this.ptbDraw.TabIndex = 0;
            this.ptbDraw.TabStop = false;
            this.ptbDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptbDraw_MouseDown);
            this.ptbDraw.MouseHover += new System.EventHandler(this.ptbDraw_MouseHover);
            this.ptbDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbDraw_MouseMove);
            this.ptbDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ptbDraw_MouseUp);
            this.ptbDraw.Resize += new System.EventHandler(this.ptbDraw_Resize);
            // 
            // btnTaoNoteMoi
            // 
            this.btnTaoNoteMoi.Location = new System.Drawing.Point(48, 15);
            this.btnTaoNoteMoi.Name = "btnTaoNoteMoi";
            this.btnTaoNoteMoi.Size = new System.Drawing.Size(243, 34);
            this.btnTaoNoteMoi.TabIndex = 4;
            this.btnTaoNoteMoi.Text = "Tạo Note mới";
            this.btnTaoNoteMoi.UseVisualStyleBackColor = true;
            this.btnTaoNoteMoi.Click += new System.EventHandler(this.btnTaoNoteMoi_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(4, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(42, 27);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // tmrNote
            // 
            this.tmrNote.Enabled = true;
            this.tmrNote.Interval = 1000;
            this.tmrNote.Tick += new System.EventHandler(this.tmrNote_Tick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmTaskManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 582);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmTaskManager";
            this.Text = "Chương trình quản lý sự kiện";
            this.Load += new System.EventHandler(this.frmTaskManager_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbDraw)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnsFile;
        private System.Windows.Forms.ToolStripMenuItem mnsTaoSuKien;
        private System.Windows.Forms.ToolStripMenuItem mnsThoat;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.RichTextBox rtbMoTa;
        private System.Windows.Forms.TextBox txtTieuDe;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblKetThuc;
        private System.Windows.Forms.Label lblBatDau;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.DateTimePicker dtpBatDau;
        private System.Windows.Forms.DateTimePicker dtpKetThuc;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.ListView lstEvent;
        private System.Windows.Forms.ColumnHeader clmID;
        private System.Windows.Forms.ColumnHeader clmTitle;
        private System.Windows.Forms.ColumnHeader clmBatDau;
        private System.Windows.Forms.ColumnHeader clmKetThuc;
        private System.Windows.Forms.ColumnHeader clmMoTa;
        private System.Windows.Forms.PictureBox ptbDraw;
        private System.Windows.Forms.Button btnTaoNoteMoi;
        private System.Windows.Forms.Button btnUpdateEvent;
        private System.Windows.Forms.Button btnDeleteEvent;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel tslNextEvent;
        private System.Windows.Forms.ToolStripProgressBar tspNote;
        private System.Windows.Forms.ToolStripComboBox tscTimeSpan;
        private System.Windows.Forms.Timer tmrNote;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.ListBox lstSearchUsername;
        private System.Windows.Forms.TextBox txtSearchUsername;
        private System.Windows.Forms.ColumnHeader clmUser;
    }
}

