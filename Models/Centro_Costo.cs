using System.ComponentModel.DataAnnotations;

namespace Gestion_Del_Presupuesto.Models
{
    public class Centro_Costo
    {
        [Key]
        public int Id_Centro_Costo { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public decimal PresupuestoAsignado { get; set; }

        [Required]
        public string Responsable { get; set; }

        [Required]
        public int Id_Presupuesto { get; set; }
    }
}
