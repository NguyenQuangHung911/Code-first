using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanagement.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public string username { get; set; } //Primary key
        public string hoTen { get; set; }
        public string boMon { get; set; }
        public DateTime? ngaySinh { get; set; } //Allow Null value
        public string soDT { get; set; }
        public string email { get; set; }
        public virtual ICollection<TaskWork> tasks { get; set; }
        public override string ToString()
        {
            return this.username;
        }
    }
}
