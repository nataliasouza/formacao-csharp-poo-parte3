using ScreenSound.Menus;
using ScreenSound.Models;

Banda ira = new Banda ("Ira");
ira.AdicionarNota(new Avaliacao(9));
ira.AdicionarNota(new Avaliacao(7));
ira.AdicionarNota(new Avaliacao(9));

Banda u2 = new Banda ("U2");

Dictionary<string, Banda> bandasRegistradas = new();
bandasRegistradas.Add(ira.Nome, ira);
bandasRegistradas.Add(u2.Nome, u2);

Dictionary<int, Menu> opcoesMenu = new();
opcoesMenu.Add(1, new MenuRegistrarBanda());
opcoesMenu.Add(2, new MenuRegistrarAlbum());
opcoesMenu.Add(3, new MenuMostrarBandasRegistradas());
opcoesMenu.Add(4, new MenuAvaliarBanda());
opcoesMenu.Add(5, new MenuAvaliarAlbum());
opcoesMenu.Add(6, new MenuExibirDetalhes());
opcoesMenu.Add(-1, new MenuSair());

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
    Console.WriteLine("Digite 3 para mostrar todas as bandas");
    Console.WriteLine("Digite 4 para avaliar uma banda");
    Console.WriteLine("Digite 5 para avaliar um álbum");
    Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcoesMenu.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menuOpcaoEscolhida = opcoesMenu[opcaoEscolhidaNumerica];
        menuOpcaoEscolhida.Executar(bandasRegistradas);
        
        if(opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();

    }else
    {
        Console.WriteLine("Opção inválida");
    }    
}

ExibirOpcoesDoMenu();