using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmYorum.Proccess
{
    internal class HomeProccess
    {
        public void Home()
        {
            LoginProccess loginProccess = new LoginProccess();
            RegisterProccess registerProccess = new RegisterProccess();


            bool status = true;
            while (status)
            {

                Console.WriteLine("-----------------------");
                Console.WriteLine("----Login / Register---");
                Console.WriteLine("-----------------------");
                Console.WriteLine("\nİşlem Seçiniz");
                Console.WriteLine("\nLogin            (1)");
                Console.WriteLine("\nRegister         (2)");
                Console.Write("\nİşlem : ");
                int select = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (select)
                {
                    case 1:
                        loginProccess.Login();
                        break;
                    case 2:
                        registerProccess.Register();
                        break;

                }
            }
        }
    }
}
