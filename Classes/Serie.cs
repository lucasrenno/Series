using System;

namespace Series
{
    public class Serie : EntidadeBase
    {
        //atributos
        private Genero Genero {get; set;}

        private string Titulo {get; set;}
        
        private string Descricao {get; set;}

        private int Ano {get; set;}
        private bool Excluido {get; set;}

        //metodos
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {   
            string quebra = "\n";
            string retorno = "";
            retorno += $"Gênero: " + this.Genero + quebra;
            retorno += $"Titulo: " + this.Titulo + quebra;
            retorno += $"Descrição: " + this.Descricao + quebra;
            retorno += $"Ano de Início: " + this.Ano + quebra;
            retorno += $"Excluido: " + this.Excluido; 
            return retorno;
        }

        public string retornatitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}