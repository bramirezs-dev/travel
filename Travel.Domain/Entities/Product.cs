using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.Common;

namespace Travel.Domain.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
    }
}
