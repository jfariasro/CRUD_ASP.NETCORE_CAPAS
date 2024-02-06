using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CapaPresentacion.Pages.Empleado
{
    public class IndexModel : PageModel
    {
        CapaNegocio.CN_Empleado CN_Empleado = new CapaNegocio.CN_Empleado();
        public List<CapaNegocio.CN_Empleado> listaEmpleado = new List<CapaNegocio.CN_Empleado>();
        
        public void OnGet()
        {
            this.Consultar("");
        }

        public void OnPost()
        {
        }

        private void Consultar(string texto)
        {
            CN_Empleado.razonsocial = texto;
            DataSet ds = CN_Empleado.Consultar();
            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                CN_Empleado = new CapaNegocio.CN_Empleado();
                CN_Empleado.idempleado = fila[0].ToString();
                CN_Empleado.razonsocial = fila[1].ToString();
                CN_Empleado.fechanacimiento = fila[2].ToString();
                CN_Empleado.edad = fila[3].ToString();
                CN_Empleado.salario = fila[4].ToString();
                listaEmpleado.Add(CN_Empleado);
            }
        }
    }
}
