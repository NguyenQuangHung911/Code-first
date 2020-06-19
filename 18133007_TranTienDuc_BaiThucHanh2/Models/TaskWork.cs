using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskmanagement.Models
{
    [Table("TaskWork")]
    public class TaskWork
    {
        public TaskWork()
        {
            listUser = new List<User>();
        }
        [Key]
        public int ID { get; set; } //Primary key
        public string title { get; set; }
        public string description { get; set; }
        public DateTime? fromDate { get; set; } //Allow Null value
        public DateTime? toDate { get; set; } //Allow Null value
        public ICollection<User> listUser { get; set; }
        public override string ToString()
        {
            string result = this.ID + "," + this.title + "," + this.fromDate.ToString() + ","
                + this.toDate.ToString() + "," + this.description + ",";
            int len = this.listUser.Count();
            if (len > 0)
            {
                for (int i = 0; i < len - 1; i++)
                {
                    result += this.listUser.ToList()[i].ToString() + " ";
                }
                result += this.listUser.ToList()[len - 1].ToString();
            }
            return result;
        }
    }
}
