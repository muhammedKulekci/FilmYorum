using EntityFrameworkExample.DataSource;
using EntityFrameworkExample.Models;
using EntityFrameworkExample.Proccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            ProductProccess productProccess = new ProductProccess();
            CategoryProccess categoryProccess = new CategoryProccess();
            UserProccess userProccess = new UserProccess();
            RoleProccess roleProccess = new RoleProccess();

            bool status = true;
            while (status)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("-------LOGIN-------");
                Console.WriteLine("-------------------");

            //                Default User List
            //-------------
            //Id               : 1
            //Name             : admin
            //Surname          : admin
            //E - mail         : admin
            //Password         : admin
            //RoleId           : 1
            //Status           : Active
            //------------ -
            //Id               : 2
            //Name             : user
            //Surname          : user
            //E - mail         : user
            //Password         : user
            //RoleId           : 2
            //Status           : Active

                DataContext db = new DataContext();

                Console.WriteLine("E-mail     :");
                var mail = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Password   :");
                var password = Convert.ToString(Console.ReadLine());
                Console.Clear();

                var user = db.User.FirstOrDefault(x => x.Email == mail);

                bool status1 = true;

                while (status1) 
                {
                    if (user != null && password != null && user.Password == password && user.RoleId == 1 && user.IsStatus == true)
                    {
                        Console.WriteLine("Select Proccess");
                        Console.WriteLine("---------------");
                        Console.WriteLine("Product Proccess    (1)");
                        Console.WriteLine("Category Proccess   (2)");
                        Console.WriteLine("Role Proccess       (3)");
                        Console.WriteLine("User Proccess       (4)");
                        Console.WriteLine("Exit Admin          (0)");
                        Console.Write("Select: ");
                        int select = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        switch (select)
                        {
                            case 1:
                                productProccess.Menu();
                                break;

                            case 2:
                                categoryProccess.Menu();
                                break;

                            case 3:
                                roleProccess.Menu();
                                break;

                            case 4:
                                userProccess.Menu();
                                break;


                            case 0:
                                status1 = !status1;
                                break;
                            default:
                                Console.WriteLine("Undefined transaction, try again...");
                                break;
                        }
                    }
                    else if (user != null && password != null && user.Password == password && user.RoleId == 2 && user.IsStatus == true)
                    {
                        Console.WriteLine("Select Proccess");
                        Console.WriteLine("---------------");
                        Console.WriteLine("Product Proccess     (1)");
                        Console.WriteLine("Category Proccess    (2)");
                        Console.WriteLine("Exit User            (0)");
                        Console.Write("Select: ");
                        int select = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        switch (select)
                        {
                            case 1:
                                productProccess.Menu();
                                break;

                            case 2:
                                categoryProccess.Menu();
                                break;

                            case 0:
                                status1 = !status1;
                                break;
                            default:
                                Console.WriteLine("Undefined transaction, try again...");
                                break;
                        }
                    }
                    else if(mail=="çıkış" && password=="")
                    {
                        Console.WriteLine("Exiting...");
                        Console.ReadKey();
                        status1 = !status1;
                        status = !status;
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
}
