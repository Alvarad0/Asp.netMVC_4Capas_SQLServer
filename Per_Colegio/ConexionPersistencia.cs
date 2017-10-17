using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Per_Colegio
{
    public class ConexionPersistencia
    {
        #region Atributos
        public static String nombreConexion = "DBColegio";

        private string cadenaConexion =
            ConfigurationManager.ConnectionStrings != null &&
            ConfigurationManager.ConnectionStrings[nombreConexion] != null ?
            ConfigurationManager.ConnectionStrings[nombreConexion].ConnectionString : "";

        public string CadenaConexion
        {
            get { return cadenaConexion; }
            set { cadenaConexion = value; }
        }
        private SqlConnection conexion;
        public SqlConnection Conexion
        {
            get { return conexion; }
        }
        /// <summary>
        /// Inicia la Conexión
        /// </summary>
        public void OpenConexion() {
            if (conexion == null)
                conexion = new SqlConnection(cadenaConexion);

            if (conexion.State == ConnectionState.Closed) {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
            }
        }
        /// <summary>
        /// Finaliza la Conexión
        /// </summary>
        public void CloseConexion() {
            if (conexion.State == ConnectionState.Open) {
                conexion.Close();
                conexion.Dispose();
            }
        }
        /// <summary>
        /// Establece la Conexión a utilizar
        /// </summary>
        public void AssignConexion(object conn) {
            if (conn is SqlConnection)
                conexion = conn as SqlConnection;
            else if (conexion != null)
            {
                conexion.Dispose();
                conexion = null;
            }

        }
        #endregion
    }
}
