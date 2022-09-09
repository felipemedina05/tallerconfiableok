using System.Data.SqlClient;
using System.Data;
using tallerconfiable.Models;

namespace tallerconfiable.Datos
{
    public class MecanicoDatos
    {
       
            public List<MecanicoModelo> Listar()
            {
                var olista = new List<MecanicoModelo>();
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_listarMecanico", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            olista.Add(new MecanicoModelo()
                            {
                                Idpersona = Convert.ToInt32(dr["Idpersona"]),
                                Identificacion = dr["Identificacion"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                anacimiento = dr["anacimiento"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Niveleducativo = dr["Niveleducativo"].ToString(),
                            });
                        }
                    }
                }
                return olista;

            }

            public MecanicoModelo Obtener(int Idpersona)
            {
                var oPersona = new MecanicoModelo();
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_ObtenerMecanico", conexion);
                    cmd.Parameters.AddWithValue("Idpersona", Idpersona);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            oPersona.Idpersona = Convert.ToInt32(dr["Idpersona"]);
                            oPersona.Identificacion = dr["Identificacion"].ToString();
                            oPersona.Nombre = dr["Nombre"].ToString();
                            oPersona.Apellido = dr["Apellido"].ToString();
                            oPersona.anacimiento = dr["anacimiento"].ToString();
                            oPersona.Direccion = dr["Direccion"].ToString();
                            oPersona.Telefono = dr["Telefono"].ToString();
                            oPersona.Niveleducativo = dr["Niveleducativo"].ToString();

                    }
                    }
                }
                return oPersona;

            }

            public bool Guardar(MecanicoModelo opersona)
            {
                bool rpta;
                try
                {
                    var cn = new Conexion();
                    using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                    {
                        conexion.Open();
                        SqlCommand cmd = new SqlCommand("sp_GuardarMecanico", conexion);
                        cmd.Parameters.AddWithValue("Identificacion", opersona.Identificacion);
                        cmd.Parameters.AddWithValue("Nombre", opersona.Nombre);
                        cmd.Parameters.AddWithValue("Apellido", opersona.Apellido);
                        cmd.Parameters.AddWithValue("anacimiento", opersona.anacimiento);
                        cmd.Parameters.AddWithValue("Telefono", opersona.Telefono);
                        cmd.Parameters.AddWithValue("Direccion", opersona.Direccion);
                        cmd.Parameters.AddWithValue("Niveleducativo", opersona.Niveleducativo);
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
            public bool Editar(MecanicoModelo opersona)
            {
                bool rpta;
                try
                {
                    var cn = new Conexion();
                    using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                    {
                        conexion.Open();
                        SqlCommand cmd = new SqlCommand("sp_EditarMecanico", conexion);
                        cmd.Parameters.AddWithValue("Idpersona", opersona.Idpersona);
                        cmd.Parameters.AddWithValue("Identificacion", opersona.Identificacion);
                        cmd.Parameters.AddWithValue("Nombre", opersona.Nombre);
                        cmd.Parameters.AddWithValue("Apellido", opersona.Apellido);
                        cmd.Parameters.AddWithValue("anacimiento", opersona.anacimiento);
                        cmd.Parameters.AddWithValue("Direccion", opersona.Direccion);
                        cmd.Parameters.AddWithValue("Telefono", opersona.Telefono);
                        cmd.Parameters.AddWithValue("Niveleducativo", opersona.Niveleducativo);
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
            public bool Eliminar(int Idpersona)
            {
                bool rpta;
                try
                {
                    var cn = new Conexion();
                    using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                    {
                        conexion.Open();
                        SqlCommand cmd = new SqlCommand("sp_EliminarMecanico", conexion);
                        cmd.Parameters.AddWithValue("Idpersona", Idpersona);
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

