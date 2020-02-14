using Mytips.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mytips.Models.TipModel
{
    public class TipDetailModel
    {
        [DisableParam(Update = false)]
        [Display(Name = "DetailID")]
        public int TIP_DETAIL_ID { get; set; }
        [Display(Name = "내용")]
        public string TIP_CONTENT { get; set; }
        [Display(Name = "내용파일")]
        public byte[] TIP_CONTENT_FILE { get; set; }
        [Display(Name = "비고")]
        public string REMARK { get; set; }
        [Display(Name = "순서")]
        public decimal SORT_NO { get; set; }
        [Display(Name = "삭제FLAG")]
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
