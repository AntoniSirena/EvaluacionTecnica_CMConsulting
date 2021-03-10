using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluacionTecnica.InternalMessagingCode
{
    public static class Constants
    {

        public static class Messages
        {
            public const string Message200 = "Registro creado con éxito";

            public const string Message201 = "Registro actualizado con éxito";

            public const string Message202 = "Registro eliminado con éxito";

        }


        public static class Errors
        {
            public const string CodeError500 = "500";
            public const string MessageError500 = "Estimado usuario ha ocurrido un error procesando su solicitud";
        }

    }
}