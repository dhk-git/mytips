using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mytips.Models.TipModel
{
    [Table(name: "TIP_HEADER")]
    public class TipHeaderModel
    {
        [Key]
        public int TIP_ID { get; set; }
        public int PARENT_TIP_ID { get; set; }
        public string TIP_NAME { get; set; }
        public string REMARK { get; set; }
        public decimal SORT_NO { get; set; }
        public string DEL_FLAG { get; set; }
        public DateTime CREATE_DTTM { get; set; }
        public DateTime UPDATE_DTTM { get; set; }
    }
}
