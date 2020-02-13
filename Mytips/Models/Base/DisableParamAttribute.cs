using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mytips.Models.Base
{
    public class DisableParamAttribute : Attribute
    {
        public bool Insert { get; set; } = true;
        public bool Update { get; set; } = true;
        public bool Delete { get; set; } = true;
    }
}
