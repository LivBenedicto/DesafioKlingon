using System;
using System.Collections.Generic;
using System.Linq;

namespace F360
{
    public class Vocabulario
    {
        protected List<KeyValuePair<char, int>> indiceOrdemAlfabeto = new List<KeyValuePair<char, int>>();
        protected List<KeyValuePair<String, List<int>>> listaPalavrasValores = new List<KeyValuePair<String, List<int>>>();
        protected int quantidadeLetrasPalavra;

        protected void OrdemAlfabeto()
        {
            List<char> ordemAlfabeto = new List<char>() { 'k', 'b', 'w', 'r', 'q', 'd', 'n', 'f', 'x', 'j', 'm', 'l', 'v', 'h', 't', 'c', 'g', 'z', 'p', 's' };
            int count = -1; //contador de posições das letras

            // atribui um peso para cada letra do alfabeto de acordo com o contador
            foreach (char item in ordemAlfabeto)
            {
                count++;
                indiceOrdemAlfabeto.Add(new KeyValuePair<char, int>(item, count));
            }
        }

        protected int ValorIndiceLetra(char letra)
        {
            // retorna o valor da letra através do indíce do alfabeto Klingon
            foreach (KeyValuePair<char, int> letraAlfabeto in indiceOrdemAlfabeto)
                if (letra == letraAlfabeto.Key)
                    return letraAlfabeto.Value;

            return -1;
        }

        protected void VerificarTamanhoPalavra(List<String> palavras)
        {
            // descobrir a maior palavra dentro da mensagem, condição de parada para o indíce da letra
            foreach (String palavra in palavras)
            {
                if (quantidadeLetrasPalavra < palavra.Length)
                    quantidadeLetrasPalavra = palavra.Length;
            }
        }

        protected void ListaValoresIndice(String palavra)
        {
            List<int> listaValoresIndiceLetra = new List<int>();

            // atribui todos os valores correspondentes as letras da palavra
            if (!listaPalavrasValores.Exists(palavraLista => palavraLista.Key.Equals(palavra)))
            {
                char[] letras = palavra.ToCharArray();

                for (int indicePalavra = 0; indicePalavra < letras.Length; indicePalavra++)
                {
                    int valorIndiceLetra = ValorIndiceLetra(letras[indicePalavra]);
                    if (valorIndiceLetra != -1)
                        listaValoresIndiceLetra.Add(valorIndiceLetra);
                }

                listaPalavrasValores.Add(new KeyValuePair<String, List<int>>(palavra, new List<int>(listaValoresIndiceLetra)));
            }
        }
        
        /*
        protected String ImprimiListaOrdenada()
        {
            Console.WriteLine("Lista Ordenada:");

            foreach (KeyValuePair<String, List<int>> palavra in listaOrdenadaPalavras)
            {
                Console.Write($"{palavra.Key} ");
                return "Fim lsita ordenada!";
            }
            return null;
        }*/

        public void OrdenaPalavras(String mensagem)
        {
            //inicializador
            OrdemAlfabeto();
            List<String> mensagemPalavras = mensagem.Split(' ').ToList();
            VerificarTamanhoPalavra(mensagemPalavras);
            int counterPosicaoLetra = 0;
            List<KeyValuePair<String, List<int>>> listaOrdenadaPalavras = new List<KeyValuePair<string, List<int>>>();

            // lista de valores das letras da palavra
            foreach (String palavra in mensagemPalavras)
                ListaValoresIndice(palavra);


            listaOrdenadaPalavras = listaPalavrasValores.OrderBy(palavraLista => palavraLista.Value[counterPosicaoLetra]).ToList();

            //return ImprimiListaOrdenada();
            Console.WriteLine("Lista Ordenada: ");

            foreach (KeyValuePair<String, List<int>> palavra in listaOrdenadaPalavras)
                Console.Write($"{palavra.Key} ");

            Console.WriteLine("Fim Lista Ordenada");
        }
    }
}