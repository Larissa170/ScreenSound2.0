using OpenAI_API;
using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuRegistrarBanda : Menu
{
    public override void Executar(Dictionary<string,Banda>bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = new(nomeDaBanda);
        bandasRegistradas.Add(nomeDaBanda, banda);

        //var client = new OpenAIAPI("");// chave do openapi
        //var chat = client.Chat.CreateConversation();
        //chat.AppendSystemMessage("$Resuma a banda {nomeDaBanda} em um paragrafo de forma informal.");
        //string resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
        //banda.Resumo = resposta;

        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Thread.Sleep(1000);
        Console.Clear();
       
    }
}
