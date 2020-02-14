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
WITH RECURSIVE
	P( TIP_NAME, TIP_ID, LEVEL, REMARK, SORT_NO, CREATE_DTTM, UPDATE_DTTM) AS (
		SELECT TIP_NAME, TIP_ID, 0, REMARK, SORT_NO, CREATE_DTTM, UPDATE_DTTM
		FROM TIP_HEADER WHERE PARENT_TIP_ID = 0
	UNION ALL
		SELECT C.TIP_NAME, C.TIP_ID, LEVEL + 1 AS LEVEL 
			, C.REMARK, C.SORT_NO, C.CREATE_DTTM, C.UPDATE_DTTM
		FROM TIP_HEADER AS C
		JOIN P ON C.PARENT_TIP_ID = P.TIP_ID
	ORDER BY LEVEL DESC, SORT_NO
)
SELECT substr('..........',TIP_NAME ,LEVEL * 3) || TIP_NAME AS TIP_NAME_LEVEL, * FROM P
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
            Execute(Crud.Update, qry, tipHeaderModel, false);
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
            Execute(Crud.Insert, qry, model, false);
        }
    }
}
