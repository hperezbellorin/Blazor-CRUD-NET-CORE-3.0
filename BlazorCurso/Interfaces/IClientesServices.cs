using BlazorCurso.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCurso.Interfaces
{
    interface IClientesServices
    {
        Task<bool> GuardarCliente(Cliente cliente);
        Task<IEnumerable<Cliente>> DameTodosLosCLientes();

        Task<Cliente> DameDatosCliente(int id);
        Task<bool> BorrarCliente(int id);

        Task<IEnumerable<Cliente>> DameTodosLosCLientes(string busqueda);
    }
}
