
using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesespeciais(IEnumerable<Cliente> clientes);
    }
}
