using FilmYorum.Models;
using FilmYorum.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmYorum.Proccess
{
    internal class CommentProccess
    {
        CommentRepository commentRepository = new CommentRepository();
        public void Add(int id,int userId)
        {
            Console.WriteLine(commentRepository.Add(SetValue(id,userId)) ? "Add Is Successful" : "Add Is Unsuccessful");
        }

        public bool DeleteComment(int id)
        {
            bool status = false;
            Console.WriteLine(commentRepository.Delete(id) ? "Deletion Successful" : "Deletion Unsuccessful");
            return status;

        }
        public void Delete(int id,int userId)
        {
            
            
            Console.WriteLine(commentRepository.Delete(id) ? "Deletion Successful" : "Deletion Unsuccessful");
        }

        public Comments Get()
        {
            Console.Write("Enter Detail User Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Comments comment = commentRepository.Get(id);
            if (comment != null&& comment.IsStatus==true&&comment.IsDelete!=true)
            {
                Console.WriteLine("Comment Detail");
                Console.WriteLine("-------------");
                Console.WriteLine("Id             : " + comment.Id);
                Console.WriteLine("Content        : " + comment.Content);
                Console.WriteLine("Rating         : " + comment.Rating);
                Console.WriteLine("Date           : " + comment.Date);
     
            }
            else
            {
                Console.WriteLine("Not Found Comment");
            }
            return comment;
        }
        public Comments GetComment()
        {
            Console.Write("Enter Detail User Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Comments comment = commentRepository.Get(id);
            if (comment != null && comment.IsStatus == true && comment.IsDelete != true)
            {
                Console.WriteLine("Comment Detail");
                Console.WriteLine("-------------");
                Console.WriteLine("Id             : " + comment.Id);
                Console.WriteLine("Content        : " + comment.Content);
                Console.WriteLine("Rating         : " + comment.Rating);
                Console.WriteLine("Date           : " + comment.Date);

            }
            else
            {
                Console.WriteLine("Not Found Comment");
            }
            return comment;
        }
        public Comments GetComment(int id)
        {
            Comments comment = commentRepository.Get(id);
            if (comment != null)
            {
                Console.WriteLine("Comment Detail");
                Console.WriteLine("-------------");
                Console.WriteLine("\nId             : " + comment.Id);
                Console.WriteLine("\nContent        : " + comment.Content);
                Console.WriteLine("\nRating         : " + comment.Rating);
                Console.WriteLine("\nDate           : " + comment.Date);
            }
            else
            {
                Console.WriteLine("Not Found Comment");
            }
            return comment;
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }

        public void Menu(int id,int userId)
        {
            bool status = true;
            while(status)
            {
                Console.WriteLine("Select Proccess");
                Console.WriteLine("---------------");
                Console.WriteLine("\nAdd comment      (1)");
                Console.WriteLine("\nDelete comment   (2)");
                Console.WriteLine("\nUpdate Comment   (3)");
                Console.WriteLine("\nUp Menu          (0)");
                Console.Write("Select: ");
                int select = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (select)
                {
                    case 1:
                        Add(id, userId);
                        break;

                    case 2:
                        Delete(id, userId);
                        break;

                    case 3:
                        Update(id, userId);
                        break;

                    case 0:
                        status = !status;
                        break;
                    default:
                        Console.WriteLine("Undefined transaction, try again...");
                        break;
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
            
        }

        public Comments SetValue(int id, int userId)
        {
            Comments comment = new Comments();
            comment.FilmId= id;
            comment.UserId = userId;

            Console.Write("Content       : ");
            comment.Content = Console.ReadLine();

            Console.Write("\nRating        : ");
            comment.Rating = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nComment Status Active(A) Passive(P):");
            comment.IsStatus = Console.ReadLine().Substring(0, 1).ToLower() == "a" ? true : false;

            return comment;
        }

        public void Update(int id, int userId)
        {
            Comments comment = Get();
            if (comment != null)
            {
                Comments setComment = SetValue(id, userId);
                if (setComment != null)
                {
                    setComment.Id = comment.Id;
                    comment = setComment;
                    commentRepository.Update(comment);
                }
            }
        }

        public bool UserMenu(string mail)
        {
            throw new NotImplementedException();
        }
    }
}
