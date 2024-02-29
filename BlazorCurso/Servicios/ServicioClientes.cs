using BlazorCurso.Data;
using BlazorCurso.Interfaces;
using BlazorCurso.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCurso.Servicios
{
    public class ServicioClientes: IClientesServices
    {
        private IClientesRepositorio clientesRepositorio;
        private SqlConfiguracion configuracion;

        public ServicioClientes(SqlConfiguracion c)
        {
            configuracion = c;
            clientesRepositorio = new RepositorioClientes(configuracion.CadenaConexion);
        }
        public Task<bool> GuardarCliente(Cliente cliente)
        {
            if (cliente.Id == 0)
                return clientesRepositorio.GuardarCliente(cliente);
            else
                return clientesRepositorio.ModificarCliente(cliente);
        }

        public Task<IEnumerable<Cliente>> DameTodosLosCLientes()
        {
            return clientesRepositorio.DameTodosLosCLientes();
        }

        public Task<Cliente> DameDatosCliente(int id)
        {
            return clientesRepositorio.DameDatosCliente(id);
        }
        public Task<bool> BorrarCliente(int id)
        {
            return clientesRepositorio.BorrarCliente(id);
        }

        public Task<IEnumerable<Cliente>> DameTodosLosCLientes(string busqueda)
        {
            return clientesRepositorio.DameTodosLosCLientes(busqueda);
        }
    }
}
