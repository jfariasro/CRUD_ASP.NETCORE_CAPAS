using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CapaDatos
{
	public class CD_Empleado
	{
        [Key]
        public int? idempleado { get; set; }

        [Required]
        public string? razonsocial { get; set; }

        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fechanacimiento { get; set; }

        [Range(0, 150)]
        public int? edad { get; set; }

        [DataType(DataType.Currency)]
        public float? salario { get; set; }

        SqlCommand comando = new SqlCommand();
        CD_Conexion conexion = new CD_Conexion();

        public string Insertar()
        {
            try
            {
                using (SqlConnection connection = conexion.Conectar())
                {
                    using (SqlCommand command = new SqlCommand("insertar_empleado", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@razonsocial", razonsocial);
                        command.Parameters.AddWithValue("@fechanacimiento", fechanacimiento);
                        command.Parameters.AddWithValue("@edad", edad);
                        command.Parameters.AddWithValue("@salario", salario);

                        command.ExecuteNonQuery();
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public string Modificar()
        {
            try
            {
                using (SqlConnection connection = conexion.Conectar())
                {
                    using (SqlCommand command = new SqlCommand("modificar_empleado", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@idempleado", idempleado);
                        command.Parameters.AddWithValue("@razonsocial", razonsocial);
                        command.Parameters.AddWithValue("@fechanacimiento", fechanacimiento);
                        command.Parameters.AddWithValue("@edad", edad);
                        command.Parameters.AddWithValue("@salario", salario);

                        command.ExecuteNonQuery();
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar()
        {
            try
            {
                using (SqlConnection connection = conexion.Conectar())
                {
                    using (SqlCommand command = new SqlCommand("eliminar_empleado", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@idempleado", idempleado);

                        command.ExecuteNonQuery();
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DataSet Consultar()
        {
            try
            {
                using (var datos = new DataSet())
                {
                    using (var adaptador = new SqlDataAdapter())
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.CommandText = "consultar_empleado";
                        comando.Parameters.Clear();
                        comando.Parameters.AddWithValue("@razonsocial", razonsocial);

                        using (SqlConnection connection = conexion.Conectar())
                        {
                            comando.Connection = connection;
                            adaptador.SelectCommand = comando;
                            adaptador.Fill(datos);
                        }
                    }

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la consulta: {ex.Message}");
                return null;
            }
        }

        public DataSet Buscar()
        {
            try
            {
                using (var datos = new DataSet())
                {
                    using (var adaptador = new SqlDataAdapter())
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.CommandText = "buscar_empleado";
                        comando.Parameters.Clear();
                        comando.Parameters.AddWithValue("@idempleado", idempleado);

                        using (SqlConnection connection = conexion.Conectar())
                        {
                            comando.Connection = connection;
                            adaptador.SelectCommand = comando;
                            adaptador.Fill(datos);
                        }
                    }

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la consulta: {ex.Message}");
                return null;
            }
        }

    }
}
