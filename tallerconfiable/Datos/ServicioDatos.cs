using System.Data;
using System.Data.SqlClient;
using tallerconfiable.Models;

namespace tallerconfiable.Datos
{
    public class ServicioDatos
    {
        public List<ServicioModelo> Listar()
        {
            var olista = new List<ServicioModelo>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarServicio", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olista.Add(new ServicioModelo()
                        {
                            Idservicio = Convert.ToInt32(dr["Idservicio"]),
                            Idpropietario = Convert.ToInt32(dr["Idpropietario"]),
                            Idvehiculo = Convert.ToInt32(dr["Idvehiculo"]),
                            Idmecanico = Convert.ToInt32(dr["Idmecanico"]),
                            Nivelaceite = dr["Nivelaceite"].ToString(),
                            Nivelfrenos = dr["Nivelfrenos"].ToString(),
                            Niveldireccion = dr["Niveldireccion"].ToString(),
                            Repuestos = dr["Repuestos"].ToString(),
                            Fecha = dr["Fecha"].ToString(),

                        });
                    }
                }
            }
            return olista;

        }

        public ServicioModelo Obtener(int Idservicio)
        {
            var oPersona = new ServicioModelo();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerServicio", conexion);
                cmd.Parameters.AddWithValue("Idservicio", Idservicio);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oPersona.Idservicio = Convert.ToInt32(dr["Idservicio"]);
                        oPersona.Idpropietario = Convert.ToInt32(dr["Idpropietario"]);
                        oPersona.Idvehiculo = Convert.ToInt32(dr["Idvehiculo"]);
                        oPersona.Idmecanico = Convert.ToInt32(dr["Idmecanico"]);
                        oPersona.Placa = dr["Placa"].ToString();
                        oPersona.Nivelaceite = dr["Nivelaceite"].ToString();
                        oPersona.Nivelfrenos = dr["Nivelfrenos"].ToString();
                        oPersona.Niveldireccion = dr["Niveldireccion"].ToString();
                        oPersona.Repuestos = dr["Repuestos"].ToString();
                        oPersona.Fecha = dr["Fecha"].ToString();


                    }
                }
            }
            return oPersona;

        }

        public bool Guardar(ServicioModelo oPersona)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarServicio", conexion);

                    cmd.Parameters.AddWithValue("Placa", oPersona.Placa);
                    cmd.Parameters.AddWithValue("Idmecanico", oPersona.Idmecanico);
                    cmd.Parameters.AddWithValue("Nivelaceite", oPersona.Nivelaceite);
                    cmd.Parameters.AddWithValue("Nivelfrenos", oPersona.Nivelfrenos);
                    cmd.Parameters.AddWithValue("Niveldireccion", oPersona.Niveldireccion);
                    cmd.Parameters.AddWithValue("Repuestos", oPersona.Repuestos);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
        public bool Editar(ServicioModelo oPersona)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarServicio", conexion);

                    cmd.Parameters.AddWithValue("Placa", oPersona.Placa);
                    cmd.Parameters.AddWithValue("Idservicio", oPersona.Idservicio);
                    cmd.Parameters.AddWithValue("Idmecanico", oPersona.Idmecanico);
                    cmd.Parameters.AddWithValue("Nivelaceite", oPersona.Nivelaceite);
                    cmd.Parameters.AddWithValue("Nivelfrenos", oPersona.Nivelfrenos);
                    cmd.Parameters.AddWithValue("Niveldireccion", oPersona.Niveldireccion);
                    cmd.Parameters.AddWithValue("Repuestos", oPersona.Repuestos);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
        public bool Eliminar(int Idservicio)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarServicio", conexion);
                    cmd.Parameters.AddWithValue("Idservicio", Idservicio);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

    }

}