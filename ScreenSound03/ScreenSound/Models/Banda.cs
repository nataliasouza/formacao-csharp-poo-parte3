using OpenAI_API;
using ScreenSound.Models.Interfaces;

namespace ScreenSound.Models;

internal class Banda : IAvaliacao
{
    private List<Album> albuns = new List<Album>();
    private List<Avaliacao> notas = new List<Avaliacao>();   

    public string Nome { get; }
    public string? Resumo { get; set; }
    public double Media 
    {
        get
        {
            if (notas.Count == 0) return 0;
            else return notas.Average(a => a.Nota);
        }
    }
    public IEnumerable<Album> Albuns => albuns;

    public Banda(string nome)
    {
        Nome = nome;
    }

    public void AdicionarAlbum(Album album) 
    { 
        albuns.Add(album);
    }

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia da banda {Nome}");
        foreach (Album album in Albuns)
        {
            Console.WriteLine($"Álbum: {album.Nome} (Duração: {album.DuracaoTotal})");
            album.ExibirMusicasDoAlbum();
        }
    }

    public void ExibirResumo(string nomeBanda)
    {
        var client = new OpenAIAPI("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");
        var chat = client.Chat.CreateConversation();
        chat.AppendSystemMessage($"Resuma a banda {nomeBanda} em 1 parágrafo. Adote um estilo informal.");
        string resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
        Resumo = resposta;
    } 
}