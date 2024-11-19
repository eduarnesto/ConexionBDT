using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALD
{
    public class ListadosDAL
    {
        /// <summary>
        /// Devuelve un listado de la base de datos de azure
        /// </summary>
        public static List<ClsPersona> ListadoCompletoPersonasDAL()
        {

           
            SqlConnection miConexion = new SqlConnection();

            List<ClsPersona> listadoPersonas = new List<ClsPersona>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsPersona oPersona;

            try
            {
                miConexion = ClsConexion.getConexion();
                miComando.CommandText = "SELECT * FROM personas";
                miComando.Connection= miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new ClsPersona();
                        oPersona.id = (int)miLector["ID"];
                        oPersona.nombre = (string)miLector["Nombre"];
                        oPersona.apellidos = (string)miLector["Apellidos"];
                        oPersona.foto = (string)miLector["Foto"];
                        if (miLector["FechaNacimiento"] != System.DBNull.Value)
                        {
                            oPersona.fechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                        }
                        oPersona.direccion = (string)miLector["Direccion"];
                        oPersona.telefono = (string)miLector["Telefono"];
                        listadoPersonas.Add(oPersona);
                    }
                }
                miLector.Close();

            }
            catch (Exception ex) {
                throw;
            }
            finally
            {
                miConexion.Close();
            }

            return listadoPersonas;
        }

        /// <summary>
        /// Devuelve una persona de la base de datos segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve una persona vacía si no se encuentra la persona</returns>
        public static ClsPersona BuscarPersonaPorId(int id)
        {
            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsPersona oPersona = new ClsPersona();

            try
            {
                miConexion = ClsConexion.getConexion();
                miComando.CommandText = "SELECT * FROM personas WHERE ID=@id";
                miComando.Connection = miConexion;
                miComando.Parameters.AddWithValue("@id", id);
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new ClsPersona();
                        oPersona.id = (int)miLector["ID"];
                        oPersona.nombre = (string)miLector["Nombre"];
                        oPersona.apellidos = (string)miLector["Apellidos"];
                        oPersona.foto = (string)miLector["Foto"];
                        if (miLector["FechaNacimiento"] != System.DBNull.Value)
                        {
                            oPersona.fechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                        }
                        oPersona.direccion = (string)miLector["Direccion"];
                        oPersona.telefono = (string)miLector["Telefono"];
                    }
                }
                miLector.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                miConexion.Close();
            }

            return oPersona;
        }

        /// <summary>
        /// Elimina una persona de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int eliminarPersona(int id)
        {

            int numeroFilasAfectadas = 0;

            SqlConnection miConexion = new SqlConnection();

            List<ClsPersona> listadoPersonas = new List<ClsPersona>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsPersona oPersona;

            try

            {
                miConexion = ClsConexion.getConexion();

                miComando.CommandText = "DELETE FROM Personas WHERE ID=@id";

                miComando.Connection = miConexion;

                miComando.Parameters.AddWithValue("@id", id);

                numeroFilasAfectadas = miComando.ExecuteNonQuery();

            }

            catch (Exception ex)

            {
                throw ex;
            }

            return numeroFilasAfectadas;
        }

    }
}

