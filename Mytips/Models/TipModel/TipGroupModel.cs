using Mytips.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mytips.Models.TipModel
{
    public class TipGroupModel
    {
        [DisableParam(Update = false)]
        [Display(Name ="GroupID")]
        public int TIP_GROUP_ID { get; set; }
        [Display(Name = "ParentGroupID")]
        public int PARENT_TIP_GROUP_ID { get; set; }
        [Display(Name = "Level")]
        [DisableParam]
        public int LEVEL { get; set; }
        [Display(Name = "TipGroupName")]
        public string TIP_GROUP_NAME { get; set; }
        [Display(Name = "Remark")]
        public string REMARK { get; set; }
        [Display(Name = "Sort")]
        public decimal SORT_NO { get; set; }
        [Display(Name = "DelFlag")]
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
