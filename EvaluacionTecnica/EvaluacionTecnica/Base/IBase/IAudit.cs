using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionTecnica.Base.IBase
{
    interface IAudit
    {
        string Usuario_Transacion { get; set; }
        DateTime? Fecha_Transacion { get; set; }

        DateTime? CreationTime { get; set; }
        long? CreatorUserId { get; set; }
        DateTime? LastModificationTime { get; set; }
        long? LastModifierUserId { get; set; }
        long? DeleterUserId { get; set; }
        DateTime? DeletionTime { get; set; }
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
    }
}
