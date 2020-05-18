using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace F360
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            // mensagem A
            // HttpResponseMessage mensagem = await client.GetAsync("https://raw.githubusercontent.com/financas360/provas/master/klingon-textoA.txt");
            
            // mensagem B
            HttpResponseMessage mensagem = await client.GetAsync("https://raw.githubusercontent.com/financas360/provas/master/klingon-textoB.txt");
            string resposta = await mensagem.Content.ReadAsStringAsync();
            
            Preposicoes preposicoes = new Preposicoes();
            Console.WriteLine(preposicoes.ContarPreposicoes(resposta));

            Verbos verbos = new Verbos();
            Console.WriteLine(verbos.ContadorVerbos(resposta));
            Console.WriteLine(verbos.ContadorVerbosPrimeiraPessoa(resposta));

            Numeros numero = new Numeros();
            Console.WriteLine(numero.ConversorPalavraNumero(resposta));
        }
    }
}
