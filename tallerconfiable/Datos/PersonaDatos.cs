using System.Data.SqlClient;
//using Tallerconfiable.Models;
using System.Data;
using System.Collections.Generic;
using System;
using tallerconfiable.Datos;
using tallerconfiable.Models;
using System.Drawing.Printing;

namespace tallerconfiable.Datos
{
    public class PersonaDatos
    {
        public List<PersonaModelo> Listar()
        {
            var olista = new List<PersonaModelo>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olista.Add(new PersonaModelo()
                        {
                            Idpersona = Convert.ToInt32(dr["Idpersona"]),
                            Identificacion = dr["Identificacion"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            anacimiento = dr["anacimiento"].ToString(),
                            Ciudad = dr["Ciudad"].ToString(),
                            Email = dr["Email"].ToString(),
                        });
                    }
                }
            }
            return olista;

        }

        public PersonaModelo Obtener(int Idpersona)
        {
            var oPersona = new PersonaModelo();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
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
                        oPersona.Ciudad = dr["Ciudad"].ToString();
                        oPersona.Email = dr["Email"].ToString();

                    }
                }
            }
            return oPersona;

        }

        public bool Guardar(PersonaModelo opersona)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarPropietario", conexion);
                    cmd.Parameters.AddWithValue("Identificacion", opersona.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre", opersona.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", opersona.Apellido);
                    cmd.Parameters.AddWithValue("anacimiento", opersona.anacimiento);
                    cmd.Parameters.AddWithValue("Ciudad", opersona.Ciudad);
                    cmd.Parameters.AddWithValue("Email", opersona.Email);
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
        public bool Editar(PersonaModelo opersona)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("Idpersona", opersona.Idpersona);
                    cmd.Parameters.AddWithValue("Identificacion", opersona.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre", opersona.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", opersona.Apellido);
                    cmd.Parameters.AddWithValue("anacimiento", opersona.anacimiento);
                    cmd.Parameters.AddWithValue("Ciudad", opersona.Ciudad);
                    cmd.Parameters.AddWithValue("Email", opersona.Email);
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
            Console.WriteLine("click eliminar");
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    Console.WriteLine(Idpersona);
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
