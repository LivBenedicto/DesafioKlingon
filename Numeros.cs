using System;
using System.Collections.Generic;
using System.Linq;

namespace F360
{
    public class Numeros
    {
        public String NumerosBonitos(string mensagem)
        {
            int quantidadeNumerosBonitos = 0;
            int numero = 0; // numero que será calculado e analisado
            int count = -1; // contador de posição do alfabeto
            char[] letraPalavra; // guarda as letras da palavra
            List<char> ordemAlfabeto = new List<char>() { 'k', 'b', 'w', 'r', 'q', 'd', 'n', 'f', 'x', 'j', 'm', 'l', 'v', 'h', 't', 'c', 'g', 'z', 'p', 's' };
            List<KeyValuePair<string, int>> indexLetras = new List<KeyValuePair<string, int>>(); // guarda o peso das letras
            List<string> listaOrdenada = mensagem.Split(' ').ToList(); // transforma a string em char para avaliar as letras individualmente

            // atribui um peso para cada letra do alfabeto de acordo com o contador de posição
            foreach (char item in ordemAlfabeto)
            {
                count++;
                indexLetras.Add(new KeyValuePair<string, int>(item.ToString(), count));
                //Console.WriteLine(indexLetras[count]);
            }

            // percorre a lista de palavras, para fazer a conta e verificação
            foreach (var palavra in listaOrdenada)
            {
                // transforma palavras em letras
                letraPalavra = palavra.ToCharArray();

                // percorre a palavra transformando as letras em valor
                letraPalavra.ToList().ForEach(letra =>
                  {
                      foreach (KeyValuePair<string, int> letraKey in indexLetras)
                      {
                          // retorna o valor do peso da letra do alfabeto correspondente a letra da palavra
                          if (letraKey.Key.Contains(letra)) // from keyvaluepair
                          {
                              numero = letraKey.Value;

                              // descobrir o número correspondete a palavra
                              ///     espaço para a formula

                              // verifica se a palavra é bonita
                              if (numero >= 440566 && (numero / 3) == 0)
                                  quantidadeNumerosBonitos++;
                          }
                      }
                  });
            }

            return $"Quantidade de números bonitos: {quantidadeNumerosBonitos}";
        }
    }
}
