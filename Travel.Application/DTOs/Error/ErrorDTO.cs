using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.DTOs.Error
{
    public class ErrorDTO
    {
        /// <summary>
        /// Describe un error por código mensaje y campo originador.
        /// </summary>
        public string InternalCode { get; set; }
        /// <summary>
        /// Receptor del mensaje de error generado
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// Receptor del campo de genero el error
        /// </summary>
        public string Field { get; set; }
    }
}
