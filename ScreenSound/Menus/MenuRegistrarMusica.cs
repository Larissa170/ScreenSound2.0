

using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuRegistrarMusica : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro de músicas");
        Console.Write("Digite a banda cujo a música deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Banda banda = bandasRegistradas[nomeDaBanda];
            Console.Write("Agora digite o título do álbum: ");
            string tituloAlbum = Console.ReadLine()!;

            if (banda.Albuns.Any(a => a.Nome.Equals(tituloAlbum))){

                Album album = banda.Albuns.First(a => a.Nome.Equals(tituloAlbum));
                Console.Write("Agora digite o título da música: ");
                string tituloMusica = Console.ReadLine()!;

                album.AdicionarMusica(new Musica(bandasRegistradas[nomeDaBanda], tituloMusica));

           
                Console.WriteLine($"A música {tituloMusica} do álbum {tituloAlbum} de {nomeDaBanda} foi registrada com sucesso!");
                Thread.Sleep(2000);
                Console.Clear();

            }


        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }


    }
}
