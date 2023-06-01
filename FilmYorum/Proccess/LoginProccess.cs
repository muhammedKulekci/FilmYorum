using FilmYorum.DataSource;
using FilmYorum.Models;
using FilmYorum.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmYorum.Proccess
{
    internal class LoginProccess
    {
        UserRepository userRepository = new UserRepository();
        FilmProccess filmProccess = new FilmProccess();
        UserProccess userProccess = new UserProccess();
        public void Login()
        {
            bool status1 = true;
            while (status1)
            {


                Console.WriteLine("-----------------------");
                Console.WriteLine("---------LOGIN---------");
                Console.WriteLine("-----------------------");
                Console.Write("\nE-mail     :");
                var mail = Convert.ToString(Console.ReadLine());
                Console.Write("\nPassword   :");
                var password = Convert.ToString(Console.ReadLine());
                Console.Clear();

                User user = userRepository.Login(mail);                
                if (user != null && password != null && user.Password == password && user.Role==Roles.admin.ToString().ToLower() && user.IsStatus == true)
                {
                    bool status3=true;
                    while (status3)
                    {
                        Console.WriteLine("----Select Proccess----");
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("\nFilm Proccess     (1)");
                        Console.WriteLine("\nAdmin Proccess    (2)");
                        Console.WriteLine("\nExit Admin        (0)");
                        Console.Write("Select: ");
                        int adminSelect = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        switch (adminSelect)
                        {
                            case 1:
                                filmProccess.Menu();
                                break;

                            case 2:
                                userProccess.AdminMenu(mail);
                                break;

                            case 0:

                                status3 = !status3;
                                break;
                            default:
                                Console.WriteLine("Undefined transaction, try again...");
                                Console.ReadKey();
                                break;
                        }
                    }
                    
                }
                else if (user != null && password != null && user.Password == password && user.Role == Roles.user.ToString().ToLower() && user.IsStatus == true)
                {
                    bool status = true;
                    while (status)
                    {
                        Console.WriteLine("----Select Proccess----");
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("\nFilm List         (1)");
                        Console.WriteLine("\nUser Proccess     (2)");
                        Console.WriteLine("\nExit User         (0)");
                        Console.Write("Select: ");
                        int adminSelect = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        switch (adminSelect)
                        {
                            case 1:
                                filmProccess.GetAll();
                                break;

                            case 2:
                                userProccess.UserMenu(mail);                               
                                break;

                            case 0:
                                
                                status =!status;
                                break;
                            default:
                                Console.WriteLine("Undefined transaction, try again...");
                                Console.ReadKey();
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Mail or Password Is False!");
                    status1 = !status1;
                    Console.ReadKey();
                    Console.Clear();

                }
            }
            
        }
    }
}
