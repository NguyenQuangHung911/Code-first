using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taskmanagement.Models;

namespace Taskmanagement.Controllers
{
    public class dbTestController
    {
        public static void initializeDB()
        {
            using(var _context=new DBTaskContext())
            {
                var user = new User { username = "phung", ngaySinh = DateTime.Now };
                _context.tbUsers.Add(user);
                _context.SaveChanges();
            }
            MessageBox.Show("Finish!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
