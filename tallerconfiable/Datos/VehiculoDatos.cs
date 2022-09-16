using System.Data.SqlClient;
using System.Data;
using tallerconfiable.Models;
using System.Numerics;
using System.Reflection;

namespace tallerconfiable.Datos
{
    public class VehiculoDatos
    {
        public List<VehiculoModelo> Listar()
        {
            
                    var olista = new List<VehiculoModelo>();
                    var cn = new Conexion();
                    using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                    {
                        conexion.Open();
                        SqlCommand cmd = new SqlCommand("sp_ListarVehiculo", conexion);

                        cmd.CommandType = CommandType.StoredProcedure;

                        using (var dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                olista.Add(new VehiculoModelo()
                                {
                                    Idvehiculo = Convert.ToInt32(dr["Idvehiculo"]),
                                    Placa = dr["Placa"].ToString(),
                                    Tipo = dr["Tipo"].ToString(),
                                    Marca = dr["Marca"].ToString(),
                                    Modelo = dr["Modelo"].ToString(),
                                    Capacidad = dr["Capacidad"].ToString(),
                                    Cilindraje = dr["Cilindraje"].ToString(),
                                    Ciudadorigen = dr["Ciudadorigen"].ToString(),
                                    Descripcion = dr["Descripcion"].ToString(),
                                });
                            }
                        }
                    }
                    return olista;

                }

                public bool Guardar(VehiculoModelo oVehiculo)
                {
                    bool rpta;
                    try
                    {
                        var cn = new Conexion();
                        using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                        {
                            conexion.Open();
                            SqlCommand cmd = new SqlCommand("sp_GuardarVehiculo", conexion);
                            cmd.Parameters.AddWithValue("Identificacion", oVehiculo.Identificacion);
                            cmd.Parameters.AddWithValue("Idpropietario", oVehiculo.Idpropietario);
                            cmd.Parameters.AddWithValue("Placa", oVehiculo.Placa);
                            cmd.Parameters.AddWithValue("Tipo", oVehiculo.Tipo);
                            cmd.Parameters.AddWithValue("Marca", oVehiculo.Marca);
                            cmd.Parameters.AddWithValue("Modelo", oVehiculo.Modelo);
                            cmd.Parameters.AddWithValue("Capacidad", oVehiculo.Capacidad);
                            cmd.Parameters.AddWithValue("Cilindraje", oVehiculo.Cilindraje);
                            cmd.Parameters.AddWithValue("Ciudadorigen", oVehiculo.Ciudadorigen);
                            cmd.Parameters.AddWithValue("Descripcion", oVehiculo.Descripcion);
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

                public VehiculoModelo Obtener(int Idvehiculo)
        {
            var oVehiculo = new VehiculoModelo();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerVehiculo", conexion);
                //no se si cambia a Idpropietario
                cmd.Parameters.AddWithValue("Idvehiculo", Idvehiculo);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        
                        oVehiculo.Identificacion = Convert.ToInt32(dr["Identificacion"]);
                        oVehiculo.Placa = dr["Placa"].ToString();
                        oVehiculo.Tipo = dr["Tipo"].ToString();
                        oVehiculo.Marca = dr["Marca"].ToString();
                        oVehiculo.Modelo = dr["Modelo"].ToString();
                        oVehiculo.Capacidad = dr["Capacidad"].ToString();
                        oVehiculo.Cilindraje = dr["Cilindraje"].ToString();
                        oVehiculo.Ciudadorigen = dr["Ciudadorigen"].ToString();
                        oVehiculo.Descripcion = dr["Descripcion"].ToString();

                    }
                }
            }
            return oVehiculo;

        }

       
        public bool Editar(VehiculoModelo ovehiculo)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarVehiculo", conexion);
                    cmd.Parameters.AddWithValue("Idvehiculo", ovehiculo.Idvehiculo);
                    cmd.Parameters.AddWithValue("Identificacion", ovehiculo.Identificacion);
                    cmd.Parameters.AddWithValue("Placa", ovehiculo.Placa);
                    cmd.Parameters.AddWithValue("Tipo", ovehiculo.Tipo);
                    cmd.Parameters.AddWithValue("Marca", ovehiculo.Marca);
                    cmd.Parameters.AddWithValue("Modelo", ovehiculo.Modelo);
                    cmd.Parameters.AddWithValue("Capacidad", ovehiculo.Capacidad);
                    cmd.Parameters.AddWithValue("Cilindraje", ovehiculo.Cilindraje);
                    cmd.Parameters.AddWithValue("Ciudadorigen", ovehiculo.Ciudadorigen);
                    cmd.Parameters.AddWithValue("Descripcion", ovehiculo.Descripcion);
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
        public bool Eliminar(int Idvehiculo)
        {
            Console.WriteLine("click eliminar");
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarVehiculo", conexion);
                    Console.WriteLine(Idvehiculo);
                    cmd.Parameters.AddWithValue("Idvehiculo", Idvehiculo);
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

