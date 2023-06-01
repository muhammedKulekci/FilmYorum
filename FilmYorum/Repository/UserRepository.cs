using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmYorum.DataSource;
using FilmYorum.Models;
using FilmYorum.Repository.Interfaces;

namespace FilmYorum.Repository
{
    internal class UserRepository : IRepository<User>
    {
        private DataContext db = new DataContext();

        public bool Add(User entity)
        {
            bool result = false;
            if (entity != null && !db.User.Any(u => u.Email == entity.Email))
            {
                db.User.Add(entity);
                result = !result;
                db.SaveChanges();
            }
            else
            {
                result = false;
            }
            return result;
        }

        public bool Delete(int id)
        {
            User user = db.User.FirstOrDefault(u => u.Id == id);
            bool result = false;
            if (user != null)
            {
                db.User.Remove(user);
                user.IsDelete = true;
                result = true;
                db.SaveChanges();
            }
            return result;
        }

        public User Get(int id)
        {
            return db.User.FirstOrDefault(x => x.Id == id && x.IsDelete == false);
        }
        public User Login(string Email)
        {
            return db.User.FirstOrDefault(x => x.Email == Email && x.IsDelete == false);
        }


        public List<User> GetAll() => db.User.Where(u => u.IsStatus && !u.IsDelete).ToList();


        public bool Update(User entity)
        {
            bool result = false;
            var user = db.User.Find(entity.Id);
            if (user != null)
            {
                user.Name = entity.Name;
                user.Surname = entity.Surname;
                user.Email = String.IsNullOrWhiteSpace(entity.Email) ? user.Email : entity.Email;
                user.Password = String.IsNullOrWhiteSpace(entity.Password) ? user.Password : entity.Password;
                user.IsStatus = entity.IsStatus;
                db.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
