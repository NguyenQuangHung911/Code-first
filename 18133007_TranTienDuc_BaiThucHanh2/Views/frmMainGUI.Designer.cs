namespace Taskmanagement.Views
{
    partial class frmMainGUI
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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnsFunction = new System.Windows.Forms.ToolStripMenuItem();
            this.msnTaskManager = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tctTabMain = new System.Windows.Forms.TabControl();
            this.testDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnsFunction,
            this.testDBToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(843, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnsFunction
            // 
            this.mnsFunction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msnTaskManager,
            this.mnsUser});
            this.mnsFunction.Name = "mnsFunction";
            this.mnsFunction.Size = new System.Drawing.Size(93, 24);
            this.mnsFunction.Text = "&Chức năng";
            // 
            // msnTaskManager
            // 
            this.msnTaskManager.Name = "msnTaskManager";
            this.msnTaskManager.Size = new System.Drawing.Size(223, 26);
            this.msnTaskManager.Text = "&Quản lý sự kiện";
            this.msnTaskManager.Click += new System.EventHandler(this.msnTaskManager_Click);
            // 
            // mnsUser
            // 
            this.mnsUser.Name = "mnsUser";
            this.mnsUser.Size = new System.Drawing.Size(223, 26);
            this.mnsUser.Text = "&Quản lý người dùng";
            this.mnsUser.Click += new System.EventHandler(this.mnsUser_Click);
            // 
            // tctTabMain
            // 
            this.tctTabMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tctTabMain.Location = new System.Drawing.Point(0, 28);
            this.tctTabMain.Name = "tctTabMain";
            this.tctTabMain.SelectedIndex = 0;
            this.tctTabMain.Size = new System.Drawing.Size(843, 34);
            this.tctTabMain.TabIndex = 5;
            this.tctTabMain.SelectedIndexChanged += new System.EventHandler(this.tctTabMain_SelectedIndexChanged);
            // 
            // testDBToolStripMenuItem
            // 
            this.testDBToolStripMenuItem.Name = "testDBToolStripMenuItem";
            this.testDBToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.testDBToolStripMenuItem.Text = "testDB";
            this.testDBToolStripMenuItem.Click += new System.EventHandler(this.testDBToolStripMenuItem_Click);
            // 
            // frmMainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 558);
            this.Controls.Add(this.tctTabMain);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMainGUI";
            this.Text = "frmMainGUI";
            this.MdiChildActivate += new System.EventHandler(this.frmMainGUI_MdiChildActivate);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnsFunction;
        private System.Windows.Forms.ToolStripMenuItem msnTaskManager;
        private System.Windows.Forms.ToolStripMenuItem mnsUser;
        private System.Windows.Forms.TabControl tctTabMain;
        private System.Windows.Forms.ToolStripMenuItem testDBToolStripMenuItem;
    }
}



