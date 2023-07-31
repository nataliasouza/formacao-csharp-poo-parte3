
using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuRegistrarBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = new Banda(nomeDaBanda);
        bandasRegistradas.Add(nomeDaBanda, banda);
        banda.ExibirResumo(nomeDaBanda);       

        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Console.Write("\nDigite uma tecla para votar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        Console.Clear();
    }
}
