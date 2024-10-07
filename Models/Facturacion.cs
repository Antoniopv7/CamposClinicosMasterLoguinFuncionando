using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gestion_Del_Presupuesto.Models
{
    public class Facturacion
    {
        [Key]
        public int Id_Facturacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public decimal Monto { get; set; }
        public int NumeroFactura { get; set; }

        public int? Id_Convenio { get; set; }

        public string Institucion { get; set; }

        public DateTime FechaEmision { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public string Descripcion { get; set; }


    }
}
