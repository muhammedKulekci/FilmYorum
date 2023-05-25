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
    internal class CategoryRepository:IRepository<Category>
    {
        private DataContext db = new DataContext();
        public bool Add(Category entity)
        {
            bool result = false;
            if (entity != null)
            {

                db.Category.Add(entity);
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool Delete(int id)
        {
            var Category = db.Category.Find(id);
            bool result = false;
            if (Category != null)
            {
                Category.IsDelete = true;
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        public Category Get(int id)
        {
            return db.Category.FirstOrDefault(x => x.Id == id && x.IsDelete == false);
        }

        public List<Category> GetAll()
        {
            return db.Category.Where(x => x.IsDelete == false).ToList();
        }

        public bool Update(Category entity)
        {
            var Category = db.Category.Find(entity.Id);
            bool result = false;
            if (Category != null)
            {
                Category.Name = String.IsNullOrWhiteSpace(entity.Name) ? Category.Name : entity.Name;
                Category.IsStatus = entity.IsStatus;
                db.SaveChanges();

                result = true;
            }
            return result;

        }
    }
}