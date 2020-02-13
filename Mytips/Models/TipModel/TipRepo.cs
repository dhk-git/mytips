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
            return QueryList<TipHeaderModel>(qry, args , false);
        }

        public TipHeaderModel SelectTipHeaderModel(TipModelArgs args)
        {
            string qry;
            qry = @"
SELECT * FROM TIP_HEADER
WHERE TIP_ID = @TIP_ID
";
            return QuerySingle<TipHeaderModel>(qry, new { TIP_ID = args.Select_Tip_Id }, false);
        }
        
        public void UpdateTipHeaderModel(TipHeaderModel tipHeaderModel)
        {
            string qry = @"
UPDATE TIP_HEADER 
    SET 
    PARENT_TIP_ID = @PARENT_TIP_ID
    , TIP_NAME    = @TIP_NAME
    , REMARK      = @REMARK
    , SORT_NO       = @SORT_NO
    , DEL_FLAG      = @DEL_FLAG
    , UPDATE_DTTM   = datetime('now','localtime')
WHERE TIP_ID = @TIP_ID
";
            Execute(Cud.Update, qry, tipHeaderModel, false);
        }
        
        public void InsertTipHeaderModel(TipHeaderModel model)
        {
            string qry = @"

INSERT INTO TIP_HEADER (
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
    , datetime('now','localtime')
    , datetime('now','localtime')
)
";
            Execute(Cud.Insert, qry, model, false);
        }
    }
}
