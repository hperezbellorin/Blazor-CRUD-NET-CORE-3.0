using BlazorCurso.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCurso.Repositorio
{
    interface IClientesRepositorio
    {

        Task<bool> GuardarCliente(Cliente cliente);
        Task<IEnumerable<Cliente>> DameTodosLosCLientes();

        Task<Cliente> DameDatosCliente(int id);

        Task<bool> ModificarCliente(Cliente cliente);

        Task<bool> BorrarCliente(int id);

        Task<IEnumerable<Cliente>> DameTodosLosCLientes(string busqueda);
    }
}
