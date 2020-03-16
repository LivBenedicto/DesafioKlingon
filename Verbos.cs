/*
Verbos:
    * contenham 8 ou mais letras
    * terminam numa letra tipo foo.
    * primeira pessoa: verbo que comece com uma letra tipo bar.

Texto A: 26 verbos, onde, 23 estão em primeira pessoa.
*/

using System.Text.RegularExpressions;

namespace F360
{
    class Verbos
    {
        private string ContadorVerbos(string mensagem)
        {
            int counterVerbos = 0;

            foreach (string verbo in mensagem.Split(' '))
            {
                bool match = Regex.IsMatch(verbo, @"^\w{7,}[slfwk]$");
                if (match)
                    counterVerbos++;
            }

            return $"Quantidade de verbos: {counterVerbos}";
        }

        private string ContadorVerbosPrimeiraPessoa (string mensagem) 
        {
            int counterVerbosPrimeiraPessoa = 0;

            foreach (string verboPrimeiraPessoa in mensagem.Split(' '))
            {
                bool match = Regex.IsMatch(verboPrimeiraPessoa, @"^[^slfwk]\w{6,}[slfwk]$");
                if (match)
                    counterVerbosPrimeiraPessoa++;
            }

            return $"Quantidade de verbos em primeira pessoa: {counterVerbosPrimeiraPessoa}";
        }
    }
}