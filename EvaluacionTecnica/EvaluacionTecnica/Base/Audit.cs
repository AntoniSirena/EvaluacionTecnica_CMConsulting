using EvaluacionTecnica.Base.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluacionTecnica.Base
{
    public abstract class Audit : IAudit
    {
        public DateTime? CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Usuario_Transacion { get; set; }
        public DateTime? Fecha_Transacion { get; set; }
    }
}