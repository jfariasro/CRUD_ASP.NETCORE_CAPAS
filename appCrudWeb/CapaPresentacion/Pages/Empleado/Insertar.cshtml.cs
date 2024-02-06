using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapaPresentacion.Pages.Empleado
{
    public class InsertarModel : PageModel
    {
        public string errorMensaje = "";
        public CapaNegocio.CN_Empleado CN_Empleado = new CapaNegocio.CN_Empleado();

        public void OnGet()
        {
        }

        public void OnPost()
        {
            CN_Empleado.razonsocial = Request.Form["razonsocial"];
            CN_Empleado.fechanacimiento = Request.Form["fechanacimiento"];
            CN_Empleado.edad = Request.Form["edad"];
            CN_Empleado.salario = Request.Form["salario"];

            this.errorMensaje = "";

            if(CN_Empleado.razonsocial.Length == 0)
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
            if(this.errorMensaje.Length > 0)
            {
                return;
            }

            string mensaje = CN_Empleado.Insertar();

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
