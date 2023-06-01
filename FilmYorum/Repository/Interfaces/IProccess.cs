using FilmYorum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmYorum.Proccess
{
    internal interface IProccess<T>
    {
        void Add();
        T SetValue();
        void Delete();
        void Update();
        T Get();
        void GetAll();
        void Menu();
        bool UserMenu(string mail);
    }
}
