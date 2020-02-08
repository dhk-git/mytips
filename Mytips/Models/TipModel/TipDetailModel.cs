using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mytips.Models.TipModel
{
    [Table(name:"TIP_DETAIL")]
    public class TipDetailModel
    {
        [Key]
        public int TIP_DETAIL_ID { get; set; }
        public string TIP_CONTENT { get; set; }
        public byte[] TIP_CONTENT_FILE { get; set; }
        public string REMARK { get; set; }
        public decimal SORT_NO { get; set; }
        public string DEL_FLAG { get; set; }
        public DateTime CREATE_DTTM { get; set; }
        public DateTime UPDATE_DTTM { get; set; }
    }
}
