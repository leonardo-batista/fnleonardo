using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FN.Store.Data.EF.Repository;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;

namespace FN.Store.SB.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<ProdutoVM> produtos;
            using (var repo = new ProdutoRepository())
            {
                produtos = repo.Obter().Select(p => new ProdutoVM
                {
                    Nome = p.Nome,
                    Preco = p.Preco
                });
            }
            //string de conexão com o Service Bus
            var conn = "Endpoint=sb://fnstore.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=nM/ezhTASnJOtek6DqmDDSyIvawNP/w7gwx9HP7QEKY=";

            //fila criada dentro do service bus
            var queue = "produtos";

            var server = QueueClient.CreateFromConnectionString(conn, queue);
            var message = JsonConvert.SerializeObject(produtos);

            server.Send(new BrokeredMessage(message));
            Console.WriteLine("Mensagem enviada!");
            Console.ReadLine();

        }
    }

    class ProdutoVM
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
