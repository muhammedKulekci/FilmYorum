using FilmYorum.Models;
using FilmYorum.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;


namespace FilmYorum.Proccess
{
    internal class FilmProccess : IProccess<Films>
    {
        FilmRepository  filmRepository = new FilmRepository();
        CommentRepository commentRepository = new CommentRepository();
        CommentProccess commentProccess = new CommentProccess();
        UserRepository userRepository = new UserRepository();
        public void Add()
        {
            Console.WriteLine(
                filmRepository.Add(SetValue()) ?
                "Add Is Successful" :
                "Add Is Unsuccessful");
        }

        public void Delete()
        {
            Console.Write("Enter Deleted Film Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(filmRepository.Delete(id) ? "Deletion Successful" : "Deletion Unsuccessful");
        }

        public Films Get(string mail)
        {
            User user = userRepository.Login(mail);
            int userId = user.Id;
            Console.Write("Enter Detail Film Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Films film = filmRepository.Get(id);
            if (film != null)
            {

                var comments = commentRepository.GetAll().Where(c => c.FilmId == film.Id).ToList();

                Console.WriteLine("Film Detail");
                Console.WriteLine("-------------");
                Console.WriteLine("\nId            : " + film.Id);
                Console.WriteLine("\nName          : " + film.Name);
                Console.WriteLine("\nDescription   : " + film.Description);
                Console.WriteLine("\nDirector      : " + film.Director);
                Console.WriteLine("\nYear          : " + film.Year);
                Console.WriteLine("\nGenre         : " + film.Genre);
                Console.WriteLine("\nRating        : " + (comments.Any() ? comments.Average(c => c.Rating) : 0));
                Console.WriteLine("\nStatus        : " + (film.IsStatus ? "Active" : "Passive"));

                Console.WriteLine("\n\n------Comments-------\n");
                

                

                var list = (from c in commentRepository.GetAll()
                            join f in filmRepository.GetAll()
                                                        
                            on c.FilmId equals f.Id
                            where f.Id==id

                            select new
                            {
                                content = c.Content,
                                rating = c.Rating,
                                date = c.Date
                            }).ToList();

                foreach (var c in list)
                {
                    Console.WriteLine("Rating     :" + c.rating);
                    Console.WriteLine("Comment    :" + c.content);
                    Console.WriteLine("Date       :" + c.date);
                    Console.WriteLine("---------------------------");
                }

                commentProccess.Menu(id,userId);
            }
            else
            {
                Console.WriteLine("Not Found Film");
            }
            return film;
        }

        public void GetAll()
        {

            Console.WriteLine("Film List");
            if (filmRepository.GetAll().Count > 0)
            {
                    
                    foreach (var film in filmRepository.GetAll())
                    {
                        
                        Console.WriteLine("-------------");
                        Console.WriteLine("\nId           : " + film.Id);
                        Console.WriteLine("\nName         : " + film.Name);
                        Console.WriteLine("\nDescription  : " + film.Description);
                        Console.WriteLine("\nDirector     : " + film.Director);
                        Console.WriteLine("\nYear         : " + film.Year);
                        Console.WriteLine("\nGenre        : " + film.Genre);
                        Console.WriteLine("\nStatus       : " + (film.IsStatus ? "Active" : "Passive"));
                        
                    
                    }
                    Console.ReadKey();
                    
            }
            else
            {
                Console.WriteLine("Film List Is Empty");
            }
            Console.Clear();

            

        }

        public void Menu(int id,string mail)
        {

            bool status = true;
            while (status)
            {
                Console.WriteLine("Select Proccess");
                Console.WriteLine("---------------");
                Console.WriteLine("\nAdd Film       (1)");
                Console.WriteLine("\nFilm Detail    (2)");
                Console.WriteLine("\nDelete Film    (3)");
                Console.WriteLine("\nUpdate Film    (4)");
                Console.WriteLine("\nFilm List      (5)");
                Console.WriteLine("\nExit           (0)");
                Console.Write("\nSelect: ");
                int select = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (select)
                {
                    case 1:
                        Add();
                        break;

                    case 2:
                        Get(mail);
                        break;

                    case 3:
                        Delete();
                        break;

                    case 4:
                        Update();
                        break;

                    case 5:
                        GetAll();
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

        public Films SetValue()
        {
            Films film = new Films();

            Console.Write("Film Name                : ");
            film.Name = Console.ReadLine();

            Console.Write("\nFilm Description       : ");
            film.Description = Console.ReadLine();

            Console.Write("\nFilm Director          : ");
            film.Director = Console.ReadLine();

            Console.Write("\nFilm Year              : ");
            film.Year = Convert.ToInt32(Console.ReadLine());

            var genres = Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList();

            int i = 0;
            foreach(var genre in genres)
            {
                i++;
                Console.WriteLine(i+". "+genre);
            }

            Console.Write("Select Genre: ");
            int selectGenre = Convert.ToInt32(Console.ReadLine());

            switch (selectGenre)
            {
                case 1:
                    film.Genre = Genre.Action.ToString();
                    break;
                case 2:
                    film.Genre = Genre.Comedy.ToString();
                    break;
                case 3:
                    film.Genre = Genre.Romantic.ToString();
                    break;
                case 4:
                    film.Genre = Genre.ScienceFiction.ToString();
                    break;
                case 5:
                    film.Genre = Genre.Drama.ToString();
                    break;
                case 6:
                    film.Genre = Genre.RomanticComedy.ToString();
                    break;
                case 7:
                    film.Genre = Genre.Horror.ToString();
                    break;
                case 8:
                    film.Genre = Genre.Western.ToString();
                    break;
                default:
                    Console.WriteLine("Undefined transaction, try again...");
                    break;                    
            }

            Console.Write("Film Status Active(A) Passive(P):");
            film.IsStatus = Console.ReadLine().Substring(0, 1).ToLower() == "a" ? true : false;

            return film;
        }

        public void Update()
        {
            Films film = Get();

            if (film != null)
            {
                Films setFilm = SetValue();
                if (setFilm != null)
                {
                    setFilm.Id = film.Id;
                    film = setFilm;
                    filmRepository.Update(film);
                }
            }
        }

        public bool UserMenu(string mail)
        {
            throw new NotImplementedException();
        }
    }
}
