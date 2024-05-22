using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuAvaliarMusica : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);

        
        ExibirTituloDaOpcao("Avaliar Música");
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Banda banda = bandasRegistradas[nomeDaBanda];
            Console.Write("Digite o nome do álbum que deseja avaliar: ");
            string tituloAlbum = Console.ReadLine()!;

            if(banda.Albuns.Any(a => a.Nome.Equals(tituloAlbum)))
            {
                Album album = banda.Albuns.First(a => a.Nome.Equals(tituloAlbum));
                Console.Write("Digite o nome da música que deseja avaliar: ");
                string titulomusica = Console.ReadLine()!;

                if(album.Musicas.Any(m => m.Equals(titulomusica)))
                {
                    Musica musica = album.Musicas.First(m => m.Equals(titulomusica));   
                    Console.Write($"Qual a nota que a música {titulomusica} merece: ");
                    Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
                    musica.AdicionarNota(nota);
                    Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para a música {titulomusica}");
                    Thread.Sleep(1000);
                    Console.Clear();
                } else
                {
                    Console.WriteLine($"\nA música {titulomusica} não foi encontrada!");
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Console.Clear();

                }

            }

        }
        
    }
}
