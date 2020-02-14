using Mytips.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mytips.Models.TipModel
{
    public class TipModel
    {
        [DisableParam(Update = false)]
        [Display(Name = "TipID")]
        public int TIP_ID { get; set; }
        [Display(Name = "TipGroupID")]
        public int TIP_GROUP_ID { get; set; }
        [Display(Name = "Title")]
        public string TIP_TITLE { get; set; }
        [Display(Name = "Content")]
        public string TIP_CONTENT { get; set; }
        [Display(Name = "ContentFile")]
        public byte[] TIP_CONTENT_FILE { get; set; }
        [Display(Name = "Remark")]
        public string REMARK { get; set; }
        [Display(Name = "Sort")]
        public decimal SORT_NO { get; set; }
        [Display(Name = "DelFLAG")]
        public string DEL_FLAG { get; set; }
        [Display(Name = "CreateDateTime")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        [DisableParam]
        public DateTime CREATE_DTTM { get; set; }
        [Display(Name = "UpdateDateTime")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        [DisableParam]
        public DateTime UPDATE_DTTM { get; set; }
    }
}
