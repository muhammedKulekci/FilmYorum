using EntityFrameworkExample.DataSource;
using EntityFrameworkExample.Models;
using EntityFrameworkExample.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Repository
{
    
    internal class UserRepository : IRepository<User>
    {
        private DataContext db = new DataContext();
        public bool Add(User entity)
        {
            bool result = false;
            if (entity != null)
            {

                db.User.Add(entity);
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool Delete(int id)
        {
            var user = db.User.Find(id);
            bool result = false;
            if (user != null)
            {
                user.IsDelete = true;
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        public User Get(int id)
        {
            return db.User.FirstOrDefault(x => x.Id == id && x.IsDelete == false);
        }

        public List<User> GetAll()
        {
            return db.User.Where(x => x.IsDelete == false).ToList();
        }

        public bool Update(User entity)
        {
            var user = db.User.Find(entity.Id);
            bool result = false;
            if (user != null)
            {
                user.Name = String.IsNullOrWhiteSpace(entity.Name) ? user.Name : entity.Name;
                user.IsStatus = entity.IsStatus;
                db.SaveChanges();

                result = true;
            }
            return result;

        }
    }
}