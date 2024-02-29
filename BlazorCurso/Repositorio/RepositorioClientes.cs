using BlazorCurso.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCurso.Repositorio
{
    public class RepositorioClientes:IClientesRepositorio
    {
        private string CadenaConexion;

        public RepositorioClientes(String cadenaConexion)
        {
            CadenaConexion = cadenaConexion;
        }

        private SqlConnection conexion()
        {
            return new SqlConnection(CadenaConexion);
        }
        public async Task<bool> GuardarCliente(Cliente cliente)
        {
            Boolean clienteCreado = false;
            SqlConnection sqlConexion = conexion();
            SqlCommand Comm = null;
            try
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.UsuariosAlta";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@Nombre", SqlDbType.VarChar, 500).Value = cliente.Nombre;
                Comm.Parameters.Add("@Email", SqlDbType.VarChar, 500).Value = cliente.Email;
                Comm.Parameters.Add("@Telefono", SqlDbType.VarChar, 100).Value = cliente.Telefono;
                Comm.Parameters.Add("@FechaAlta", SqlDbType.DateTime).Value = DateTime.Now;

                if (cliente.Nombre != null && cliente.Email != null && cliente.Telefono != null)
                    await Comm.ExecuteNonQueryAsync();

                clienteCreado = true;

            }
            catch (SqlException ex)
            {
                throw new Exception("Error guardando los datos de nuestro cliente " + ex.Message);
            }
            finally
            {
                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
            }

            return clienteCreado;
        }

        public async Task<IEnumerable<Cliente>> DameTodosLosCLientes()
        {
            List<Cliente> lista = new List<Cliente>();
            SqlConnection sqlConexion = conexion();
            SqlCommand Comm = null;
            try
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.UsuariosLista";
                Comm.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = await Comm.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Cliente c = new Cliente();
                    c.Id = Convert.ToInt32(reader["Id"]);
                    c.Nombre = reader["Nombre"].ToString();
                    c.Email = reader["Email"].ToString();
                    c.Telefono = reader["Telefono"].ToString();
                    lista.Add(c);
                }
                reader.Close();

            }
            catch (SqlException ex)
            {
                throw new Exception("Error guardando los datos de nuestro cliente " + ex.Message);
            }
            finally
            {

                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
            }

            return lista;
        }

        public async Task<Cliente> DameDatosCliente(int id)
        {
            Cliente c = new Cliente();
            SqlConnection sqlConexion = conexion();
            SqlCommand Comm = null;
            try
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.UsuariosLista";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader reader = await Comm.ExecuteReaderAsync();
                if (reader.Read())
                {
                    c.Id = Convert.ToInt32(reader["Id"]);
                    c.Nombre = reader["Nombre"].ToString();
                    c.Email = reader["Email"].ToString();
                    c.Telefono = reader["Telefono"].ToString();

                }
                reader.Close();

            }
            catch (SqlException ex)
            {
                throw new Exception("Error cargando los datos del cliente " + ex.Message);
            }
            finally
            {

                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
            }

            return c;
        }

        public async Task<bool> ModificarCliente(Cliente cliente)
        {
            Boolean clienteModificado = false;
            SqlConnection sqlConexion = conexion();
            SqlCommand Comm = null;
            try
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.UsuariosAlta";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@Nombre", SqlDbType.VarChar, 500).Value = cliente.Nombre;
                Comm.Parameters.Add("@Email", SqlDbType.VarChar, 500).Value = cliente.Email;
                Comm.Parameters.Add("@Telefono", SqlDbType.VarChar, 100).Value = cliente.Telefono;
                Comm.Parameters.Add("@id", SqlDbType.Int).Value = cliente.Id;
                Comm.Parameters.Add("@FechaAlta", SqlDbType.DateTime).Value = DateTime.Now;

                if (cliente.Nombre != null && cliente.Email != null && cliente.Telefono != null)
                    await Comm.ExecuteNonQueryAsync();

                clienteModificado = true;

            }
            catch (SqlException ex)
            {
                throw new Exception("Error guardando los datos de nuestro cliente " + ex.Message);
            }
            finally
            {
                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
            }

            return clienteModificado;
        }
        public async Task<bool> BorrarCliente(int id)
        {
            Boolean clienteBorrado = false;
            SqlConnection sqlConexion = conexion();
            SqlCommand Comm = null;
            try
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.UsuariosBaja";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@id", SqlDbType.Int).Value = id;

                if (id > 0)
                    await Comm.ExecuteNonQueryAsync();

                clienteBorrado = true;

            }
            catch (SqlException ex)
            {
                throw new Exception("Error borrando nuestro cleinte " + ex.Message);
            }
            finally
            {
                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
            }

            return clienteBorrado;
        }

        public async Task<IEnumerable<Cliente>> DameTodosLosCLientes(string busqueda)
        {
            List<Cliente> lista = new List<Cliente>();
            SqlConnection sqlConexion = conexion();
            SqlCommand Comm = null;
            try
            {
                sqlConexion.Open();
                Comm = sqlConexion.CreateCommand();
                Comm.CommandText = "dbo.UsuariosLista";
                Comm.CommandType = CommandType.StoredProcedure;
                Comm.Parameters.Add("@busqueda", SqlDbType.VarChar, 500).Value = busqueda;
                SqlDataReader reader = await Comm.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Cliente c = new Cliente();
                    c.Id = Convert.ToInt32(reader["Id"]);
                    c.Nombre = reader["Nombre"].ToString();
                    c.Email = reader["Email"].ToString();
                    c.Telefono = reader["Telefono"].ToString();
                    lista.Add(c);
                }
                reader.Close();

            }
            catch (SqlException ex)
            {
                throw new Exception("Error cargando los datos de nuestros cliente " + ex.Message);
            }
            finally
            {

                Comm.Dispose();
                sqlConexion.Close();
                sqlConexion.Dispose();
            }

            return lista;
        }
    }
}
