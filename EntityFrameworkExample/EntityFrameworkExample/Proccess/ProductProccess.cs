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
    internal class ProductProccess : IProccess<Product>
    {
        ProductRepository productRepository= new ProductRepository();


        public void Add()
        {
            Product product = SetValue();
            Console.WriteLine(productRepository.Add(product) ? "Add Is Successful" : "Add is Unuccessful");
        }
        public Product SetValue()
        {
            Product product = new Product();

            Console.Write("Product Name       : ");
            product.Name = Console.ReadLine();
            Console.Write("Product Description: ");
            product.Description = Console.ReadLine();
            Console.Write("Category ID        :");
            product.CategoryId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Product Price      :");
            product.Price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Product Stock      :");
            product.Stock = Convert.ToInt32(Console.ReadLine());
            Console.Write("Product Status Active(A) Passive(P):");
            product.IsStatus = Console.ReadLine().Substring(0, 1).ToLower() == "a" ? true : false;

            return product;
        }

        public void Delete()
        {

            Console.Write("Enter Deleted Product Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(productRepository.Delete(id) ? "Deletion Successful" : "Deletion Unsuccessful");
        }

        public Product Get()
        {
            Console.Write("Enter Detail Product Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Product product = productRepository.Get(id);
            if (product != null)
            {
                Console.WriteLine("Product Detail");
                Console.WriteLine("-------------");
                Console.WriteLine("Id         : " + product.Id);
                Console.WriteLine("Name       : " + product.Name);
                Console.WriteLine("Descriptin : " + product.Description);
                Console.WriteLine("CategoryId : " + product.CategoryId);
                Console.WriteLine("Price      : " + product.Price + " TL");
                Console.WriteLine("Stock      : " + product.Stock);
                Console.WriteLine("Status     : " + (product.IsStatus ? "Active" : "Passive"));
            }
            else
            {
                Console.WriteLine("Not Found Product");
            }
            return product;
        }

        public void GetAll()
        {
            Console.WriteLine("Product List");
            if (productRepository.GetAll().Count > 0)
            {
                foreach (var product in productRepository.GetAll())
                {
                    Console.WriteLine("-------------");
                    Console.WriteLine("Id         : " + product.Id);
                    Console.WriteLine("Name       : " + product.Name);
                    Console.WriteLine("Descriptin : " + product.Description);
                    Console.WriteLine("CategoryId : " + product.CategoryId);
                    Console.WriteLine("Price      : " + product.Price + " TL");
                    Console.WriteLine("Stock      : " + product.Stock);
                    Console.WriteLine("Status     : " + (product.IsStatus ? "Active" : "Passive"));
                }
            }
            else
            {
                Console.WriteLine("Product List Is Empty");
            }
        }

        public void Menu()
        {
            bool status = true;
            while (status)
            {
                Console.WriteLine("Select Proccess");
                Console.WriteLine("---------------");
                Console.WriteLine("Add Product    (1)");
                Console.WriteLine("Detail Product (2)");
                Console.WriteLine("Delete Product (3)");
                Console.WriteLine("Update Product (4)");
                Console.WriteLine("Product List   (5)");
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
            Product product = Get();

            if (product != null)
            {
                Product setProduct = SetValue();
                if (setProduct != null)
                {
                    setProduct.Id = product.Id;
                    product = setProduct;
                    productRepository.Update(product);
                }
            }
        }
    }
}