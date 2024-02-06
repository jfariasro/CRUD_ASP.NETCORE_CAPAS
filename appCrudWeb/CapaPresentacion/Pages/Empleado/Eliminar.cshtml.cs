using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CapaPresentacion.Pages.Empleado
{
    public class EliminarModel : PageModel
    {
        CapaNegocio.CN_Empleado CN_Empleado = new CapaNegocio.CN_Empleado();
        public void OnGet(string id)
        {
            CN_Empleado.idempleado = id;
            string mensaje = CN_Empleado.Eliminar();
            Response.Redirect("/Empleado");
        }
    }
}
