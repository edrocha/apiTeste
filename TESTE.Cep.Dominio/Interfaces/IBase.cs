using System;
using System.Collections.Generic;
using System.Text;

namespace TESTE.Cep.Dominio.Interfaces
{
    public interface IBase<T> where T : class
    {
        T Obter(string id);
    }
}
