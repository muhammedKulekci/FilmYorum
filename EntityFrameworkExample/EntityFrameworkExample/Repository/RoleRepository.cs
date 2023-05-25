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
    internal class RoleRepository : IRepository<Role>
    {
        private DataContext db = new DataContext();
        public bool Add(Role entity)
        {
            bool result = false;
            if (entity != null)
            {

                db.Role.Add(entity);
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool Delete(int id)
        {
            var role = db.Role.Find(id);
            bool result = false;
            if (role != null)
            {
                role.IsDelete = true;
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        public Role Get(int id)
        {
            return db.Role.FirstOrDefault(x => x.Id == id && x.IsDelete == false);
        }

        public List<Role> GetAll()
        {
            return db.Role.Where(x => x.IsDelete == false).ToList();
        }

        public bool Update(Role entity)
        {
            var role = db.Role.Find(entity.Id);
            bool result = false;
            if (role != null)
            {
                role.Name = String.IsNullOrWhiteSpace(entity.Name) ? role.Name : entity.Name;
                role.IsStatus = entity.IsStatus;
                db.SaveChanges();

                result = true;
            }
            return result;

        }
    }
}
    
        