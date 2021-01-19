using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Ploomes
{
    public class Constantes
    {
        public string Site = "https://api2.ploomes.com/";
        public string Chave = "User-Key";
        public string Valor = "672BECF8BA3D2F99F78D5A4484F090A80815D582EB6096B39C06D908334BD4E478078AB30EE575D098151D7FA7A2548687FBE78A4F908963336B186FD12FAAA2";
        public string TipoRetorno = "application/json";
        public string topo = "#######################################################################################\n\n" +
        "------------------------------ CONSULTOR DE VENDAS ------------------------------------\n\n";
        public string[] dadoEtapa = new string[7]
        {
        "1 - Criar um cliente",
        "2 - Criar uma negociação com este cliente",
        "3 - Criar uma tarefa dentro desta negociação",
        "4 - Atualizar a negociação e atribuir o valor de R$ 15.000,00",
        "5 - Finalizar a tarefa",
        "6 - Ganhar a negociação",
        "7 - Escrever no histórico do cliente “Negócio fechado!”"
        };
    }
}
