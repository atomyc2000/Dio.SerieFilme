using System;
using System.Collections.Generic;
using Dio.SerieFilme.Interface;

namespace Dio.SerieFilme
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
            //throw new NotImplementedException();
        }
        public void Exclui(int id)
        {
            listaSerie[id].excluir();
            //listaSerie.RemoveAt(id); //Muda o indice do vetor.
            //trow new NotImplementedException();
        }
        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
            //throw new NotImplementedException();
        }
        public List<Serie> Lista()
        {
            return listaSerie;
            //throw new NotImplementedException();
        }
        public int Proximo()
        {
            return listaSerie.Count;
            //throw new NotImplementedException();
        }
        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
            //throw new NotImplementedException();
        }
    }
}