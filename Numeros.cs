using System;
using System.Collections.Generic;
using System.Linq;

namespace F360
{
    public class Numeros
    {
        protected List<KeyValuePair<char, int>> indiceOrdemAlfabeto = new List<KeyValuePair<char, int>>();
        protected int quantidadeNumerosBonitos = 0;

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

        protected int NumeroBonitos(long somaPalavraConvertida)
        {
            // contador de palavras verificadas como Bonitas
            if ((somaPalavraConvertida >= 440566) && (somaPalavraConvertida % 3) == 0)
                quantidadeNumerosBonitos++;

            return quantidadeNumerosBonitos;
        }

        public String ConversorPalavraNumero(String mensagem)
        {
            // inicializador
            OrdemAlfabeto();
            long somaPalavraConvertida = 0;
            List<String> mensagemPalavras = mensagem.Split(' ').ToList();

            foreach (String palavra in mensagemPalavras)
            {
                char[] letras = palavra.ToCharArray();
                for (int indicePalavra = 0; indicePalavra < letras.Length; indicePalavra++)
                {
                    int valorIndiceLetra = ValorIndiceLetra(letras[indicePalavra]);
                    if (valorIndiceLetra != -1)
                        // converte a palavra em número
                        somaPalavraConvertida += (valorIndiceLetra * (long)Math.Pow(20, indicePalavra));
                }

                //Console.WriteLine($"** Soma da palavra: {palavra}, em número é: {somaPalavraConvertida}");

                quantidadeNumerosBonitos = NumeroBonitos(somaPalavraConvertida);

                somaPalavraConvertida = 0;
            }

            return $"Quantidade de números bonitos: {quantidadeNumerosBonitos}";
        }
    }
}
