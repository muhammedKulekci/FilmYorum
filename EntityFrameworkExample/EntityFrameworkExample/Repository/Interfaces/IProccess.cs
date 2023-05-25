using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Repository.Interfaces
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

    }
}
