using ScreenSound.Menus;
using ScreenSound.Models;

#region "Bandas, Albúns e Musicas"

Banda bandaGunsNRoses = new Banda("Guns in Roses");
Album albumDoGunsInRoses = new Album("Use your ilusion I");

Musica musicaNovemberRain = new Musica(bandaGunsNRoses, "November Rain")
{
    Duracao = 538,
    Disponivel = true,
};

Musica musicaLiveAndLetDie = new Musica(bandaGunsNRoses, "Live and Let Die")
{
    Duracao = 184,
    Disponivel = false,
};


bandaGunsNRoses.AdicionarAlbum(albumDoGunsInRoses);
albumDoGunsInRoses.AdicionarMusica(musicaNovemberRain);
albumDoGunsInRoses.AdicionarMusica(musicaLiveAndLetDie);

bandaGunsNRoses.AdicionarNota(new Avaliacao(10));
bandaGunsNRoses.AdicionarNota(new Avaliacao(8));
bandaGunsNRoses.AdicionarNota(new Avaliacao(9));

albumDoGunsInRoses.AdicionarNota(new Avaliacao(7));
albumDoGunsInRoses.AdicionarNota(new Avaliacao(9));

Banda bandaU2 = new Banda ("U2");
Album albumU2 = new Album("All That You Can't Leave Behind");

Musica musicaElevation = new Musica(bandaU2, "Elevation")
{
    Duracao = 421,
    Disponivel = true,
};

Musica musicaBeautifulDay = new Musica(bandaU2, "Beautiful Day")
{
    Duracao = 398,
    Disponivel = false,
};

bandaU2.AdicionarAlbum(albumU2);
albumU2.AdicionarMusica(musicaBeautifulDay);
albumU2.AdicionarMusica(musicaElevation);

bandaU2.AdicionarNota(new Avaliacao(10));
bandaU2.AdicionarNota(new Avaliacao(7));
bandaU2.AdicionarNota(new Avaliacao(7));

albumU2.AdicionarNota(new Avaliacao(8));

#endregion 

Dictionary<string, Banda> bandasRegistradas = new();
bandasRegistradas.Add(bandaGunsNRoses.Nome, bandaGunsNRoses);
bandasRegistradas.Add(bandaU2.Nome, bandaU2);

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