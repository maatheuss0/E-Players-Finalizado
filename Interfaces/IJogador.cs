using System.Collections.Generic;
using E_Players_MVC.Models;

namespace E_Players_mvc_main.Interfaces
{
    public interface IJogador
    {
         void Criar(Jogador J);

         List<Jogador> LerTodos();

         void Alterar (Jogador J);

         void Deletar (int id);
    }
}