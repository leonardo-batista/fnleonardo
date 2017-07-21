using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.Store.SB.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //string de conexão com o Service Bus
            var conn = "Endpoint=sb://fnstore.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=nM/ezhTASnJOtek6DqmDDSyIvawNP/w7gwx9HP7QEKY=";

            //fila criada dentro do service bus
            var queue = "produtos";

            var server = QueueClient.CreateFromConnectionString(conn, queue);
            server.OnMessage(msg=>{
                Console.WriteLine("Id: {0}", msg.MessageId);
                var produtos = JsonConvert.DeserializeObject<List<ProdutoVM>>(msg.GetBody<string>());
                
                foreach (var prod in produtos)
                {
                    Console.WriteLine("Nome: {0} - Preço: {1:C2}", prod.Nome, prod.Preco);
                }
            });

            Console.ReadLine();
        }
    }

    class ProdutoVM
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
