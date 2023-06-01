using FilmYorum.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmYorum.Proccess
{
    internal class RegisterProccess
    {
        public void Register() 
        {
            UserProccess userProccess = new UserProccess();

            
            
            Console.WriteLine("-----------------------");
            Console.WriteLine("--------Register-------");
            Console.WriteLine("-----------------------\n");
            
            
            userProccess.Add();
            Console.ReadKey();
            Console.Clear();
            

        }
    }
}
