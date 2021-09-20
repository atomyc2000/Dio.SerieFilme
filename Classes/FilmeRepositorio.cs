using System;
using System.Collections.Generic;
using Dio.SerieFilme.Interface;

namespace Dio.SerieFilme
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
        private List<Filme> listaFilme = new List<Filme>();

        public void Atualiza(int id, Filme objeto)
        {
            listaFilme[id] = objeto;
            //throw new NotImplementedException();
        }
        public void Exclui(int id)
        {
            listaFilme[id].excluir();
            //listaSerie.RemoveAt(id); //Muda o indice do vetor.
            //trow new NotImplementedException();
        }
        public void Insere(Filme objeto)
        {
            listaFilme.Add(objeto);
            //throw new NotImplementedException();
        }
        public List<Filme> Lista()
        {
            return listaFilme;
            //throw new NotImplementedException();
        }
        public int Proximo()
        {
            return listaFilme.Count;
            //throw new NotImplementedException();
        }
        public Filme RetornaPorId(int id)
        {
            return listaFilme[id];
            //throw new NotImplementedException();
        }
    }
}