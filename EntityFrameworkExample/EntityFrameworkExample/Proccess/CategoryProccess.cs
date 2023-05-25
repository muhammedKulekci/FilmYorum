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
    internal class CategoryProccess : IProccess<Category>
    {

        CategoryRepository categoryRepository = new CategoryRepository();

        public void Add()
        {
            Console.WriteLine(
                categoryRepository.Add(SetValue()) ?
                "Add Is Successful" :
                "Add Is Unsuccessful");
        }
        public Category SetValue()
        {
            Category category = new Category();

            Console.Write("Category Name       : ");
            category.Name = Console.ReadLine();
            Console.Write("Category Status Active(A) Passive(P):");
            category.IsStatus = Console.ReadLine().Substring(0, 1).ToLower() == "a" ? true : false;

            return category;
        }

        public void Delete()
        {

            Console.Write("Enter Deleted Category Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(categoryRepository.Delete(id) ? "Deletion Successful" : "Deletion Unsuccessful");
        }

        public Category Get()
        {
            Console.Write("Enter Detail Category Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Category category = categoryRepository.Get(id);
            if (category != null)
            {
                Console.WriteLine("Category Detail");
                Console.WriteLine("-------------");
                Console.WriteLine("Id         : " + category.Id);
                Console.WriteLine("Name       : " + category.Name);
                Console.WriteLine("Status     : " + (category.IsStatus ? "Active" : "Passive"));
            }
            else
            {
                Console.WriteLine("Not Found Category");
            }
            return category;
        }

        public void GetAll()
        {
            Console.WriteLine("Category List");
            if (categoryRepository.GetAll().Count > 0)
            {
                foreach (var category in categoryRepository.GetAll())
                {
                    Console.WriteLine("-------------");
                    Console.WriteLine("Id         : " + category.Id);
                    Console.WriteLine("Name       : " + category.Name);
                    Console.WriteLine("Status     : " + (category.IsStatus ? "Active" : "Passive"));
                }
            }
            else
            {
                Console.WriteLine("Category List Is Empty");
            }
        }

        public void Menu()
        {
            bool status = true;
            while (status)
            {
                Console.WriteLine("Select Proccess");
                Console.WriteLine("---------------");
                Console.WriteLine("Add Category    (1)");
                Console.WriteLine("Detail Category (2)");
                Console.WriteLine("Delete Category (3)");
                Console.WriteLine("Update Category (4)");
                Console.WriteLine("Category List   (5)");
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

        public void Update()
        {
            Category category = Get();

            if (category != null)
            {
                Category setCategory = SetValue();
                if (setCategory != null)
                {
                    setCategory.Id = category.Id;
                    category = setCategory;
                    categoryRepository.Update(category);
                }
            }
        }
    }
}
