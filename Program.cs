using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace F360
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage mensagem = await client.GetAsync("https://raw.githubusercontent.com/financas360/provas/master/klingon-textoA.txt");
            string resposta = await mensagem.Content.ReadAsStringAsync();
            
            // Console.WriteLine(countPreposicao);
            Vocabulario vocabulario = new Vocabulario();
            vocabulario.OrdenaListaLexica(resposta);
        }
    }
}
