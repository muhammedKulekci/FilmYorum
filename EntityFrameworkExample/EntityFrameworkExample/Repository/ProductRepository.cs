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
    internal class ProductRepository:IRepository<Product>
    {
        private DataContext db = new DataContext();
        public bool Add(Product entity)
        {
            bool result = false;
            if (entity != null)
            {

                db.Product.Add(entity);
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool Delete(int id)
        {
            var Product = db.Product.Find(id);
            bool result = false;
            if (Product != null)
            {
                Product.IsDelete = true;
                db.SaveChanges();
                result = true;
            }
            return result;
        }

        public Product Get(int id)
        {
            return db.Product.FirstOrDefault(x => x.Id == id && x.IsDelete == false);
        }

        public List<Product> GetAll()
        {
            return db.Product.Where(x => x.IsDelete == false).ToList();
        }

        public bool Update(Product entity)
        {
            var Product = db.Product.Find(entity.Id);
            bool result = false;
            if (Product != null)
            {
                Product.Name = String.IsNullOrWhiteSpace(entity.Name) ? Product.Name : entity.Name;
                Product.IsStatus = entity.IsStatus;
                db.SaveChanges();

                result = true;
            }
            return result;

        }
    }
}
