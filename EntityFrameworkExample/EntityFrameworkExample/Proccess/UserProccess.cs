using EntityFrameworkExample.Models;
using EntityFrameworkExample.Repository;
using EntityFrameworkExample.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Proccess
{
    internal class UserProccess : IProccess<User>
    {
        UserRepository userRepository = new UserRepository();


        public void Add()
        {
            User user = SetValue();
            Console.WriteLine(userRepository.Add(user) ? "Add is Successful" : "Add is Unsuccessful");
        }
        public User SetValue()
        {
            User user = new User();

            Console.Write("User Name       : ");
            user.Name = Console.ReadLine();            
            Console.Write("User Status Active(A) Passive(P):");
            user.IsStatus = Console.ReadLine().Substring(0, 1).ToLower() == "a" ? true : false;

            return user;
        }

        public void Delete()
        {

            Console.Write("Enter Deleted User Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(userRepository.Delete(id) ? "Deletion Successful" : "Deletion Unsuccessful");
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
                Console.WriteLine("Id             : " + user.Id);
                Console.WriteLine("Name           : " + user.Name);
                Console.WriteLine("Surname        : " + user.Surname);
                Console.WriteLine("E-mail         : " + user.Email);
                Console.WriteLine("Password       : " + user.Password);
                Console.WriteLine("RoleId         : " + user.RoleId);
                Console.WriteLine("Status         : " + (user.IsStatus ? "Active" : "Passive"));
            }
            else
            {
                Console.WriteLine("Not Found User");
            }
            return user;
        }

        public void GetAll()
        {
            Console.WriteLine("User List");
            if (userRepository.GetAll().Count > 0)
            {
                foreach (var user in userRepository.GetAll())
                {
                    Console.WriteLine("-------------");
                    Console.WriteLine("Id             : " + user.Id);
                    Console.WriteLine("Name           : " + user.Name);
                    Console.WriteLine("Surname        : " + user.Surname);
                    Console.WriteLine("E-mail         : " + user.Email);
                    Console.WriteLine("Password       : " + user.Password);
                    Console.WriteLine("RoleId         : " + user.RoleId);
                    Console.WriteLine("Status         : " + (user.IsStatus ? "Active" : "Passive"));
                }
            }
            else
            {
                Console.WriteLine("User List Is Empty");
            }
        }

        public void Menu()
        {
            bool status = true;
            while (status)
            {
                Console.WriteLine("Select Proccess");
                Console.WriteLine("---------------");
                Console.WriteLine("Add User       (1)");
                Console.WriteLine("Detail User    (2)");
                Console.WriteLine("Delete User    (3)");
                Console.WriteLine("Update User    (4)");
                Console.WriteLine("User List      (5)");
                Console.WriteLine("Up Menu        (0)");
                Console.Write("Select: ");
                int select = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (select)
                {
                    case 1:
                        Add();
                        break;

                    case 2:
                        Get();
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
    }
}
