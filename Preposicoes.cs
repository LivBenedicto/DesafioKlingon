/*
Preposicoes:
    * contenham 3 letras
    * terminam numa letra tipo bar\
    * não podem ter ocorrências da letra d.
Texto A: 63 preposições
*/

using System.Text.RegularExpressions;

namespace F360
{
    public class Preposicoes
    {
        public string ContarPreposicoes(string resposta)
        {
            int countPreposicao = 0;

            foreach (string palavra in resposta.Split(' '))
            {
                bool match = Regex.IsMatch(palavra, @"^[^d]{2}[^dslfwk]$");
                if (match)
                    countPreposicao++;
            }

            return $"Quantidade de preposições: {countPreposicao}";
        }
    }
}