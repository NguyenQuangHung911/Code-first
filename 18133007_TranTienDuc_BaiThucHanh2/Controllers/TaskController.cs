using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskmanagement.Models;

namespace Taskmanagement.Controllers
{
    public class TaskController
    {
        public static int GetIDFromDB()
        {
            using (var _context = new DBTaskContext())
            {
                var id = (from t in _context.tbTaskWorks
                          select t.ID).ToList();
                if(id.Count <= 0)
                {
                    return 1;
                }
                else
                {
                    return id.Max() + 1;
                }
            }
        }
        public static bool AddTask(TaskWork task)
        {
            using (var _context = new DBTaskContext())
            {
                foreach(var user in task.listUser)
                {
                    //var dbUser = (from u in _context.tbUsers
                    //              where u.username == user.username
                    //              select u).Single();
                    var dbUser = _context.tbUsers.Single(x => x.username == user.username);
                    if (dbUser.tasks is null)
                    {
                        dbUser.tasks = new List<TaskWork>();
                    }
                    dbUser.tasks.Add(task);
                }
                task.listUser.Clear();
                _context.tbTaskWorks.AddOrUpdate(task);
                _context.SaveChanges();
                return true;
            }
        }
        public static bool UpdateTask(TaskWork task)
        {
            using (var _context =new DBTaskContext())
            {
                var dbTask = (from t in _context.tbTaskWorks
                              where t.ID == task.ID
                              select t).SingleOrDefault();
                foreach (var user in task.listUser)
                {
                    var dbUser = (from u in _context.tbUsers
                                  where u.username == user.username
                                  select u).SingleOrDefault();
                    dbUser.tasks.Add(dbTask);
                }
                task.listUser.Clear();
                _context.tbTaskWorks.AddOrUpdate(task);
                _context.SaveChanges();
                return true;
            }
        }
        public static bool DeleteTask(TaskWork task)
        {
            using (var _context = new DBTaskContext())
            {
                //Lấy thực thể kiểu User từ database
                var dbTask = (from t in _context.tbTaskWorks
                              where t.ID == task.ID
                              select t).SingleOrDefault();
                #region Xoá công việc khỏi quan hệ tbUser
                foreach (var user in dbTask.listUser)
                {
                    foreach (var tempTask in user.tasks)
                    {
                        if (tempTask.ID == task.ID)
                        {
                            user.tasks.Remove(tempTask);
                            break;
                        }
                    }
                }
                #endregion
                _context.tbTaskWorks.Remove(dbTask);
                _context.SaveChanges();
                return true;
            }
        }
        public static List<TaskWork> GetAllTasks()
        {
            using (var _context = new DBTaskContext())
            {
                var dbTask = (from t in _context.tbTaskWorks.Include("listUser").AsEnumerable()
                              select new
                              {
                                  ID = t.ID,
                                  title = t.title,
                                  description = t.description,
                                  fromDate = t.fromDate,
                                  toDate = t.toDate,
                                  listUser = t.listUser
                              })
                              .Select(x => new TaskWork
                              {
                                  ID = x.ID,
                                  title = x.title,
                                  description = x.description,
                                  fromDate = x.fromDate,
                                  toDate = x.toDate,
                                  listUser = x.listUser
                              });
                return dbTask.ToList();
            }
        }
    }
}
