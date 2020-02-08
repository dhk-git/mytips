using Mytips.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mytips.Models.TipModel
{
    public class TipRepo : RepoBase
    {
        public List<TipHeaderModel> SelectTipHeaderModels(TipModelArgs args)
        {
            string qry;
            qry = @"
SELECT * FROM TIP_HEADER
";
            return Query<TipHeaderModel>(qry, false);
        }
        public void SaveTipHeaderModel(TipHeaderModel model)
        {
            string qry = @"
INSERT INTO TIP_DETAIL (
    PARENT_TIP_ID
    , TIP_NAME
    , REMARK
    , SORT_NO
    , DEL_FLAG
    , CREATE_DTTM
    , UPDATE_DTTM
) VALUES (
    @PARENT_TIP_ID
    , @TIP_NAME
    , @REMARK
    , @SORT_NO
    , @DEL_FLAG
    , @CREATE_DTTM
    , @UPDATE_DTTM
)
";
            Execute(qry, model, false);
        }
    }
}
