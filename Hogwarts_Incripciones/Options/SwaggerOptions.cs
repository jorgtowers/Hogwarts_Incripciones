using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts_Incripciones.Options
{
    /// <summary>
    /// Configuraciones para servicio de Swagger
    /// </summary>
    public class SwaggerOptions
    {
        public string Description{ get; set; }
        public string UIEndpoint { get; set; }
        public string PathJson { get; set; }
        public string RoutePrefix { get; set; }
    }
}
