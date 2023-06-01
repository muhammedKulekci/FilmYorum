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
    internal class CommentRepository : IRepository<Comments>
    {
        DataContext db = new DataContext();
        public bool Add(Comments entity)
        {
            bool result = false;
            if (entity != null)
            {
                db.Comments.Add(entity);
                result = true;
                db.SaveChanges();
            }
            return result;
        }

        public bool Delete(int id)
        {
            Comments comment = db.Comments.FirstOrDefault(x => x.Id == id);
            bool result = false;
            if (comment != null)
            {
                comment.IsDelete = true;
                result = true;
            }
            return result;

        }

        public Comments Get(int id) => db.Comments.FirstOrDefault(x => x.Id == id && !x.IsDelete && x.IsStatus);


        public List<Comments> GetAll()
        {

            return db.Comments.ToList();


        }

        public bool Update(Comments entity)
        {
            bool result = false;
            var comment = db.Comments.Find(entity.Id);
            if (comment != null)
            {
                comment.Content = entity.Content;
                comment.Rating = !String.IsNullOrEmpty(entity.Rating.ToString()) ? entity.Rating : comment.Rating;
                comment.IsStatus = entity.IsStatus;
                db.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}