using Mytips.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mytips.Models.TipModel
{
    public class TipHeaderModel
    {
        [DisableParam(Update = false)]
        [Display(Name ="ID")]
        public int TIP_ID { get; set; }
        [Display(Name = "상위ID")]
        public int PARENT_TIP_ID { get; set; }
        [Display(Name = "Level")]
        [DisableParam]
        public int LEVEL { get; set; }
        [Display(Name = "TipLevel")]
        [DisableParam]
        public string TIP_NAME_LEVEL { get; set; }
        [Display(Name = "Tip")]
        public string TIP_NAME { get; set; }
        [Display(Name = "비고")]
        public string REMARK { get; set; }
        [Display(Name = "순서")]
        public decimal SORT_NO { get; set; }
        [Display(Name = "삭제Flag")]
        public string DEL_FLAG { get; set; }
        [Display(Name = "생성일시")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        [DisableParam]
        public DateTime CREATE_DTTM { get; set; }
        [Display(Name = "수정일시")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        [DisableParam]
        public DateTime UPDATE_DTTM { get; set; } 
    }
}
