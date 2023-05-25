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
    internal class RoleProccess : IProccess<Role>
    {
        RoleRepository roleRepository = new RoleRepository();
        public void Add()
        {
            Console.WriteLine(
                roleRepository.Add(SetValue()) ?
                "Add is Successful" :
                "Add is Unsuccessful");
        }

        public void Delete()
        {
            Console.Write("Enter Deleted Category Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(roleRepository.Delete(id) ? "Deletion Successful  " : "deletion Unsuccessful  ");
        }

        public Role Get()
        {
            Console.Write("Enter Detail Category Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Role role = roleRepository.Get(id);
            if (role != null)
            {
                Console.WriteLine("Category Detail");
                Console.WriteLine("-------------");
                Console.WriteLine("Id         : " + role.Id);
                Console.WriteLine("Name       : " + role.Name);
                Console.WriteLine("Status     : " + (role.IsStatus ? "Active" : "Passive"));
            }
            else
            {
                Console.WriteLine("Not Found Role");
            }
            return role;
        }

        public void GetAll()
        {
            Console.WriteLine("Role List");
            if (roleRepository.GetAll().Count > 0)
            {
                foreach (var role in roleRepository.GetAll())
                {
                    Console.WriteLine("-------------");
                    Console.WriteLine("Id         : " + role.Id);
                    Console.WriteLine("Name       : " + role.Name);
                    Console.WriteLine("Status     : " + (role.IsStatus ? "Active" : "Passive"));
                }
            }
            else
            {
                Console.WriteLine("Role List Is Empty");
            }
        }

        public void Menu()
        {
            bool status = true;
            while (status)
            {
                Console.WriteLine("Select Proccess");
                Console.WriteLine("---------------");
                Console.WriteLine("Add Role        (1)");
                Console.WriteLine("Detail Role     (2)");
                Console.WriteLine("Delete Role     (3)");
                Console.WriteLine("Update Role     (4)");
                Console.WriteLine("Role List       (5)");
                Console.WriteLine("Up Menu         (0)");
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

        public Role SetValue()
        {
            Role role = new Role();

            Console.Write("Role Name       : ");
            role.Name = Console.ReadLine();
            Console.Write("Role Status Active(A) Passive(P):");
            role.IsStatus = Console.ReadLine().Substring(0, 1).ToLower() == "a" ? true : false;

            return role;
        }

        public void Update()
        {
            Role role = Get();

            if (role != null)
            {
                Role setRole = SetValue();
                if (setRole != null)
                {
                    setRole.Id = role.Id;
                    role = setRole;
                    roleRepository.Update(role);
                }
            }
        }
    }
}
