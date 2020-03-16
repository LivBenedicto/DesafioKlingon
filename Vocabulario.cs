/*
Lista ordenada de vocabulário:
    * não podem conter repetições de palavras.
    * as palavras ordenadas lexicograficamente (dicionario).
    * respeitar a ordem alfabética Klingon.

Ordem do alfabeto Klingon: kbwrqdnfxjmlvhtcgzps. 
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace F360
{
    public class Vocabulario
    {
        public List<string> OrdenaListaLexica(string mensagem)
        {
            List<string> OrdemAlfabeto = new List<string> { "k", "b", "w", "r", "q", "d", "n", "f", "x", "j", "m", "l", "v", "h", "t", "c", "g", "z", "p", "s" };
            List<string> listaDesordenadaLexica = mensagem.Split(' ').ToList(); // transforma a string em char para avaliar as letras individualmente

            // listaOrdenada = listaOrdenada.OrderBy(p => p.Length).ToList();
            // List<string> listaAuxiliar = listaOrdenadaLexica.OrderBy(palavra => palavra.Length).ThenBy(palavra => palavra);
            // IEnumerable<string> letrasPalavra = palavra.Select(p => p.ToString());

            List<string> listaOrdenadaLexica = listaDesordenadaLexica.OrderBy(x => OrdemAlfabeto.IndexOf(x)).ToList();

            return listaOrdenadaLexica;
        }

    }
}