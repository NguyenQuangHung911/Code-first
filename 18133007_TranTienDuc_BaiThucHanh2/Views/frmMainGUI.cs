/*Họ và tên: Trần Tiến Đức
MSSV: 18133007
Ngày sinh: 29/07/2000
Công dụng: Hoàn thiện project quản lý công việc có kết nối cơ sở dữ liệu (Sử dụng mô hình Code-first) 
Ngày viết: 23/05/2020
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Taskmanagement.Models;
using Taskmanagement.Controllers;

namespace Taskmanagement.Views
{
    public partial class frmMainGUI : Form
    {
        #region Danh sách biến
        //private int childFormNumber = 0;
        frmTaskManager formTaskManager;
        frmUser formUser;
        List<User> listUsers;
        List<TaskWork> listTasks;
        #endregion
        #region Hàm khởi tạo frmMainGUI
        public frmMainGUI()
        {
            InitializeComponent();
            listUsers = new List<User>();
            listTasks = new List<TaskWork>();
        }
        #endregion
        #region Hàm đọc dữ liệu
        //private void LoadFromFile(string path)
        //{
        //    int lineCount = 0;
        //    using (var reader = File.OpenText(path))
        //    {
        //        while (reader.ReadLine() != null)
        //        {
        //            lineCount++;
        //        }
        //    }
        //    #region Nếu tồn tại dữ liệu
        //    if (lineCount > 0)
        //    {
        //        ID = lineCount;
        //        List<string> lines = File.ReadAllLines(path).ToList();
        //        for (int i = 0; i < lineCount; i++)
        //        {
        //            string temp = lines[i];
        //            string[] displayListTasks = temp.Split(',');
        //            ClassTask tempTask = new ClassTask();
        //            tempTask.ID = int.Parse(displayListTasks[0]);
        //            tempTask.title = displayListTasks[1];
        //            tempTask.fromDate = DateTime.Parse(displayListTasks[2]);
        //            tempTask.toDate = DateTime.Parse(displayListTasks[3]);
        //            tempTask.description = displayListTasks[4];
        //            tempTask.listUser = new List<User>();
        //            string[] displayListUsers = displayListTasks[5].Split();
        //            for (int j = 0; j < displayListUsers.Count(); j++)
        //            {
        //                var user = listUsers.FirstOrDefault(x => x.username == displayListUsers[j]);
        //                tempTask.listUser.Add(user as User);
        //            }
        //            listTasks.Add(tempTask);
        //        }
        //    }
        //    #endregion
        //    else
        //        return;
        //}
        #endregion
        #region Hàm lưu file
        private void SaveToFile(string path)
        {
            #region Lưu có hỏi đường dẫn lưu file (Đã thành comment)
            //string fileName = "";
            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Title = "Export to file";
            //sfd.Filter = "Text File (.txt) | *.txt";
            //if(sfd.ShowDialog()==DialogResult.OK)
            //{
            //    fileName = sfd.FileName.ToString();
            //    if (fileName != "")
            //    {
            //        using(StreamWriter sw=new StreamWriter(fileName))
            //        {
            //            foreach(ListViewItem item in this.lstEvent.Items)
            //            {
            //                for (int i = 0; i < 6; i++)
            //                {
            //                    sw.Write("{0}\t", item.SubItems[i].Text);
            //                }
            //                sw.WriteLine();
            //            }
            //        }
            //    }
            //}
            #endregion
            #region Lưu ở thư mục đã được chỉ định sẵn
            using (FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                lock (fs)
                {
                    fs.SetLength(0);
                    fs.Close();
                }
            }
            //using(FileStream fs=File.Open(path,FileMode.Truncate,FileAccess.ReadWrite,FileShare.None))
            //{
            //    fs.Close();
            //}
            //File.WriteAllText(path, String.Empty);
            int len = this.listTasks.Count();
            if (len > 0)
            {
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    //foreach (ListViewItem item in this.lstEvent.Items)
                    //{
                    //    for (int i = 0; i < 6; i++)
                    //    {
                    //        sw.Write("{0}\t", item.SubItems[i].Text);
                    //    }
                    //    sw.WriteLine();
                    //}
                    //foreach (ClassTask task in this.listTasks)
                    //{
                    //    sw.WriteLine(task.ToString());
                    //}
                    for (int i = 0; i < len - 1; i++)
                    {
                        sw.WriteLine(this.listTasks[i].ToString());
                    }
                    sw.Write(this.listTasks[len - 1].ToString());
                    sw.Close();
                }
            }
            else
                return;
            #endregion
        }
        #endregion
        #region Hàm xử lý sự kiện cho MenuStrip
        private void msnTaskManager_Click(object sender, EventArgs e)
        {
            if(this.formTaskManager is null || this.formTaskManager.IsDisposed)
            {
                this.formTaskManager = new frmTaskManager(ref listTasks, listUsers);
                this.formTaskManager.MdiParent = this;
                this.formTaskManager.Show();
            }
            else
            {
                this.formTaskManager.Select();
            }
        }

        private void mnsUser_Click(object sender, EventArgs e)
        {
            if (this.formUser is null || this.formUser.IsDisposed)
            {
                this.formUser = new frmUser(ref listUsers);
                this.formUser.MdiParent = this;
                this.formUser.Show();
            }
            else
            {
                this.formUser.Select();
            }
        }
        #endregion
        #region Hàm xử lý sự kiện cho MDI Form và MDI Child Form
        private void frmMainGUI_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                return;
            }
            this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
            if (this.ActiveMdiChild.Tag == null)
            {
                TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                tp.Tag = this.ActiveMdiChild;
                tp.Parent = this.tctTabMain;
                this.tctTabMain.SelectedTab = tp;
                this.ActiveMdiChild.Tag = tp;
                this.ActiveMdiChild.FormClosed += ActiveMdiChild_FormClosed;
            }
        }

        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }

        private void tctTabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tctTabMain.SelectedTab != null && this.tctTabMain.SelectedTab.Tag != null)
            {
                (this.tctTabMain.SelectedTab.Tag as Form).Select();
            }
        }
        #endregion
        #region Khởi tạo cơ sở dữ liệu thông qua sự kiện click trên menuStrip
        private void testDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbTestController.initializeDB();
        }
        #endregion
    }
}
