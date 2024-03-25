using System;
using System.Collections.Generic;
using System.Text;
using TESTE.Cep.Dominio.Entidades;

namespace TESTE.Cep.Dominio.Interfaces
{
    public interface IBase<T> where T : class
    {
        T Obter(string id);
        void SalvaAeroporto(PCModels obj);
    }
}
