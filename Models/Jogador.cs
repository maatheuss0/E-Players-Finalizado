using System.Collections.Generic;
using System.IO;
using E_Players_mvc_main.Interfaces;

namespace E_Players_MVC.Models
{
    public class Jogador : EPlayersBase, IJogador
    {
        public Jogador(int idJogador, string nome, int idEquipe, string email, string senha)
        {
            this.IdJogador = idJogador;
            this.Nome = nome;
            this.IdEquipe = idEquipe;
            this.Email = email;
            this.Senha = senha;

        }
        public int IdJogador { get; set; }
        public string Nome { get; set; }
        public int IdEquipe { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        private const string CAMINHO = "Database/Jogador.csv";

        public Jogador()
        {
            CriarPastaEArquivo(CAMINHO);
        }
        private string PrepararLinha(Jogador j)
        {
            return $"{j.IdJogador}; {j.Nome}; {j.IdEquipe}; {j.Email}; {j.Senha}";
        }


        public void Criar(Jogador J)
        {
            string[] linha = { PrepararLinha(J) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public List<Jogador> LerTodos()
        {
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Jogador novojogador = new Jogador();
                novojogador.IdJogador = int.Parse(linha[0]);
                novojogador.Nome = linha[1];
                novojogador.IdEquipe = int.Parse(linha[2]);
                novojogador.Email = linha[3];
                novojogador.Senha = linha[4];

                jogadores.Add(novojogador);

            }
            return jogadores;
        }

        public void Alterar(Jogador j)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
            linhas.Add(PrepararLinha(j));
            ReescreverCSV(CAMINHO, linhas);

        }

        public void Deletar(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            // 1;FLA;fla.png
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            ReescreverCSV(CAMINHO, linhas);
        }
    }
}