using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Ploomes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Criando Instâncias de Classes
            var contato = new Contacts();
            var metodos = new Metodos();

            //Cabeçalho da tela
            metodos.TelaInicial();
            metodos.Pergunta();
            metodos.Etapas(0);

            //Coletando os dados para cadastrar o contact
            contato = metodos.ColetaDados();

            //Coletando os parâmetros para chamada da API
            var textos = new Textos()
            {
                Url = "/Contacts",
                MessageSuccess = "\n\nCliente incluído com sucesso!!!\n\nPrecione qualquer tecla para continuar...",
                MessageError = "\n\nFalha ao incluir cliente",
                Email = contato.Email,
                NumeroConsulta = 1
            };

            //Cadastrando o Contact
            Helper.Post(contato, textos).Wait();
            Console.ReadKey();

            //Consultando o Id do contact incluído
            var idContact = Helper.Get(textos).Result;

            //Coletando os parâmetros para chamada da API
            textos = new Textos()
            {
                Url = "/Deals",
                MessageSuccess = "\n\nNegócio incluído com sucesso!!!\n\nPrecione qualquer tecla para continuar...",
                MessageError = "\n\nFalha ao incluir negócio"
            };

            //Atribuindo o Id do contact incluído
            var deal = new Deals() { ContactId = idContact };

            //Cabeçalho da tela
            metodos.Etapas(1);
            metodos.Pergunta();

            //Cadastrando a Deal
            Helper.Post(deal, textos).Wait();
            Console.ReadKey();

            //Coletando os parâmetros para chamada da API
            textos = new Textos()
            {
                Url = "/Deals",
                NumeroConsulta = 2,
                ContactId = idContact
            };

            //Consultando o Id do contact incluído
            var idDeal = Helper.Get(textos).Result;

            //Coletando os parâmetros para chamada da API
            textos = new Textos()
            {
                Url = "/Tasks",
                MessageSuccess = "\n\nTarefa criada com sucesso!!!\n\nPrecione qualquer tecla para continuar...",
                MessageError = "\n\nFalha ao criar a tarefa",
                DealId = idDeal
            };

            //Atribuindo o Id da deal incluído
            var tasks = new Tasks() { DealId = idDeal };

            //Cabeçalho da tela
            metodos.Etapas(2);
            metodos.Pergunta();

            //Cadastrando a Tasks
            Helper.Post(tasks, textos).Wait();
            Console.ReadKey();

            //Coletando os parâmetros para chamada da API
            textos = new Textos()
            {
                Url = "/Deals(" + idDeal + ")",
                MessageSuccess = "\n\nTarefa alterada com sucesso!!!\n\nPrecione qualquer tecla para continuar...",
                MessageError = "\n\nFalha ao alterar a tarefa"
            };

            //Atribuindo o valor de Amount
            var dealPatch = new DealsPatch() { Amount = 15000 };

            //Cabeçalho da tela
            metodos.Etapas(3);
            metodos.Pergunta();

            //Alterando a Deal no Amount
            Helper.Patch(dealPatch, textos).Wait();
            Console.ReadKey();

            //Coletando os parâmetros para chamada da API
            textos = new Textos()
            {
                Url = "/Tasks",
                NumeroConsulta = 3,
                DealId = idDeal
            };

            //Consultando o Id do tasks
            var idTasks = Helper.Get(textos).Result;

            //Coletando os parâmetros para chamada da API
            textos = new Textos()
            {
                Url = "/Tasks(" + idTasks + ")/Finish",
                MessageSuccess = "\n\nTarefa finalizada com sucesso!!!\n\nPrecione qualquer tecla para continuar...",
                MessageError = "\n\nFalha ao finalizar a tarefa"
            };

            //Cabeçalho da tela
            metodos.Etapas(4);
            metodos.Pergunta();

            //Finalizando a tarefa
            Helper.Post("", textos).Wait();
            Console.ReadKey();

            //Coletando os parâmetros para chamada da API
            textos = new Textos()
            {
                Url = "/Deals(" + idDeal + ")/Win",
                MessageSuccess = "\n\nGanhou a Deal com sucesso!!!\n\nPrecione qualquer tecla para continuar...",
                MessageError = "\n\nFalha ao ganhar a Deal"
            };

            //Cabeçalho da tela
            metodos.Etapas(5);
            metodos.Pergunta();

            //Ganhando a Deal
            Helper.Post("", textos).Wait();
            Console.ReadKey();

            //Coletando os parâmetros para chamada da API
            textos = new Textos()
            {
                Url = "/InteractionRecords",
                MessageSuccess = "\n\nHistórico do cliente incluíudo com sucesso!!!\n\nPrecione qualquer tecla para continuar...",
                MessageError = "\n\nFalha ao incluir histórico do cliente"
            };

            //Atribuindo o histórico do cliente
            var interRecords = new InteractionRecords() { ContactId = idContact, Content = "Negócio fechado!!!" };

            //Cabeçalho da tela
            metodos.Etapas(6);
            metodos.Pergunta();

            //Inserindo histórico do cliente
            Helper.Post(interRecords, textos).Wait();
            Console.ReadKey();
        }
    }
}
