using FilmYorum.Models;
using FilmYorum.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmYorum.Proccess
{
    internal class UserProccess : IProccess<User>
    {
        UserRepository userRepository = new UserRepository();
        HomeProccess homeProccess = new HomeProccess();
        
        public void Add()
        {
            
            Console.WriteLine(
                userRepository.Add(SetValue()) ?
                "Add Is Successful" :
                "Add Is Unsuccessful");
            

        }

        public bool DeleteUser(int id)
        {
            bool status = false;
            if (id != 1)
            {
                if (userRepository.Delete(id))
                {
                    Console.WriteLine("Deletion Successful");
                    Console.ReadKey();
                    Console.Clear();
                    homeProccess.Home();
                }
                else
                {
                    Console.WriteLine("Deletion Unsuccessful");
                }

                                
            }
            else if (id == 1)
            {
                Console.WriteLine("User cannot be deleted ! ");
                Console.ReadKey();
            }
            return status;

        }

        public User Get()
        {
            Console.Write("Enter Detail User Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            User user = userRepository.Get(id);
            if (user != null)
            {
                Console.WriteLine("User Detail");
                Console.WriteLine("-------------");
                Console.WriteLine("\nId             : " + user.Id);
                Console.WriteLine("\nName           : " + user.Name);
                Console.WriteLine("\nSurname        : " + user.Surname);
                Console.WriteLine("\nE-mail         : " + user.Email);
                Console.WriteLine("\nPassword       : " + user.Password);
                Console.WriteLine("\nRole           : " + Roles.user.ToString());
                Console.WriteLine("\nStatus         : " + (user.IsStatus ? "Active" : "Passive"));
            }
            else
            {
                Console.WriteLine("Not Found User");
            }
            return user;
        }
        public User GetUser(int id)
        {
            User user = userRepository.Get(id);
            if (user != null)
            {
                Console.WriteLine("User Detail");
                Console.WriteLine("-------------");
                Console.WriteLine("\nId             : " + user.Id);
                Console.WriteLine("\nName           : " + user.Name);
                Console.WriteLine("\nSurname        : " + user.Surname);
                Console.WriteLine("\nE-mail         : " + user.Email);
                Console.WriteLine("\nPassword       : " + user.Password);
                Console.WriteLine("\nRole           : " + Roles.user.ToString());
                Console.WriteLine("\nStatus         : " + (user.IsStatus ? "Active" : "Passive"));
            }
            else
            {
                Console.WriteLine("Not Found User");
            }
            return user;
        }

        public void GetAll()
        {
            Console.WriteLine("--------User List--------");
            if (userRepository.GetAll().Count > 0)
            {
                foreach(var user in userRepository.GetAll())
                {
                    Console.WriteLine("User Detail");
                    Console.WriteLine("-----------");
                    Console.WriteLine("\nId             :" + user.Id);
                    Console.WriteLine("\nName           :" + user.Name);
                    Console.WriteLine("\nSurname        :" + user.Surname);
                    Console.WriteLine("\nE-mail         : " + user.Email);
                    Console.WriteLine("\nPassword       : " + user.Password);
                    Console.WriteLine("\nRole           : " + Roles.user.ToString());
                    Console.WriteLine("\nStatus         : " + (user.IsStatus ? "Active" : "Passive"));

                }
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("User List Is Empty");
            }
        }

        public void AdminMenu(string mail)
        {
            User user = userRepository.Login(mail);
            int id = user.Id;
            bool status = true;
            while (status)
            {
                Console.WriteLine("Select Proccess");
                Console.WriteLine("---------------");
                Console.WriteLine("\nAdmin Detail    (1)");
                Console.WriteLine("\nUpdate Admin    (2)");
                Console.WriteLine("\nUser List       (3)");
                Console.WriteLine("\nDelete User     (4)");
                Console.WriteLine("\nExit            (0)");
                Console.Write("\nSelect: ");
                int select = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (select)
                {
                   case 1:
                        GetUser(id);
                        break;

                    case 2:
                        UpdateUser(id);
                        break;

                    case 3:
                        GetAll();                        
                        break;

                    case 4:
                        Delete();
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
        public void UserMenu(string mail)
        {
            User user = userRepository.Login(mail);
            int id = user.Id;
            bool status2 = true;
            
            while (status2)
            {
                Console.WriteLine("Select Proccess");
                Console.WriteLine("---------------");
                Console.WriteLine("\nUser Detail    (1)");
                Console.WriteLine("\nDelete User    (2)");
                Console.WriteLine("\nUpdate User    (3)");
                Console.WriteLine("\nExit           (0)");
                Console.Write("\nSelect: ");
                int select = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (select)
                {
                    case 1:
                        GetUser(id);
                        break;

                    case 2:
                        DeleteUser(id);
                        break;                        

                    case 3:
                        UpdateUser(id);
                        break;

                    case 0:
                        status2 = !status2;
                        
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

        public User SetValue()
        {
            User user = new User();

            Console.Write("Name          : ");
            user.Name = Console.ReadLine();

            Console.Write("\nSurname       : ");
            user.Surname = Console.ReadLine();

            Console.Write("\nEmail         : ");
            user.Email = Console.ReadLine();

            Console.Write("\nPassword      : ");
            user.Password = Console.ReadLine();

            user.Role = Roles.user.ToString();

            Console.Write("User Status Active(A) Passive(P):");
            user.IsStatus = Console.ReadLine().Substring(0, 1).ToLower() == "a" ? true : false;
            Console.Clear();

            return user;
        }

        public void Update()
        {
            User user = Get();

            if (user != null)
            {
                User setUser = SetValue();
                if (setUser != null)
                {
                    setUser.Id = user.Id;
                    user = setUser;
                    userRepository.Update(user);
                }
            }
        }

        public void Menu()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            Console.Write("Enter Deleted User Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            if(id == 1)
            {
                Console.WriteLine("Admin can not be deleted !");
            }
            else if(id != 1)
            {
                Console.WriteLine(userRepository.Delete(id) ? "Deletion Successful" : "Deletion Unsuccessful");
            }
            
        }
        public void UpdateUser(int id)
        {
            User user = GetUser(id);

            if (user != null)
            {
                User setUser = SetValue();
                if (setUser != null)
                {
                    setUser.Id = user.Id;
                    user = setUser;
                    userRepository.Update(user);
                }
            }
        }

        bool IProccess<User>.UserMenu(string mail)
        {
            throw new NotImplementedException();
        }
    }
}
