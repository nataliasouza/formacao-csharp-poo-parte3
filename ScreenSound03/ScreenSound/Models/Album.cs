using ScreenSound.Models.Interfaces;

namespace ScreenSound.Models;

internal class Album : IAvaliacao
{
    private List<Musica> musicas = new List<Musica>();
    private List<Avaliacao> notas = new();

    public double Media
    {
        get
        {
            if (notas.Count == 0) return 0;
            else return notas.Average(a => a.Nota);
        }
    }
    public string Nome { get; }
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);
    public List<Musica> Musicas => musicas;    

    public Album(string nome)
    {
        Nome = nome;
    }

    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }

    public void ExibirMusicasDoAlbum()
    {
        Console.WriteLine($"\n\tLista de músicas do álbum {Nome}:\n");
        foreach (var musica in musicas)
        {
            Console.WriteLine($"\tMúsica: {musica.Nome}");
        }
        Console.WriteLine($"\nPara ouvir este álbum inteiro você precisa de {DuracaoTotal}.\n");
    }

    public static void ExibirDadosDoAlbum(Dictionary<string, Banda> bandasRegistradas)
    {
        Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Banda banda = bandasRegistradas[nomeDaBanda];
            banda.ExibirResumo(nomeDaBanda);
            Console.WriteLine($"\n{banda.Resumo}");
            Console.WriteLine($"\nA média da banda {nomeDaBanda} é {banda.Media}.\n");
            banda.ExibirDiscografia();
            foreach (Album album in banda.Albuns)
            {
                Console.WriteLine($"Albúm Nome: {album.Nome} - Avaliação: {album.Media}");                
            }

            Console.Write("\nDigite uma tecla para votar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.Write("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}