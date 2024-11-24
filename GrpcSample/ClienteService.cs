using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using ClientesGRPC;
using Google.Protobuf.WellKnownTypes;


namespace GrpcSample
{
    public class ClienteService : ClientesGRPC.ClienteService.ClienteServiceBase
    {
        private readonly List<Cliente> clientes = new List<Cliente>
    {
        new Cliente { Id = 1, Nome = "João Silva" },
        new Cliente { Id = 2, Nome = "Maria Oliveira" },
        new Cliente { Id = 3, Nome = "Carlos Santos" }
    };

        public override Task<ClienteList> GetClientes(ClientesGRPC.Empty request, ServerCallContext context)
        {
            // Retornando a lista de clientes
            var response = new ClienteList();
            response.Clientes.AddRange(clientes);

            return Task.FromResult(response);
        }

        // Método que retorna um cliente específico baseado no ID
        public override Task<Cliente> GetClienteById(ClienteIdRequest request, ServerCallContext context)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == request.Id);
            return Task.FromResult(cliente);
        }
    }
}
