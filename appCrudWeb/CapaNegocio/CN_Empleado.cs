using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
	public class CN_Empleado
	{
		CD_Empleado cdEmpleado = new CD_Empleado();
		public string? idempleado { get; set; }
		public string? razonsocial { get; set; }
		public string? fechanacimiento { get; set; }
		public string? edad { get; set; }
		public string? salario { get; set; }

		public string Insertar()
		{
			cdEmpleado.razonsocial = this.razonsocial;
			cdEmpleado.fechanacimiento = DateTime.Parse(this.fechanacimiento);
			cdEmpleado.edad = int.Parse(this.edad);
			cdEmpleado.salario = float.Parse(this.salario);

			string mensaje = cdEmpleado.Insertar();

			return mensaje;
		}

		public string Modificar()
		{
			cdEmpleado.idempleado = int.Parse(this.idempleado);
			cdEmpleado.razonsocial = this.razonsocial;
			cdEmpleado.fechanacimiento = DateTime.Parse(this.fechanacimiento);
			cdEmpleado.edad = int.Parse(this.edad);
			cdEmpleado.salario = float.Parse(this.salario);

			string mensaje = cdEmpleado.Modificar();

			return mensaje;
		}

		public string Eliminar()
		{
			cdEmpleado.idempleado = int.Parse(this.idempleado);
			return cdEmpleado.Eliminar();
		}

		public DataSet Consultar()
		{
			cdEmpleado.razonsocial = this.razonsocial;
			return cdEmpleado.Consultar();
		}

		public DataSet Buscar()
		{
			cdEmpleado.idempleado = int.Parse(this.idempleado);
			return cdEmpleado.Buscar();
		}
	}
}
