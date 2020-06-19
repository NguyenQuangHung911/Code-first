using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Taskmanagement.Models;
using System.Data.Entity.Migrations;
using System.Security.Cryptography;

namespace Taskmanagement.Controllers
{
    public class UserController
    {
        public static bool AddUser(User user)
        {
            try
            {
                using (var _context = new DBTaskContext())
                {
                    _context.tbUsers.Add(user);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static User GetUser(string username)
        {
            using (var _context= new DBTaskContext())
            {
                var user = (from u in _context.tbUsers
                            where u.username == username
                            select u).ToList();
                if (user.Count == 1)
                {
                    return user[0];
                }
                else
                {
                    return null;
                }
            }
        }
        public static List<User> GetListUsers()
        {
            using (var _context = new DBTaskContext())
            {
                var user = (from u in _context.tbUsers.AsEnumerable()
                            select new {
                                username = u.username,
                                hoTen = u.hoTen,
                                ngaySinh = u.ngaySinh,
                                boMon = u.boMon,
                                soDT = u.soDT,
                                email = u.email
                            })
                            .Select(x => new User
                            {
                                username = x.username,
                                hoTen = x.hoTen,
                                ngaySinh = x.ngaySinh,
                                boMon = x.boMon,
                                soDT = x.soDT,
                                email = x.email
                            }).ToList();
                return user;
            }
        }
        public static List<User> GetListUsers(string searchUsername)
        {
            using (var _context = new DBTaskContext())
            {
                //var user = (from u in _context.tbUsers.AsEnumerable()
                //            where u.username.Contains(searchUsername)
                //            select new
                //            {
                //                username = u.username,
                //                hoTen = u.hoTen,
                //                ngaySinh = u.ngaySinh,
                //                boMon = u.boMon,
                //                soDT = u.soDT,
                //                email = u.email
                //            })
                //            .Select(x => new User
                //            {
                //                username = x.username,
                //                hoTen = x.hoTen,
                //                ngaySinh = x.ngaySinh,
                //                boMon = x.boMon,
                //                soDT = x.soDT,
                //                email = x.email
                //            }).ToList();
                var user = (from u in _context.tbUsers.Include("tasks")
                            where u.username.Contains(searchUsername)
                            select u).ToList();                           
                return user;
            }
        }
        public static bool UpdateUser(User user)
        {
            using (var _context = new DBTaskContext())
            {
                _context.tbUsers.AddOrUpdate(user);
                _context.SaveChanges();
                return true;
            }
        }
        //public static bool DeleteUser(string username)
        //{
        //    using (var _context = new DBTaskContext())
        //    {
        //        User user = (from u in _context.tbUsers
        //                     where u.username == username
        //                     select u).SingleOrDefault();
        //        _context.tbUsers.Remove(user);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //}
        public static bool DeleteUser(User user)
        {
            using (var _context = new DBTaskContext())
            {
                //Lấy thực thể kiểu User từ database
                var dbUser = (from u in _context.tbUsers
                             where u.username == user.username
                             select u).SingleOrDefault();
                #region Xoá user khỏi danh sách công việc
                foreach (var task in dbUser.tasks)
                {
                    foreach(var u in task.listUser)
                    {
                        if(u.username == user.username)
                        {
                            task.listUser.Remove(u);
                            break;
                        }
                    }
                }
                #endregion
                _context.tbUsers.Remove(dbUser);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
