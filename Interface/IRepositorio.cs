using System;
using System.Collections.Generic;

namespace Dio.SerieFilme.Interface
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T RetornaPorId(int id);
         void Insere(T entidade);
         void Exclui(int id);
         void Atualiza (int id, T entidade);
         int Proximo();
    }
}