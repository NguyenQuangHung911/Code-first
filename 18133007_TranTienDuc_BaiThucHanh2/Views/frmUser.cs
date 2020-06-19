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
    public partial class frmUser : Form
    {
        #region Danh sách biến
        List<User> listUsers;
        DateTimePicker dtpTemp;
        ComboBox cmbTemp;
        //DataGridViewComboBoxCell cmbTemp;
        //DataGridViewComboBoxColumn cmbTemp;
        #endregion
        #region Các sự kiện của form frmUser
        #region Hàm khởi tạo frmUser
        public frmUser(ref List<User> users)
        {
            InitializeComponent();
            this.dgvUser.AutoGenerateColumns = false;
            this.txtUserName.Select();
            this.listUsers = users;
            #region Gán thuộc tính dữ liệu cho các thuộc tính
            this.colUserName.DataPropertyName = nameof(User.username);
            this.colFullName.DataPropertyName = nameof(User.hoTen);
            this.colBoMon.DataPropertyName = nameof(User.boMon);
            this.colBirthDay.DataPropertyName = nameof(User.ngaySinh);
            this.colPhone.DataPropertyName = nameof(User.soDT);
            this.colEmail.DataPropertyName = nameof(User.email);
            #endregion
            this.cmbBoMon.Text = this.cmbBoMon.Items[0].ToString();
            #region Đổ dữ liệu từ listUsers vào để hiển thị lại nội dung
            BindingSource source = new BindingSource();
            source.DataSource = UserController.GetListUsers();
            this.dgvUser.DataSource = source;
            #endregion
        }
        #endregion
        #region Sự kiện load form frmUser
        private void frmUser_Load(object sender, EventArgs e)
        {
            #region Set Help Provider => Nhấn F1 để hiển thị trợ giúp
            this.helpProvider2.SetShowHelp(this.txtUserName, true);
            this.helpProvider2.SetHelpString(this.txtUserName, "Đây là nơi nhập Username.");
            this.helpProvider2.SetShowHelp(this.txtHoTen, true);
            this.helpProvider2.SetHelpString(this.txtHoTen, "Đây là nơi nhập họ và tên đầy đủ.");
            this.helpProvider2.SetShowHelp(this.cmbBoMon, true);
            this.helpProvider2.SetHelpString(this.cmbBoMon, "Đây là nơi nhập tên bộ môn");
            this.helpProvider2.SetShowHelp(this.dtpNgaySinh, true);
            this.helpProvider2.SetHelpString(this.dtpNgaySinh, "Đây là nơi chọn ngày sinh");
            this.helpProvider2.SetShowHelp(this.txtPhone, true);
            this.helpProvider2.SetHelpString(this.txtPhone, "Đây là nơi nhập số điện thoại của người dùng");
            this.helpProvider2.SetShowHelp(this.txtEmail, true);
            this.helpProvider2.SetHelpString(this.txtEmail, "Đây là nơi nhập địa chỉ email của người dùng");
            #endregion
        }
        #endregion
        #endregion
        #region Xử lý sự kiện cho các nút bấm
        #region Thêm người dùng
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            #region Set Error Provider
            //Nếu chưa nhập username
            if (this.txtUserName.Text.Trim().Length <= 0)
            {
                this.errorProvider2.SetError(this.txtUserName, "Yêu cầu nhập username!");
                return;
            }
            else if (UserController.GetUser(this.txtUserName.Text.Trim()) != null)
            {
                this.errorProvider2.SetError(this.txtUserName, "User đã tồn tại!");
                return;
            }
            //Nếu chưa nhập họ tên
            if (this.txtHoTen.Text.Trim().Length <= 0)
            {
                this.errorProvider2.SetError(this.txtHoTen, "Yêu cầu nhập họ và tên đầy đủ!");
                return;
            }
            //if (this.txtBoMon.Text.Trim().Length <= 0)
            //{
            //    this.errorProvider2.SetError(this.txtBoMon, "Yêu cầu nhập bộ môn!");
            //    return;
            //}
            //Nếu thời gian trong datetime picker lớn hơn bằng thời gian hệ thống
            if (DateTime.Now.Year - dtpNgaySinh.Value.Year < 18)
            {
                this.errorProvider2.SetError(this.dtpNgaySinh, "Độ tuổi của nhân viên phải từ 18 tuổi trở lên!");
                return;
            }
            if (this.txtPhone.Text.Trim().Length <= 0)
            {
                this.errorProvider2.SetError(this.txtPhone, "Yêu cầu nhập số điện thoại liên lạc!");
                return;
            }
            if (this.txtEmail.Text.Trim().Length <= 0)
            {
                this.errorProvider2.SetError(this.txtEmail, "Yêu cầu nhập địa chỉ email!");
                return;
            }
            errorProvider2.Clear();
            #endregion
            #region Gán cho biến có kiểu dữ liệu là lớp User
            User user = new User();
            user.username = this.txtUserName.Text.Trim();
            user.hoTen = this.txtHoTen.Text.Trim();
            //user.boMon = this.txtBoMon.Text.Trim();
            user.boMon = this.cmbBoMon.SelectedItem.ToString();
            user.ngaySinh = this.dtpNgaySinh.Value;
            user.soDT = this.txtPhone.Text;
            user.email = this.txtEmail.Text;
            if (UserController.AddUser(user) == false)
            {
                MessageBox.Show("Lỗi thêm user!");
                return;
            }
            #endregion
            #region Kiểm tra username
            //Nếu đã tồn tại username đó trong listUsers
            if (this.listUsers.Where(x => x.username == user.username).Count() >0)
            {
                MessageBox.Show("Username đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion
            #region Thêm user vào danh sách
            listUsers.Add(user);
            #endregion
            #region Thêm user từ listUsers vào Datagridview
            BindingSource source = new BindingSource();
            //Chọn nguồn dữ liệu của source từ listUsers
            source.DataSource = UserController.GetListUsers();
            //Chọn nguồn dữ liệu của datagridview từ source
            this.dgvUser.DataSource = source;
            #endregion
            #region Xóa nội dung của các control để người dùng có thể nhập tiếp
            this.txtUserName.Clear();
            this.txtHoTen.Clear();
            this.dtpNgaySinh.ResetText();
            this.txtPhone.Clear();
            this.txtEmail.Clear();
            #endregion
        }
        #endregion
        #region Xóa Người dùng
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (this.dgvUser.Rows.Count > 0)
            {
                if (this.dgvUser.SelectedRows.Count > 0)
                {
                    string temp = this.dgvUser.SelectedRows[0].Cells[0].Value.ToString();
                    User user = UserController.GetUser(temp);
                    if(UserController.DeleteUser(user) is false)
                    {
                        MessageBox.Show("Can not delete!");
                    }
                    BindingSource source = new BindingSource();
                    source.DataSource = UserController.GetListUsers();
                    this.dgvUser.DataSource = source;
                    #region Khúc xử lý cũ
                    //var user = listUsers.FirstOrDefault(x => x.username == temp);
                    //if (user != null)
                    //    listUsers.Remove(user);
                    //this.dgvUser.DataSource = listUsers.ToList();
                    #endregion
                    //this.dgvUser.Rows.RemoveAt(this.dgvUser.CurrentCell.RowIndex);
                }
            }
        }
        #endregion
        #endregion
        #region Xử lý các sự kiện trên datagrid dgvUser
        #region Sự kiện click vào 1 ô
        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(!dgvUser.IsCurrentCellInEditMode)
            if ((e.ColumnIndex != -1) && (this.dgvUser.Columns[e.ColumnIndex].DataPropertyName == nameof(User.ngaySinh)))
            {
                dtpTemp = new DateTimePicker();
                dtpTemp.Format = DateTimePickerFormat.Short;
                dtpTemp.Visible = true;
                #region Thiết lập vị trí đặt datetime picker
                Rectangle rect = this.dgvUser.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dtpTemp.Location = new Point(rect.X, rect.Y);
                dtpTemp.Size = new Size(rect.Width, rect.Height);
                #endregion
                #region Xử lý dữ liệu cho datetime picker
                try
                {
                    dtpTemp.Value = DateTime.Parse(this.dgvUser.CurrentCell.Value.ToString());
                }
                catch
                {
                    dtpTemp.Value = DateTime.Now;
                }
                #endregion
                #region Thêm sự kiện cho datetime picker trong cột ngày sinh
                dtpTemp.CloseUp += DtpTemp_CloseUp;
                dtpTemp.TextChanged += DtpTemp_TextChanged;
                #endregion
                //this.dgvUser.Controls.Add(dtpTemp);
            }
            this.dgvUser.Controls.Add(dtpTemp);
            #region Thêm combobox vào control
            if ((e.ColumnIndex != -1) && (this.dgvUser.Columns[e.ColumnIndex].DataPropertyName == nameof(User.boMon)))
            {
                cmbTemp = new ComboBox();
                //cmbTemp = new DataGridViewComboBoxColumn();
                cmbTemp.Items.Add("CNPM");
                cmbTemp.Items.Add("HHTT");
                cmbTemp.Items.Add("MMT");
                cmbTemp.Items.Add("THCS");
                cmbTemp.Visible = true;
                Rectangle rect = this.dgvUser.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                cmbTemp.Location = new Point(rect.X, rect.Y);
                cmbTemp.Size = new Size(rect.Width, rect.Height);
                cmbTemp.DropDownClosed += CmbTemp_DropDownClosed;
                cmbTemp.TextChanged += CmbTemp_TextChanged;
                //this.dgvUser.Columns.Add(cmbTemp);
                //this.dgvUser.Controls.Add(cmbTemp);
            }
            this.dgvUser.Controls.Add(cmbTemp);
            #endregion
        }

        #region Các sự kiện của combobox trên datagridview
        //private void CmbTemp_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    this.dgvUser.CurrentCell.Value = this.cmbTemp.SelectedText.ToString();
        //    User user = new User();
        //    user.username = this.dgvUser.CurrentRow.Cells[0].Value.ToString();
        //    user.hoTen = this.dgvUser.CurrentRow.Cells[1].Value.ToString();
        //    user.boMon = this.dgvUser.CurrentRow.Cells[2].Value.ToString();
        //    user.ngaySinh = DateTime.Parse(this.dgvUser.CurrentRow.Cells[3].Value.ToString());
        //    int index = listUsers.FindIndex(x => x.username == user.username);
        //    listUsers[index] = user;
        //    this.dgvUser.DataSource = listUsers.ToList();
        //}
        private void CmbTemp_TextChanged(object sender, EventArgs e)
        {
            this.dgvUser.CurrentRow.Cells[2].Value = cmbTemp.SelectedItem.ToString();
            User user = UserController.GetUser(this.dgvUser.CurrentRow.Cells[0].Value.ToString());
            user.boMon = cmbTemp.SelectedItem.ToString();
            UserController.UpdateUser(user);
        }

        private void CmbTemp_DropDownClosed(object sender, EventArgs e)
        {
            cmbTemp.Visible = false;
            //cmbTemp.Dispose();
        }
        #endregion
        #endregion
        #region Sự kiện của datetime picker
        #region Sự kiện thay đổi giá trị trên datetime picker     
        private void DtpTemp_TextChanged(object sender, EventArgs e)
        {
            //int year = DateTime.Parse(this.dgvUser.CurrentCell.Value.ToString()).Year;
            //if (this.dtpTemp.Value.Year - year < 18)
            //{
            //    MessageBox.Show("Yêu cầu độ tuổi của nhân viên phải từ 18 tuổi trở lên!", "Cảnh báo", MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning);
            //    return;
            //}
            //Cập nhật giá trị trực quan trên datagridview
            this.dgvUser.CurrentCell.Value = this.dtpTemp.Value.ToString();
            #region Cập nhật dữ liệu trong listUsers
            User user = new User();
            user.username = this.dgvUser.CurrentRow.Cells[0].Value.ToString();
            user.hoTen = this.dgvUser.CurrentRow.Cells[1].Value.ToString();
            user.boMon = this.dgvUser.CurrentRow.Cells[2].Value.ToString();
            user.ngaySinh = DateTime.Parse(this.dgvUser.CurrentRow.Cells[3].Value.ToString());
            user.soDT = this.dgvUser.CurrentRow.Cells[4].Value.ToString();
            user.email = this.dgvUser.CurrentRow.Cells[5].Value.ToString();
            //int index = listUsers.FindIndex(x => x.username == user.username);
            //listUsers[index] = user;
            UserController.UpdateUser(user);
            BindingSource source = new BindingSource();
            source.DataSource = UserController.GetListUsers();
            this.dgvUser.DataSource = source;
            //this.dgvUser.DataSource = listUsers.ToList();
            #endregion
        }
        #endregion
        #region Sự kiện đóng datetime picker
        private void DtpTemp_CloseUp(object sender, EventArgs e)
        {
            dtpTemp.Visible = false;
            dtpTemp.Dispose();
        }
        #endregion
        #endregion
        #region Sự kiện kết thúc chế độ chỉnh sửa (Edit Mode) ô trống của datagridview
        private void dgvUser_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex <= 0)
                return;
            #region Gán vào biến kiểu dữ liệu User để chuẩn bị xử lý
            User user = new User();
            user.username = this.dgvUser.CurrentRow.Cells[0].Value.ToString();
            if (user.username.Length <= 0)
                return;
            if (this.dgvUser.CurrentRow.Cells[1].Value is null)
                this.dgvUser.CurrentRow.Cells[1].Value = "";
            user.hoTen = this.dgvUser.CurrentRow.Cells[1].Value.ToString().Trim();
            if (this.dgvUser.CurrentRow.Cells[2].Value is null)
                this.dgvUser.CurrentRow.Cells[2].Value = "";
            user.boMon = this.dgvUser.CurrentRow.Cells[2].Value.ToString();
            //this.dgvUser.CurrentRow.Cells[2].Value = this.colBoMon.Selected.ToString();
            if (this.dgvUser.CurrentRow.Cells[3].Value is null)
                this.dgvUser.CurrentRow.Cells[3].Value = "01/01/1990";
            user.ngaySinh = DateTime.Parse(this.dgvUser.CurrentRow.Cells[3].Value.ToString()).Date;
            if (this.dgvUser.CurrentRow.Cells[4].Value is null)
                this.dgvUser.CurrentRow.Cells[4].Value = "";
            user.soDT = this.dgvUser.CurrentRow.Cells[4].Value.ToString();
            if (this.dgvUser.CurrentRow.Cells[5].Value is null)
                this.dgvUser.CurrentRow.Cells[5].Value = "";
            user.email = this.dgvUser.CurrentRow.Cells[5].Value.ToString();
            #endregion
            #region Phần xử lý user trước kia (không dùng nữa)
            //try
            //{
            //    user.hoTen = this.dgvUser.CurrentRow.Cells[1].Value.ToString();
            //    user.boMon = this.dgvUser.CurrentRow.Cells[2].Value.ToString();
            //    user.ngaySinh = DateTime.Parse(this.dgvUser.CurrentRow.Cells[3].Value.ToString());
            //    user.soDT = this.dgvUser.CurrentRow.Cells[4].Value.ToString();
            //    user.email = this.dgvUser.CurrentRow.Cells[5].Value.ToString();
            //}
            //catch
            //{
            //    user.ngaySinh = DateTime.Now;
            //    user.hoTen = "";
            //    user.boMon = "";
            //    user.soDT = "";
            //    user.email = "";
            //}
            //#endregion
            //#region Xử lý dữ liệu tại dòng hiện tại trong datagridview
            //int count = listUsers.Where(x => x.username == user.username).Count();
            //#region Các trường hợp có thể có về dữ liệu username trong datagridview và listUsers
            //#region Nếu chưa tồn tại username trong listUsers
            //if (count == 0)
            //{
            //    listUsers.Add(user);
            //}
            //#endregion
            //#region Nếu đã tồn tại username trong listUsers và số bộ trong datagridview bằng số phần tử trong listUsers cộng 1 (do có tính dòng trống) => Cập nhật dữ liệu trong listUsers
            //else if (count == 1 && this.dgvUser.Rows.Count == (listUsers.Count() + 1))
            //{
            //    int index = listUsers.FindIndex(x => x.username == user.username);
            //    if (index != e.RowIndex)
            //    {
            //        MessageBox.Show("Trùng username!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        this.dgvUser.CurrentRow.Cells[0].Value = listUsers[e.RowIndex].username;
            //        //this.dgvUser.CurrentRow.Cells[1].Value = listUsers[e.RowIndex].boMon;
            //        return;
            //    }
            //    listUsers[index] = user;
            //}
            //#endregion
            //#region Nếu trùng username và số bộ trong datagridview khác số phần tử trong listUsers => Xóa dòng bị trùng username gần nhất
            //else if (count == 1 && this.dgvUser.Rows.Count != listUsers.Count())
            //{
            //    MessageBox.Show("Trùng username!\nUsername bạn đang điền vào trùng với username trong danh sách", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.dgvUser.CurrentRow.Cells[0].Value = "";
            //    this.dgvUser.Rows.RemoveAt(this.dgvUser.Rows.Count - 2);
            //    return;
            //}
            //#endregion
            #endregion
            if (!UserController.UpdateUser(user))
            {
                MessageBox.Show("Can not update!");
            }
            #region Đổ dữ liệu từ listUsers vào datagridview
            BindingSource source = new BindingSource();
            source.DataSource = UserController.GetListUsers();
            this.dgvUser.DataSource = source;
            #endregion
            //#endregion
            //#endregion
        }
        #endregion
        #endregion        
    }
}
