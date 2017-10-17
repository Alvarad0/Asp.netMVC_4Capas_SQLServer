using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ent_Colegio;
using System.Data.SqlClient;
using System.Data;
using Per_Colegio;

namespace Per_Colegio
{
    public class RolPersistencia : ConexionPersistencia
    {
        public List<Rol> ObtenerTodos() {
            List<Rol> lista = new List<Rol>();
            Rol entidad = null;
            try {
                OpenConexion();
                StringBuilder CadenaSql = new StringBuilder();
                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Rol";
                using (var dr = comandoSelect.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new Rol();
                        entidad.Id_Rol = int.Parse(dr["Id_Rol"].ToString());
                        entidad.Nombre = dr["Nombre"].ToString();
                        lista.Add(entidad);
                    }

                }
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "ObtenerRoles";
                throw excepcion;
            }
            finally
            {
                CloseConexion();
            }
            return lista;
        }

        public bool Insertar (Rol entidad) {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                OpenConexion();
                if (esValido(entidad))
                {
                    cmd.Connection = Conexion;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DML_InsertarRol";
                    cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
                else
                {
                    throw new System.ArgumentException("Existen parametros requeridos", "RolPersistencia");
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero Error => " + ex.Message, ex);
                excepcion.Source = "Insertar Nombre";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero Error => " + ex.Message, ex);
                excepcion.Source = "Insertar Nombre";
                throw excepcion;
            }
            finally {
                CloseConexion();
                cmd = null;
            }
            return respuesta;
        }

        private bool esValido(Rol entidad)
        {
            bool valido = false;
            if (entidad.Nombre != null)
                valido = true;

            return valido;
        }

        public bool Actualizar(Rol entidad) {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                OpenConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_ActualizarRol";
                cmd.Parameters.AddWithValue("@Id_Rol", entidad.Id_Rol);
                cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un Error => " + ex.Message, ex);
                excepcion.Source = "Actualizar Rol";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un Error => " + ex.Message, ex);
                excepcion.Source = "Actualizar Rol";
                throw excepcion;
            }
            finally {
                CloseConexion();
                cmd = null;
            }
            return respuesta;
        }

        public Rol Obtener(int id) {
            Rol entidad = null;
            try
            {
                OpenConexion();
                StringBuilder CadenaSql = new StringBuilder();
                SqlCommand comandoSelect = new SqlCommand();
                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_ObtenerRol";
                comandoSelect.Parameters.AddWithValue("@Id_Rol", id);
                using (var dr = comandoSelect.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new Rol();
                        entidad.Nombre = dr["Nombre"].ToString();
                    }
                }
            }
            catch (Exception exc)
            {

                throw exc;
            }
            finally {
                CloseConexion();
            }
            return entidad;
        }

        public bool Eliminar(int id) {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                OpenConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_EliminarRol";
                cmd.Parameters.AddWithValue("@Id_Rol", id);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un Error => " + ex.Message, ex);
                excepcion.Source = "Eliminar Rol";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error => " + ex.Message, ex);
                excepcion.Source = "Eliminar Rol";
                throw excepcion;
            }
            finally {
                CloseConexion();
                cmd = null;
            }
            return respuesta;
        }
    }
}
