using EvaluacionTecnica.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EvaluacionTecnica.Models
{
    public class Usuario: Audit
    {
        [Key]
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long Cedula { get; set; }
        public string Usuario_Nombre { get; set; }
        public string Contraseña { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }


        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}