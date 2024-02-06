using CapaNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CapaPresentacion.Pages.Empleado
{
    public class EditarModel : PageModel
    {
        public string errorMensaje = "";
        public CapaNegocio.CN_Empleado CN_Empleado = new CapaNegocio.CN_Empleado();

        public void OnGet(string id)
        {
            this.CN_Empleado.idempleado = id;
            DataSet ds = CN_Empleado.Buscar();

            DataRow fila = ds.Tables[0].Rows[0];

            CN_Empleado.idempleado = fila[0].ToString();
            CN_Empleado.razonsocial = fila[1].ToString();
            CN_Empleado.fechanacimiento = fila[2].ToString();
            CN_Empleado.edad = fila[3].ToString();
            CN_Empleado.salario = fila[4].ToString();
        }

        public void OnPost()
        {
            CN_Empleado.idempleado = Request.Form["id"];
            CN_Empleado.razonsocial = Request.Form["razonsocial"];
            CN_Empleado.fechanacimiento = Request.Form["fechanacimiento"];
            CN_Empleado.edad = Request.Form["edad"];
            CN_Empleado.salario = Request.Form["salario"];

            this.errorMensaje = "";

            if (CN_Empleado.razonsocial.Length == 0)
            {
                this.errorMensaje += "Falta Ingresar la Razón Social <br>";
            }
            if (CN_Empleado.fechanacimiento.Length == 0)
            {
                this.errorMensaje += "Falta Ingresar la Fecha de Nacimiento <br>";
            }
            else if (DateTime.Parse(CN_Empleado.fechanacimiento) > DateTime.Now)
            {
                this.errorMensaje += "La Fecha de Nacimiento no Debe ser Mayor a la Actual <br>";
            }
            if (CN_Empleado.edad.Length == 0)
            {
                this.errorMensaje += "Falta Ingresar la Edad <br>";
            }
            if (CN_Empleado.salario.Length == 0)
            {
                this.errorMensaje += "Falta Ingresar el Salario <br>";
            }
            if (this.errorMensaje.Length > 0)
            {
                return;
            }

            string mensaje = CN_Empleado.Modificar();

            if (mensaje == null)
            {
                CN_Empleado = new CapaNegocio.CN_Empleado();
                Response.Redirect("/Empleado");
            }
            else
            {
                errorMensaje = mensaje;
            }
        }

    }
}
