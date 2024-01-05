using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaEntidad;

using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Ubicacion
    {
        public List<Provincia> ObtenerProvincia()
        {

            List<Provincia> lista = new List<Provincia>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select*from PROVINCIA";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            lista.Add(
                                new Provincia()
                                {
                                    IdProvincia = dr["IdProvincia"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),

                                });
                        }
                    }
                }

            }
            catch
            {
                lista = new List<Provincia>();

            }

            return lista;


        }


        public List<Canton> ObtenerCanton( string IdProvincia)
        {

            List<Canton> lista = new List<Canton>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select*from CANTON where IdProvincia = @IdProvincia";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@IdProvincia", IdProvincia);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            lista.Add(
                                new Canton()
                                {
                                    IdCanton = dr["IdCanton"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),

                                });
                        }
                    }
                }

            }
            catch
            {
                lista = new List<Canton>();

            }

            return lista;


        }


        public List<Parroquia> ObtenerParroquia(string idcanton, string idprovincia)
        {

            List<Parroquia> lista = new List<Parroquia>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select*from PARROQUIA where IdCanton = @IdCanton and IdProvincia = @IdProvincia";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.Parameters.AddWithValue("@IdCanton", idcanton);
                    cmd.Parameters.AddWithValue("@IdProvincia", idprovincia);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            lista.Add(
                                new Parroquia()
                                {
                                    IdParroquia = dr["IdParroquia"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),

                                });
                        }
                    }
                }

            }
            catch
            {
                lista = new List<Parroquia>();

            }

            return lista;


        }

    }
}
