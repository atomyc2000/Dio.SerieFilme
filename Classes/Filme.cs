using System;
using System.Collections;

namespace Dio.SerieFilme
{
    public class Filme : EntidadeBase
    {   
        private string Gravadora { set; get; }
        public Filme(int id, Genero genero, string titulo, int ano, string gravadora, string descricao)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Gravadora = gravadora;
            this.Excluido = false;
        }

        public override string ToString()
        {
            //Environment.NewLine http://docs.microsoft.com/en-us/dotnet/api/system.encironment.net
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Lançamento: " + this.Ano + Environment.NewLine;
            retorno += "Emisora: " + this.Gravadora + Environment.NewLine;
            retorno += "Excluir: " + this.Excluido;
            return retorno;
        }
        
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public void excluir()
        {
            this.Excluido = true;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
    }
}