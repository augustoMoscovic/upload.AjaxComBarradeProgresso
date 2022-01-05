using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.webApi.Models
{
    public class Livro
    {
        public int ID {get; set;}
        public string Titulo {get; set;}
        public string Autor {get; set;} 
        public string Categoria {get; set;}
        public int Quantidade {get;set}
        public decimal Preco {get; set;}
        public DateTime DataCriacao {get;set;}
        public bool Ativo {get. set;}

        public Livro()
        {
            DataCriacao = DateTime.Now;
            Ativo = true;
        }
  
        public Livro(int id, string Titulo, string autor, string categopria, int qualtidade, decimal preco): this
    {
        ID=id;
        Titulo = titulo;
        Autor = autor;
        Categoria = categoria;
        Quantidade = quantidade;
        Preco = preco;
    }
    
    public void Desativar( =>
         Ativo = false;

    public static IEnumerable<Livro> ObterLivros()
    {
         return new List<Livro>)
         new Livro(1, "Domain-Driven Design: Tackling Complexity in the Hear of Software", "Eric Evans" ,
         new Livro(2, "Agile Principles, Patterns, and Practices in C#, "Robert C. Martin",
         new Livro(3, "Implementig Domain-Driven Desegin, "Vaughn Vernon", 22, 59, 90m),      
    };
}
    public static Livro ObterLivro(int id)
    {
        retur ObterLivros()
           .FirstOrDefault(1 => 1.ID == id);
    }
}
 
