using EvaluacionTecnica.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvaluacionTecnica.Models
{
    public class Role: Audit
    {
        [Key]
        public long Id { get; set; }
        public string Nombre { get; set; }
    }
}