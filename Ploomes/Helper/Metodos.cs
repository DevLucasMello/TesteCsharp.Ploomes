using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Ploomes
{
    public class Metodos
    {
        Constantes constante = new Constantes();
        public void TelaInicial()
        {
            Console.WriteLine(constante.topo + "ETAPAS TESTE PRÁTICO C#:\n");
            for (var i = 0; i < 7; i++)
            {
                Console.WriteLine(constante.dadoEtapa[i]);
            }
        }

        public void Etapas(int etapa)
        {
            Console.Clear();
            Console.WriteLine(constante.topo);
            Console.WriteLine(constante.dadoEtapa[etapa] + "\n");
        }

        public Contacts ColetaDados()
        {
            var contato = new Contacts();
            Console.Write("Digite um nome: ");
            contato.Name = Console.ReadLine();
            Console.Write("Digite um Email: ");
            contato.Email = Console.ReadLine();
            Console.Write("Digite um Endereço: ");
            contato.StreetAddress = Console.ReadLine();
            Console.Write("Digite um Bairro: ");
            contato.Neighborhood = Console.ReadLine();

            return contato;
        }

        public void Pergunta()
        {
            string resp = "";
            do
            {
                Console.WriteLine("");
                Console.Write("Digite S - Continuar ou N - Sair: ");
                resp = Console.ReadLine().ToUpper();

            } while (resp != "S" && resp != "N");
            if (resp == "N")
            {
                Environment.Exit(0);
            }
        }
    }
}
