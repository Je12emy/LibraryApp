using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace LibraryWebService
{
    /// <summary>
    /// Summary description for LibraryWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LibraryWebService : System.Web.Services.WebService
    {
        #region Metodos de BD
        static string Cadena_Conexion = "Data Source=192.168.0.114;Initial Catalog=Library;Persist Security Info=True;User ID=PrograMVC;Password=PrograMVC";
        static SqlConnection Conexion = new SqlConnection(Cadena_Conexion);

        
        public DataTable Ejecutar_Consulta(StringBuilder Query, SqlCommand Comando = null)
        {
            // Es mejor usar un DataTable cuando trabajemos con consultas a una sola tabla.
            DataTable Tabla = new DataTable();
            try
            {
                Tabla.TableName = "Consulta";
                Conexion.Open();
                if (Comando == null)
                {
                    Comando = new SqlCommand();
                }
                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = Query.ToString();

                SqlDataReader Lector = Comando.ExecuteReader();
                // DataReader para tabajar DataTable!

                Tabla.Load(Lector);
                Conexion.Close();

                return Tabla;
            }
            catch (Exception ex)
            {
                Conexion.Close();
                throw new Exception(ex.ToString());
                //throw new Exception("Error en Capa de Datos: " + ex);
                // En el mundo real mostrar el mensaje de error no es lo optimo, pues puede ser informacion sensible.
            }
        }
        
        public int EjecutarSentencia(StringBuilder Query, SqlCommand Comando = null)
        {
            // Es mejor usar parametros especificos para evitar vulnerabilidades.
            // Aca tambien definimos a Comando como null para que sea Opcinal.
            int resultado = 0;

            try
            {
                Conexion.Open();
                Comando.Connection = Conexion;
                Comando.CommandType = CommandType.Text;
                Comando.CommandText = Query.ToString();

                resultado = Comando.ExecuteNonQuery();
                // Captura el numero de fials afectadas por este comando.

                Conexion.Close();

                return resultado;
            }
            catch (Exception ex)
            {
                Conexion.Close();
                throw new Exception(ex.ToString());
                //throw new Exception("Error en Capa de Datos: " + ex);
            }

        }
        #endregion

        #region Bibliotecario
        // Verificar credenciales del bibliotecario
        // Devuelve un BIT en el DataTable
        [WebMethod]
        public DataTable VerificarBibliotecario(string usuario, string clave)
        {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            DataTable tabla = new DataTable();

            try
            {
                sqlQuery.Append("EXEC [dbo].[VerificarBibliotecario]");

                sqlQuery.Append(" @Usuario,@Clave");
                comando.Parameters.Add("@Usuario", SqlDbType.NVarChar).Value = usuario;
                comando.Parameters.Add("@Clave", SqlDbType.VarChar).Value = clave;
                tabla = Ejecutar_Consulta(sqlQuery, comando);

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        // Manejo del catalogo de libros
        // Insertar libro
        [WebMethod]
        public int InsertarLibro(string titulo, string autor,bool disponibilidad,int codigoUbicacion) {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            int i;
            try
            {
                sqlQuery.Append("INSERT INTO [Libreria.Catalogo] VALUES (@titulo, @autor,@disponibilidad, @codigoUbicacion)");
                comando.Parameters.Add("@titulo",SqlDbType.NVarChar).Value = titulo;
                comando.Parameters.Add("@autor",SqlDbType.NVarChar).Value = autor;                                
                comando.Parameters.Add("@disponibilidad", SqlDbType.Bit).Value = disponibilidad;                           
                comando.Parameters.Add("@codigoUbicacion",SqlDbType.Int).Value = codigoUbicacion;
                i = EjecutarSentencia(sqlQuery,comando);
                return i;
            }
            catch (Exception e)
            {
                throw new Exception("Error:"+e);
            }
        }
        // Modificar libro.
        [WebMethod]
        public int ModificarLibro(int codigoLibro, string titulo, string autor, bool disponibilidad, int codigoUbicacion)
        {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            int i;
            try
            {
                sqlQuery.Append("UPDATE [Libreria.Catalogo] SET Titulo = @titulo, Autor =@autor, Disponibilidad = @disponibilidad, CodigoUbicacion = @codigoUbicacion WHERE CodigoLibro = @codigoLibro");
                comando.Parameters.Add("@codigoLibro", SqlDbType.Int).Value = codigoLibro;
                comando.Parameters.Add("@titulo", SqlDbType.NVarChar).Value = titulo;
                comando.Parameters.Add("@autor", SqlDbType.NVarChar).Value = autor;
                comando.Parameters.Add("@disponibilidad", SqlDbType.Bit).Value = disponibilidad;
                comando.Parameters.Add("@codigoUbicacion", SqlDbType.Int).Value = codigoUbicacion;
                i = EjecutarSentencia(sqlQuery, comando);
                return i;
            }
            catch (Exception e)
            {
                throw new Exception("Error:" + e);
            }
        }
        // Eliminar libro
        [WebMethod]
        public int EliminarLibro(int codigoLibro) {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            int i;
            try
            {
                sqlQuery.Append("DELETE FROM [Libreria.Catalogo] WHERE CodigoLibro = @codigoLibro");
                comando.Parameters.Add("@codigoLibro",SqlDbType.Int).Value = codigoLibro;

                EliminarLibroReservas(codigoLibro);
                i = EjecutarSentencia(sqlQuery, comando);
                return i;
            }
            catch (Exception e)
            {
                throw new Exception("Error:" + e);
            }
        }
        public int EliminarLibroReservas(int codigoLibro)
        {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            int i;
            try
            {
                sqlQuery.Append("DELETE FROM [Socio.Prestamo] WHERE CodigoLibro = @codigoLibro");
                comando.Parameters.Add("@codigoLibro", SqlDbType.Int).Value = codigoLibro;

                i = EjecutarSentencia(sqlQuery, comando);
                return i;
            }
            catch (Exception e)
            {
                throw new Exception("Error:" + e);
            }
        }
        // Buscar Libro
        [WebMethod] 
        public DataTable UbicarLibro(int codigoLibro)
        {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            DataTable tabla = new DataTable();
            
            try
            {
                sqlQuery.Append("EXEC [dbo].[UbicarLibro]");

                sqlQuery.Append(" @CodigoLibro");
                comando.Parameters.Add("@CodigoLibro", SqlDbType.Int).Value = codigoLibro;
                tabla = Ejecutar_Consulta(sqlQuery, comando);

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        // Buscar TODOS los Libro
        [WebMethod]
        public DataTable BuscarLibros()
        {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            DataTable tabla = new DataTable();

            try
            {
                sqlQuery.Append("SELECT * FROM [Libreria.Catalogo]");
                tabla = Ejecutar_Consulta(sqlQuery, comando);

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        // Consultar prestamos
        [WebMethod]
        public DataTable HistorialSocio(int codigoSocio, bool? estado) {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            DataTable tabla = new DataTable();
            try
            {
                if (estado == true)
                {
                    // Si el estado es True, buscar los prestamos Activos.
                    sqlQuery.Append("EXEC [dbo].[HistorialSocioActivos] @CodigoSocio");
                }
                else if (estado == false)
                {
                    // Si el estado es False, buscar los prestamos Inactivos.
                    sqlQuery.Append("EXEC [dbo].[HistorialSocioInactivos] @CodigoSocio");
                }
                else if (estado == null)
                {
                    // Si no nos dan un valor, buscar el historial completo.
                    sqlQuery.Append("EXEC [dbo].[HistorialSocio] @CodigoSocio");
                }
                comando.Parameters.Add("@CodigoSocio", SqlDbType.Int).Value = codigoSocio;

                tabla = Ejecutar_Consulta(sqlQuery, comando);
                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        [WebMethod]
        // Buscar todos los prestamos
        public DataTable BuscarPrestamosTodo() {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            DataTable tabla = new DataTable();

            try
            {
                sqlQuery.Append("SELECT * FROM [Socio.Prestamo]");
                tabla = Ejecutar_Consulta(sqlQuery, comando);

                return tabla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        // Insertar prestamo
        [WebMethod]
        public int InsertarPrestamo(int codigoSocio, int codigoLibro, DateTime fechaPrestamo, bool estado) {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            int i;
            try
            {
                sqlQuery.Append("INSERT INTO [Socio.Prestamo] VALUES (@CodigoSocio, @CodigoLibro, @FechaPrestamo, @Estado)");
                comando.Parameters.Add("@codigoSocio", SqlDbType.Int).Value = codigoSocio;
                comando.Parameters.Add("@codigoLibro", SqlDbType.Int).Value = codigoLibro;
                comando.Parameters.Add("@FechaPrestamo", SqlDbType.DateTime).Value = fechaPrestamo;
                comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = estado;

                i = EjecutarSentencia(sqlQuery, comando);
                return i;
            }
            catch (Exception e)
            {
                throw new Exception("Error:" + e);
            }
        }
        // Modificar prestamo
        [WebMethod]
        public int ModificarPrestamo(int codigoPrestamo,int codigoSocio, int codigoLibro, DateTime fechaPrestamo, bool estado)
        {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            int i;
            try
            {
                sqlQuery.Append("UPDATE [Socio.Prestamo] SET CodigoSocio = @codigoSocio, CodigoLibro = @CodigoLibro, FechaPrestamo = @fechaPrestamo, Estado = @Estado WHERE CodigoPrestamo = @codigoPrestamo");
                comando.Parameters.Add("@codigoPrestamo",SqlDbType.Int).Value = codigoPrestamo;
                comando.Parameters.Add("@codigoSocio", SqlDbType.Int).Value = codigoSocio;
                comando.Parameters.Add("@codigoLibro", SqlDbType.Int).Value = codigoLibro;
                comando.Parameters.Add("@FechaPrestamo", SqlDbType.DateTime).Value = fechaPrestamo;
                comando.Parameters.Add("@Estado", SqlDbType.Bit).Value = estado;

                i = EjecutarSentencia(sqlQuery, comando);
                return i;
            }
            catch (Exception e)
            {
                throw new Exception("Error:" + e);
            }
        }
        // Eliminar Prestamo
        [WebMethod]
        public int EliminarPrestamo(int codigoPrestamo)
        {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            int i;
            try
            {
                sqlQuery.Append("DELETE FROM [Socio.Prestamo] WHERE CodigoPrestamo = @codigoPrestamo");
                comando.Parameters.Add("@codigoPrestamo", SqlDbType.Int).Value = codigoPrestamo;

                i = EjecutarSentencia(sqlQuery, comando);
                return i;
            }
            catch (Exception e)
            {
                throw new Exception("Error:" + e);
            }
        }
        // Comprobar Socio
        [WebMethod]
        public DataTable ComprobarSocio(int codigoSocio) {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            DataTable tabla = new DataTable();
            try
            {
                sqlQuery.Append("EXEC [dbo].[ComprobarEstadoSocio] @codigoSocio");
                comando.Parameters.Add("@codigoSocio", SqlDbType.Int).Value = codigoSocio;

                tabla = Ejecutar_Consulta(sqlQuery,comando);
                return tabla;
            }
            catch (Exception e)
            {
                throw new Exception("Error:" + e);
            }
        }
        #endregion

        #region Socio
        [WebMethod]
        public DataTable VerificarSocio(int codigoSocio, string clave) {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            DataTable tabla = new DataTable();

            try
            {
                sqlQuery.Append("EXEC [dbo].[VerificarSocio] @CodigoSocio, @Clave");
                comando.Parameters.Add("@CodigoSocio", SqlDbType.NVarChar).Value = codigoSocio;
                comando.Parameters.Add("@Clave", SqlDbType.VarChar).Value = clave;
                tabla = Ejecutar_Consulta(sqlQuery, comando);

                return tabla;
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e);
            }
        }
        [WebMethod]
        public DataTable BuscarSocio(int codigoSocio)
        {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            DataTable tabla = new DataTable();

            try
            {
                sqlQuery.Append("SELECT * FROM [Socio.Informacion] WHERE CodigoSocio = @codigoSocio");
                comando.Parameters.Add("@CodigoSocio", SqlDbType.NVarChar).Value = codigoSocio;
                tabla = Ejecutar_Consulta(sqlQuery, comando);

                return tabla;
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e);
            }
        }
        [WebMethod]
        public DataTable BuscarSocioTodo()
        {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            DataTable tabla = new DataTable();

            try
            {
                sqlQuery.Append("SELECT * FROM [Socio.Informacion]");
                tabla = Ejecutar_Consulta(sqlQuery, comando);

                return tabla;
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e);
            }
        }

        [WebMethod]
        public int ModificarSocio(int codigoSocio, string nombre, string primerApellido, string segundoApellido, string direccion)
        {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            int i;
            try
            {
                sqlQuery.Append("UPDATE [Socio.Informacion] SET NombreSocio = @nombre, PrimerApellido = @primerApellido, SegundoApellido = @segundoApellido, DireccionSocio = @direccion WHERE CodigoSocio = @codigoSocio");
                comando.Parameters.Add("@codigoSocio", SqlDbType.Int).Value = codigoSocio;
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
                comando.Parameters.Add("@primerApellido", SqlDbType.NVarChar).Value = primerApellido;
                comando.Parameters.Add("@segundoApellido", SqlDbType.NVarChar).Value = segundoApellido;
                comando.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = direccion;

                i = EjecutarSentencia(sqlQuery, comando);
                return i;
            }
            catch (Exception e)
            {
                throw new Exception("Error:" + e);
            }
        }
        [WebMethod]
        public int EliminarSocio(int codigoSocio) {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            int i;
            try
            {
                sqlQuery.Append("DELETE FROM [Socio.Informacion] WHERE CodigoSocio = @codigoSocio");
                comando.Parameters.Add("@codigoSocio", SqlDbType.Int).Value = codigoSocio;

                i = EjecutarSentencia(sqlQuery, comando);
                EliminarSocioPrestamos(codigoSocio);
                return i;
            }
            catch (Exception e)
            {
                throw new Exception("Error:" + e);
            }
        }
        public int EliminarSocioPrestamos(int codigoSocio) {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            int i;
            try
            {
                sqlQuery.Append("DELETE FROM [Socio.Prestamo] WHERE CodigoSocio = @codigoSocio");
                comando.Parameters.Add("@codigoSocio", SqlDbType.Int).Value = codigoSocio;

                i = EjecutarSentencia(sqlQuery, comando);
                return i;
            }
            catch (Exception e)
            {
                throw new Exception("Error:" + e);
            }
        }
        [WebMethod]
        public DataTable ContarPrestamosSocio(int codigoSocio) {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            DataTable tabla = new DataTable();

            try
            {
                sqlQuery.Append("EXEC [dbo].[ContarPrestamos] @CodigoCliente");
                comando.Parameters.Add("@CodigoCliente",SqlDbType.Int).Value = codigoSocio;
                tabla = Ejecutar_Consulta(sqlQuery, comando);

                return tabla;
            }
            catch (Exception e)
            {
                throw new Exception("Error: " + e);
            }
        }
        [WebMethod]
        public int AgregarSocio(string nombre, string primerApellido, string segundoApellido, string direccion, bool estado, string clave)
        {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            int i;
            try
            {
                sqlQuery.Append("INSERT INTO [Socio.Informacion] VALUES (@nombre, @primerApellido, @segundoApellido, @direccion, @estadoSocio, @clave)");
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
                comando.Parameters.Add("@primerApellido", SqlDbType.NVarChar).Value = primerApellido;
                comando.Parameters.Add("@segundoApellido", SqlDbType.NVarChar).Value = segundoApellido;
                comando.Parameters.Add("@direccion", SqlDbType.NVarChar).Value = direccion;
                comando.Parameters.Add("@estadoSocio", SqlDbType.Bit).Value = estado;
                comando.Parameters.Add("@clave",SqlDbType.VarChar).Value = clave;

                i = EjecutarSentencia(sqlQuery, comando);
                return i;
            }
            catch (Exception e)
            {
                throw new Exception("Error:" + e);
            }
        }
        [WebMethod]
        public int ModificarEstadoSocio(int codigoSocio, bool estado) {
            StringBuilder sqlQuery = new StringBuilder();
            SqlCommand comando = new SqlCommand();
            int i;
            try
            {
                sqlQuery.Append("UPDATE [Socio.Informacion] SET EstadoSocio = @estadoSocio WHERE CodigoSocio = @codigoSocio");
                comando.Parameters.Add("@codigoSocio",SqlDbType.Int).Value = codigoSocio;
                comando.Parameters.Add("@estadoSocio", SqlDbType.Bit).Value = estado;

                i = EjecutarSentencia(sqlQuery, comando);
                return i;
            }
            catch (Exception e)
            {
                throw new Exception("Error:" + e);
            }
        }
    }


    #endregion
}
