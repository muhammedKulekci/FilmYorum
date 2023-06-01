using FilmYorum.DataSource;
using FilmYorum.Models;
using FilmYorum.Proccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FilmYorum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HomeProccess homeProccess = new HomeProccess();
            homeProccess.Home();
        }

        
    }
}
