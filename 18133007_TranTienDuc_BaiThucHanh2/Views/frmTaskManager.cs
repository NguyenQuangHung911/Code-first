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
    public partial class frmTaskManager : Form
    {
        #region Danh sách biến
        private int ID;
        private DrawNote drawNote;
        private Graphics graphics = null;
        private List<TaskWork> listTasks;
        private List<User> listUsers;
        //private PictureBox picSelected = null;
        #endregion
        #region Các sự kiện của form frmTaskManager
        #region Hàm khởi tạo frmTaskManager với tham số lisktasks (kiểu List<ClassTask>) và users (List<User>)
        public frmTaskManager(ref List<TaskWork> listtasks, List<User> users)
        {
            //listTasks = listtasks;
            //listUsers = users;
            InitializeComponent();
            //ID = 0;
            DisplayTask();
            //this.ptbDraw.Image = Properties.Resources.blank;
            #region Đổ dữ liệu từ listTasks vào để hiển thị lại nội dung
            //int lenTask = listTasks.Count();
            //if (lenTask > 0)
            //{
            //    foreach (TaskWork task in listTasks)
            //    {
            //        string tempUser = "";
            //        int lenUser = task.listUser.Count();
            //        for (int i = 0; i < lenUser - 1; i++)
            //        {
            //            tempUser += task.listUser.ToList()[i].ToString() + " ";
            //        }
            //        tempUser += task.listUser.ToList()[lenUser - 1].ToString();
            //        //if (true)
            //        //{
            //        var item = new ListViewItem(new[] {task.ID.ToString(),
            //                task.title,
            //                task.fromDate.ToString(),
            //                task.toDate.ToString(),
            //                task.description,
            //                tempUser });
            //        lstEvent.Items.Add(item);
            //        //}                    
            //    }
            //}
            #endregion
        }
        #endregion
        #region Load form frmTaskManager
        private void frmTaskManager_Load(object sender, EventArgs e)
        {
            //ID = 1;
            drawNote = new DrawNote();
            #region Set help provider
            this.helpProvider1.SetShowHelp(this.txtTieuDe, true);
            this.helpProvider1.SetHelpString(this.txtTieuDe, "Đây là nơi nhập tiêu đề");
            this.helpProvider1.SetShowHelp(this.rtbMoTa, true);
            this.helpProvider1.SetHelpString(this.rtbMoTa, "Đây là nơi nhập mô tả");
            this.helpProvider1.SetShowHelp(this.dtpBatDau, true);
            this.helpProvider1.SetHelpString(this.dtpBatDau, "Đây là nơi chọn thời điểm bắt" +
                " đầu 1 sự kiện");
            this.helpProvider1.SetShowHelp(this.dtpKetThuc, true);
            this.helpProvider1.SetHelpString(this.dtpKetThuc, "Đây là nơi chọn thời điểm kết" +
                " thúc 1 sự kiện");
            this.helpProvider1.SetShowHelp(this.txtSearchUsername, true);
            this.helpProvider1.SetHelpString(this.txtSearchUsername, "Bạn cần nhập username bạn muốn thêm vào danh sách " +
                "công việc");
            this.helpProvider1.SetShowHelp(this.lstUsers, true);
            this.helpProvider1.SetHelpString(this.lstUsers, "Đây là danh sách user bạn đã nhập vào");
            #endregion
        }
        #endregion
        #endregion
        private void DisplayTask()
        {
            List<TaskWork> lstTask = TaskController.GetAllTasks();
            this.lstEvent.Items.Clear();
            foreach (TaskWork task in lstTask)
            {               
                ListViewItem eVent = new ListViewItem(task.ID.ToString());
                eVent.SubItems.Add(new ListViewItem.ListViewSubItem(eVent, task.title));
                eVent.SubItems.Add(new ListViewItem.ListViewSubItem(eVent, task.fromDate.ToString()));
                eVent.SubItems.Add(new ListViewItem.ListViewSubItem(eVent, task.toDate.ToString()));
                eVent.SubItems.Add(new ListViewItem.ListViewSubItem(eVent, task.description));
                string displayUsers = "";
                foreach (User u in task.listUser)
                {
                    displayUsers += u + " ";
                }
                eVent.SubItems.Add(new ListViewItem.ListViewSubItem(eVent, displayUsers));
                this.lstEvent.Items.Add(eVent);
            }
        }
        #region Xử lý sự kiện click cho danh sách sự kiện
        private void lstEvent_Click(object sender, EventArgs e)
        {
            #region Hiển thị cho các control ở trên
            this.txtTieuDe.Text = this.lstEvent.SelectedItems[0].SubItems[1].Text.Trim();
            this.dtpBatDau.Value = DateTime.Parse(this.lstEvent.SelectedItems[0].SubItems[2].Text.Trim());
            this.dtpKetThuc.Value = DateTime.Parse(this.lstEvent.SelectedItems[0].SubItems[3].Text.Trim());
            this.rtbMoTa.Text = this.lstEvent.SelectedItems[0].SubItems[4].Text.Trim();
            #endregion
            #region Hiển thị ảnh theo ID ở hàng được chọn
            using (FileStream stream = new FileStream(String.Format("{0}.jpg",
                this.lstEvent.SelectedItems[0].SubItems[0].Text.Trim()), FileMode.Open, FileAccess.Read))
            {
                ptbDraw.Image = Image.FromStream(stream);
            }
            #endregion
            #region Hiển thị danh sách người dùng trong lstUsers
            this.lstUsers.Items.Clear();
            //string displayUsers = this.lstEvent.SelectedItems[0].SubItems[5].Text.Trim();
            //string[] displayForList = displayUsers.Split();
            //for (int i = 0; i < displayForList.Count(); i++)
            //{
            //    //var user = listUsers.FirstOrDefault(x => x.username == displayForList[i]);

            //    this.lstUsers.Items.Add(user as User);
            //}
            List<TaskWork> taskWorks = TaskController.GetAllTasks();
            TaskWork task = taskWorks.Where(x => x.ID == int.Parse(this.lstEvent.SelectedItems[0].SubItems[0].Text)).Single();
            foreach (var user in task.listUser)
            {
                this.lstUsers.Items.Add(user as User);
            }
            #endregion
        }
        #endregion
        #region Xử lý sự kiện cho các nút bấm của frmTaskManager
        #region Tạo sự kiện mới
        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            //Lưu note                        
                #region Set Error Provider
                if (this.txtTieuDe.Text.Trim().Length <= 0)
                {
                    this.errorProvider1.SetError(this.txtTieuDe, "Yêu cầu nhập tiêu đề!");
                    return;
                }
                if (this.rtbMoTa.Text.Trim().Length <= 0)
                {
                    this.errorProvider1.SetError(this.rtbMoTa, "Yêu cầu nhập mô tả!");
                    return;
                }
                if (DateTime.Compare(this.dtpBatDau.Value, DateTime.Now) <= 0)
                {
                    this.errorProvider1.SetError(this.dtpBatDau, "Yêu cầu chỉnh lại thời điểm bắt đầu sau " +
                        "thời điểm hiện tại của hệ thống!");
                    return;
                }
                if (DateTime.Compare(this.dtpKetThuc.Value, this.dtpBatDau.Value) <= 0)
                {
                    this.errorProvider1.SetError(this.dtpKetThuc, "Yêu cầu chỉnh lại thời điểm kết thúc sau " +
                        "thời điểm bắt đầu sự kiện!");
                    return;
                }
                if(this.lstUsers.Items.Count ==0)
                {
                    this.errorProvider1.SetError(this.lstUsers, "Yêu cầu gán ít nhất 1 người dùng trong danh sách để thiết lập " +
                        "sự kiện!");
                    return;
                }
                errorProvider1.Clear();
            #endregion
            #region Gán dữ liệu sự kiện vào danh sách kiểu ClassTask
            TaskWork task = new TaskWork();
            //if (this.listTasks.Count() > 0)
            //    this.ID = this.listTasks[listTasks.Count() - 1].ID + 1;
            this.ID = TaskController.GetIDFromDB();
            //this.ID = this.listTasks.Count() + 1;
            task.ID = this.ID;
            task.title = this.txtTieuDe.Text.Trim();
            task.description = this.rtbMoTa.Text.Trim();
            task.fromDate = this.dtpBatDau.Value;
            task.toDate = this.dtpKetThuc.Value;
            //task.listUser = new List<User>();
            task.listUser = new List<User>();
            string displayUsers = "";
            for (int i = 0; i < this.lstUsers.Items.Count; i++)
            {               
                displayUsers = displayUsers + this.lstUsers.Items[i] + " ";
                task.listUser.Add(this.lstUsers.Items[i] as User);
            }
            //this.listTasks.Add(task);
            #endregion
            //Lưu dữ liệu vào database
            if (TaskController.AddTask(task) == false)
            { 
                MessageBox.Show("Can not add this task!", "Error");
            }
            #region Hiển thị sự kiện trên lstEvent
            //ListViewItem eVent = new ListViewItem(this.ID.ToString());
            //eVent.SubItems.Add(new ListViewItem.ListViewSubItem(eVent, this.txtTieuDe.Text));
            //eVent.SubItems.Add(new ListViewItem.ListViewSubItem(eVent, this.dtpBatDau.Value.ToString()));
            //eVent.SubItems.Add(new ListViewItem.ListViewSubItem(eVent, this.dtpKetThuc.Value.ToString()));
            //eVent.SubItems.Add(new ListViewItem.ListViewSubItem(eVent, this.rtbMoTa.Text));
            //eVent.SubItems.Add(new ListViewItem.ListViewSubItem(eVent, displayUsers));
            //this.lstEvent.Items.Add(eVent);
            DisplayTask();
            #endregion
            #region Lưu hình vẽ
            Bitmap bm = new Bitmap(this.ptbDraw.ClientSize.Width, this.ptbDraw.ClientSize.Height);
            this.ptbDraw.DrawToBitmap(bm, this.ptbDraw.ClientRectangle);
            bm.Save(String.Format("{0}.jpg", this.ID));
            this.ptbDraw.CreateGraphics().Clear(Color.White);
            //ptbDraw.Image.Save(String.Format("{0}.jpg", this.ID), System.Drawing.Imaging.ImageFormat.Jpeg);
            //graphics.Clear(ptbDraw.BackColor);
            graphics = null;
            #endregion
            this.ID++;
            //}           
        }
        #endregion
        #region Tạo Note mới
        private void btnTaoNoteMoi_Click(object sender, EventArgs e)
        {
            this.ptbDraw.CreateGraphics().Clear(this.ptbDraw.BackColor);
            //graphics.Clear(ptbDraw.BackColor);
            graphics = null;
        }
        #endregion
        #region Cập nhật (Thay đổi) sự kiện
        private void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            if (this.lstEvent.SelectedItems.Count > 0)
            {
                #region Set error provider
                if (this.txtTieuDe.Text.Trim().Length <= 0)
                {
                    this.errorProvider1.SetError(this.txtTieuDe, "Yêu cầu nhập tiêu đề!");
                    return;
                }
                if (this.rtbMoTa.Text.Trim().Length <= 0)
                {
                    this.errorProvider1.SetError(this.rtbMoTa, "Yêu cầu nhập mô tả!");
                    return;
                }
                if (DateTime.Compare(this.dtpBatDau.Value, DateTime.Now) <= 0)
                {
                    this.errorProvider1.SetError(this.dtpBatDau, "Yêu cầu chỉnh lại thời điểm bắt đầu sau " +
                        "thời điểm hiện tại của hệ thống!");
                    return;
                }
                if (DateTime.Compare(this.dtpKetThuc.Value, this.dtpBatDau.Value) <= 0)
                {
                    this.errorProvider1.SetError(this.dtpKetThuc, "Yêu cầu chỉnh lại thời điểm kết thúc sau " +
                        "thời điểm bắt đầu sự kiện!");
                    return;
                }
                if (this.lstUsers.Items.Count == 0)
                {
                    this.errorProvider1.SetError(this.lstUsers, "Yêu cầu gán ít nhất 1 người dùng trong danh sách để thiết lập " +
                        "sự kiện!");
                    return;
                }
                errorProvider1.Clear();
                #endregion
                #region Update user và sự kiện trong listTasks
                //int taskIndex = listTasks.FindIndex(x => x.ID == int.Parse(this.lstEvent.SelectedItems[0].SubItems[0].Text.Trim()));
                //this.listTasks[taskIndex].ID = this.ID;
                //this.listTasks[taskIndex].title = this.txtTieuDe.Text.Trim();
                //this.listTasks[taskIndex].description = this.rtbMoTa.Text.Trim();
                //this.listTasks[taskIndex].fromDate = this.dtpBatDau.Value;
                //this.listTasks[taskIndex].toDate = this.dtpKetThuc.Value;
                //this.listTasks[taskIndex].listUser.Clear();
                #region Update cho list kiểu TaskWork từ database
                List<TaskWork> taskWorks = TaskController.GetAllTasks();
                TaskWork task = taskWorks.Where(x => x.ID == int.Parse(this.lstEvent.SelectedItems[0].SubItems[0].Text)).Single();
                task.title = this.txtTieuDe.Text.Trim();
                task.description = this.rtbMoTa.Text.Trim();
                task.fromDate = this.dtpBatDau.Value;
                task.toDate = this.dtpKetThuc.Value;
                task.listUser.Clear();
                string displayUsers = "";
                for (int i = 0; i < this.lstUsers.Items.Count; i++)
                {
                    displayUsers = displayUsers + this.lstUsers.Items[i] + " ";
                    //this.listTasks[taskIndex].listUser.Add(this.lstUsers.Items[i] as User);                   
                    task.listUser.ToList().Add(this.lstUsers.Items[i] as User);
                }
                if (TaskController.UpdateTask(task) is false)
                {
                    MessageBox.Show("Can not update this event!", "Error");
                }
                #endregion
                #endregion
                #region Hiển thị trong lstEvent
                //this.lstEvent.SelectedItems[0].SubItems[1].Text = this.txtTieuDe.Text.Trim();
                //this.lstEvent.SelectedItems[0].SubItems[2].Text = this.dtpBatDau.Value.ToString();
                //this.lstEvent.SelectedItems[0].SubItems[3].Text = this.dtpKetThuc.Value.ToString();
                //this.lstEvent.SelectedItems[0].SubItems[4].Text = this.rtbMoTa.Text.Trim();
                //this.lstEvent.SelectedItems[0].SubItems[5].Text = displayUsers;
                DisplayTask();
                #endregion
                //Lưu note
                //this.ID += 1;
                //graphics.Clear(this.ptbDraw.BackColor);
                Bitmap bm = new Bitmap(this.ptbDraw.ClientSize.Width, this.ptbDraw.ClientSize.Height);
                this.ptbDraw.DrawToBitmap(bm, this.ptbDraw.ClientRectangle);
                //bm.Save(String.Format("{0}.jpg", this.lstEvent.SelectedItems[0].SubItems[0].Text.Trim()));
                this.ptbDraw.CreateGraphics().Clear(Color.White);
                graphics = null;
                //this.lstEvent.Update();
            }            
        }
        #endregion
        #region Xóa sự kiện
        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            //int index = this.listTasks.FindIndex(x => x.ID == int.Parse(this.lstEvent.SelectedItems[0].SubItems[0].Text));
            //this.listTasks.RemoveAt(index);
            //this.lstEvent.SelectedItems[0].Remove();
            List<TaskWork> taskWorks = TaskController.GetAllTasks();
            TaskWork task = taskWorks.Where(x => x.ID == int.Parse(this.lstEvent.SelectedItems[0].SubItems[0].Text)).Single();
            if(TaskController.DeleteTask(task) is false)
            {
                MessageBox.Show("Can not delete this event!", "Error");
            }
            DisplayTask();
        }
        #endregion
        #endregion        
        #region Các hàm xử lý sự kiện cho ptbDraw (Nơi vẽ)
        #region Hàm xử lý thả chuột trái
        private void ptbDraw_MouseUp(object sender, MouseEventArgs e)
        {
            drawNote.isDrawn = false;
        }
        #endregion
        #region Hàm xử lý nhấn chuột trái
        private void ptbDraw_MouseDown(object sender, MouseEventArgs e)
        {
            drawNote.isDrawn = true;
            drawNote.X = e.X;
            drawNote.Y = e.Y;
        }
        #endregion
        #region Hàm xử lý sự kiện di chuột để vẽ
        private void ptbDraw_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawNote.isDrawn) //Cờ vẽ được bật
            {
                if (graphics == null) //Nếu đối tượng graphics bị null
                {
                    graphics = this.ptbDraw.CreateGraphics();
                    Bitmap bmp = new Bitmap(ptbDraw.ClientSize.Width, ptbDraw.ClientSize.Height);
                    this.ptbDraw.Image = bmp;
                    graphics = Graphics.FromImage(bmp);
                    graphics.Clear(Color.White);
                }

                graphics.DrawLine(drawNote.pen, drawNote.X, drawNote.Y, e.X, e.Y);

                graphics.Flush();
                graphics.Save();
                this.ptbDraw.Refresh();

                drawNote.X = e.X;
                drawNote.Y = e.Y;
            }
        }
        #endregion
        #region Hàm xử lý sự kiện chỉnh kích thước khung vẽ
        private void ptbDraw_Resize(object sender, EventArgs e)
        {
            //Trường hợp 1: Nếu ảnh không có gì cả
            if (graphics == null) return;
            //Trường hợp 2: Nếu đã tồn tại ảnh
            this.ptbDraw.CreateGraphics().Clear(this.ptbDraw.BackColor);
            graphics = null;
            //try
            //{

            //}
            //catch
            //{
            //    this.ptbDraw.ClientSize = new Size(10, 10);
            //}
        }
        #endregion
        #endregion
        #region Xử lý sự kiện cho Menustrip
        #region Tạo sự kiện
        private void mnsTaoSuKien_Click(object sender, EventArgs e)
        {
            this.txtTieuDe.Clear();
            this.rtbMoTa.Clear();
            this.ptbDraw.CreateGraphics().Clear(this.ptbDraw.BackColor);
            graphics = null;

        }
        #endregion
        #region Thoát chương trình
        private void mnsThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn thật sự muốn thoát chương trình?", "Thoát chương trình", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if(dlr == DialogResult.Yes)
                this.Close();
        }
        #endregion
        #endregion      
        #region Xử lý Next Event dùng Timer
        private void tmrNote_Tick(object sender, EventArgs e)
        {
            #region Các thuộc tính đầu
            DateTime previousDate = DateTime.MaxValue;
            DateTime currentDate = new DateTime();
            TimeSpan timeSpan = new TimeSpan();           
            int result = 0;
            #endregion
            #region Trường hợp không có sự kiện
            if (this.lstEvent.SelectedItems.Count == 0)
                return;
            #endregion
            #region Trường hợp tồn tại sự kiện
            else
            {
                #region Trường hợp chỉ có 1 sự kiện (So sánh với ngày giờ hệ thống)
                if (this.lstEvent.Items.Count > 0 && this.lstEvent.Items.Count < 2)
                {
                    previousDate = DateTime.Parse(this.lstEvent.SelectedItems[0].SubItems[2].Text);
                    currentDate = DateTime.Now;
                    if (DateTime.Compare(previousDate, currentDate) >= 0)
                    {
                        tslNextEvent.Text = "Next Event: " + this.lstEvent.Items[0].SubItems[1].Text;
                        timeSpan = previousDate.Subtract(currentDate);                       
                    }
                    else
                        return;
                }
                #endregion
                #region Trường hợp có 2 sự kiện trở lên
                else if (this.lstEvent.Items.Count >= 2)
                {                    
                    int index = -1;
                    previousDate = DateTime.Parse(this.lstEvent.SelectedItems[0].SubItems[2].Text);
                    List<DateTime> dateList = new List<DateTime>();
                    List<int> indexList = new List<int>();
                    for(int i=0;i<this.lstEvent.Items.Count;i++)
                    {
                        DateTime temp = DateTime.Parse(this.lstEvent.Items[i].SubItems[2].Text);
                        if (DateTime.Compare(previousDate, temp) < 0)
                        {
                            dateList.Add(temp);
                            indexList.Add(i);
                        }
                    }
                    if (dateList.Count > 0)
                    {
                        currentDate = dateList.Min();
                        int tempIndex = dateList.IndexOf(currentDate);
                        index = indexList[tempIndex];
                        if (this.lstEvent.SelectedItems[0].Index != index)
                        {
                            tslNextEvent.Text = "Next Event: " + this.lstEvent.Items[index].SubItems[1].Text;
                            timeSpan = currentDate.Subtract(previousDate);
                        }
                    }
                    else
                    {                      
                        return;
                    }
                }
                #endregion
            }
            #region Xử lý kết quả cuối
            switch (tscTimeSpan.Text)
            {
                case "Minute":
                    result = int.Parse(Math.Round(timeSpan.TotalMinutes).ToString());
                    break;
                case "Hour":
                    result = int.Parse(Math.Round(timeSpan.TotalHours).ToString());
                    break;
                default:
                    result = int.Parse(Math.Round(timeSpan.TotalDays).ToString());
                    break;
            }
            if (result >= tspNote.Maximum)
                tspNote.Value = tspNote.Maximum;
            else
                tspNote.Value = result;
            #endregion           
        }
        #endregion

        #endregion
        #region Sự kiện di con trỏ chuột trên khu vực vẽ hình (ptbDraw)
        private void ptbDraw_MouseHover(object sender, EventArgs e)
        {
            this.ptbDraw.Focus();
            this.helpProvider1.SetShowHelp(this.ptbDraw, true);
            this.helpProvider1.SetHelpString(this.ptbDraw, "Vẽ ghi chú cho sự kiện");
        }
        #endregion
        #region Xử lý hàm tìm kiếm username và thêm xóa người dùng
        #region Tìm kiếm username
        private void txtSearchUsername_TextChanged(object sender, EventArgs e)
        {
            this.lstSearchUsername.Items.Clear();
            //List<User> searchUser = this.listUsers.Where(x => x.username.Contains(this.txtSearchUsername.Text)).ToList();
            //List<User> searchUser = UserController.GetListUsers().Where(x => x.username.Contains(this.txtSearchUsername.Text)).ToList();
            List<User> searchUser = UserController.GetListUsers(this.txtSearchUsername.Text.Trim());
            if (searchUser.Count >0)
            {
                this.lstSearchUsername.Visible = true;
            }
            else
            {
                this.lstSearchUsername.Visible = false;
            }
            for(int i=0;i<searchUser.Count;i++)
            {
                this.lstSearchUsername.Items.Add(searchUser[i]);
            }
        }
        #endregion
        #region Thêm người dùng thông qua sự kiện double click
        private void lstSearchUsername_DoubleClick(object sender, EventArgs e)
        {
            //Bắt đầu chọn 1 đối tượng kiểu user
            if (this.lstSearchUsername.SelectedIndex >= 0)
            {
                #region Nếu lstUsers có số phần tử lớn hơn 0 => Bắt đầu kiểm tra lstUsers có tồn tại user(nếu có)
                if (this.lstUsers.Items.Count > 0)
                {
                    #region Nếu đã tồn tại username được chọn => Không thêm vào
                    foreach (User user in this.lstUsers.Items)
                    {
                        if (user == this.lstSearchUsername.SelectedItem)
                            return;
                    }
                    #endregion
                    //Nếu không tồn tại phần tử trùng với user dự định được thêm vào
                    this.lstUsers.Items.Add(this.lstSearchUsername.SelectedItem);
                }
                #endregion
                #region Trường hợp không tồn tại phần tử bên lstUsers => Thêm user vào mà không cần kiểm tra ràng buộc
                else
                {
                    this.lstUsers.Items.Add(this.lstSearchUsername.SelectedItem);
                }
                #endregion
            }
        }
        #endregion
        #region Xóa người dùng trong lstUsers thông qua sự kiện Double Click
        private void lstUsers_DoubleClick(object sender, EventArgs e)
        {
            if (this.lstUsers.SelectedIndex >= 0)
            {
                this.lstUsers.Items.Remove(this.lstUsers.SelectedItem);
            }
        }
        #endregion
        #endregion       
    }
    #region Lớp công cụ vẽ hình cho 1 sự kiện
    public class DrawNote
    {
        //Phương thức Get/Set
        public int X { get; set; }
        public int Y { get; set; }
        public Color color { get; set; }
        public Pen pen { get; set; }
        public bool isDrawn { get; set; }
        public DrawNote()
        {
            isDrawn = false;
            color = Color.Black;
            pen = new Pen(color, 2);
        }
    }
    #endregion
}
