using System;
using System.Collections.Generic;
using System.Text;

namespace TESTE.Cep.Dominio.Interfaces
{
    public interface IBaseCrud<T> where T : class
    {
        T Cadastrar(T obj);
        T Alterar(T obj);
        List<T> Obter();
        T Listar(string id);
        void Deletar(T obj);
    }
}
