﻿using Mytips.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mytips.Models.TipModel
{
    public class TipRepo : RepoBase
    {
        public List<TipGroupModel> SelectTipGroupModels(TipModelArgs args)
        {
            string qry;
            qry = @"
WITH RECURSIVE
	P( TIP_GROUP_NAME, TIP_GROUP_ID, LEVEL, REMARK, SORT_NO, CREATE_DTTM, UPDATE_DTTM) AS (
		SELECT TIP_GROUP_NAME, TIP_GROUP_ID, 0, REMARK, SORT_NO, CREATE_DTTM, UPDATE_DTTM
		FROM TIP_GROUP WHERE PARENT_TIP_GROUP_ID = 0
	UNION ALL
		SELECT C.TIP_GROUP_NAME, C.TIP_GROUP_ID, LEVEL + 1 AS LEVEL 
			, C.REMARK, C.SORT_NO, C.CREATE_DTTM, C.UPDATE_DTTM
		FROM TIP_GROUP AS C
		JOIN P ON C.PARENT_TIP_GROUP_ID = P.TIP_GROUP_ID
	ORDER BY LEVEL DESC, SORT_NO
)
SELECT 
 CASE WHEN LEVEL <> 0 THEN '⤷ ' || TIP_GROUP_NAME ELSE TIP_GROUP_NAME END AS TIP_GROUP_NAME
, TIP_GROUP_ID, LEVEL, REMARK, SORT_NO, CREATE_DTTM, UPDATE_DTTM
FROM P
";
            return QueryList<TipGroupModel>(qry, args , false);
        }

        public TipGroupModel SelectTipGroupModel(TipModelArgs args)
        {
            string qry;
            qry = @"
SELECT * FROM TIP_GROUP
WHERE TIP_GROUP_ID = @TIP_GROUP_ID
";
            return QuerySingle<TipGroupModel>(qry, new { TIP_GROUP_ID = args.Select_Tip_Group_Id }, false);
        }
        
        public void UpdateTipGroupModel(TipGroupModel tipGroupModel)
        {
            string qry = @"
UPDATE TIP_GROUP
    SET 
    PARENT_TIP_GROUP_ID = @PARENT_TIP_GROUP_ID
    , TIP_GROUP_NAME          = @TIP_GROUP_NAME
    , REMARK            = @REMARK
    , SORT_NO           = @SORT_NO
    , DEL_FLAG          = @DEL_FLAG
    , UPDATE_DTTM       = datetime('now','localtime')
WHERE TIP_GROUP_ID = @TIP_GROUP_ID
";
            Execute(Crud.Update, qry, tipGroupModel, false);
        }
        
        public void InsertTipGroupModel(TipGroupModel model)
        {
            string qry = @"

INSERT INTO TIP_GROUP (
    PARENT_TIP_GROUP_ID
    , TIP_GROUP_NAME
    , REMARK
    , SORT_NO
    , DEL_FLAG
    , CREATE_DTTM
    , UPDATE_DTTM
) VALUES (
    @PARENT_TIP_GROUP_ID
    , @TIP_GROUP_NAME
    , @REMARK
    , @SORT_NO
    , @DEL_FLAG
    , datetime('now','localtime')
    , datetime('now','localtime')
)
";
            Execute(Crud.Insert, qry, model, false);
        }



        //TipDetail

        public List<TipModel> SelectTipModels(TipModelArgs args)
        {
            string qry = @"
SELECT 
    TIP_ID
    , TIP_GROUP_ID
    , TIP_TITLE
    , TIP_CONTENT
    , REMARK
    , SORT_NO
    , DEL_FLAG
    , CREATE_DTTM
    , UPDATE_DTTM
FROM TIP
WHERE TIP_GROUP_ID = @TIP_GROUP_ID
";
            return QueryList<TipModel>(qry, new { TIP_GROUP_ID = args.Select_Tip_Group_Id }, false);
        }

        public void UpdateTipModel(TipModel tipModel)
        {
            string qry = @"
UPDATE TIP 
    SET
    TIP_GROUP_ID    = @TIP_GROUP_ID 
    , TIP_TITLE     = @TIP_TITLE  
    , TIP_CONTENT   = @TIP_CONTENT
    , REMARK        = @REMARK     
    , SORT_NO       = @SORT_NO    
    , DEL_FLAG      = @DEL_FLAG   
    , UPDATE_DTTM   = datetime('now','localtime')
WHERE TIP_ID = @TIP_ID
";
            Execute(Crud.Update, qry, tipModel, false);
        }

        public TipModel SelectTipModel(TipModelArgs args)
        {
            string qry = @"
SELECT 
    TIP_ID
    , TIP_GROUP_ID
    , TIP_TITLE
    , TIP_CONTENT
    , REMARK
    , SORT_NO
    , DEL_FLAG
    , CREATE_DTTM
    , UPDATE_DTTM
FROM TIP
WHERE TIP_ID = @TIP_ID
";
            return QuerySingle<TipModel>(qry, new {TIP_ID = args.Select_Tip_Id }, false);
        }

        public void InsertTipModel(TipModel tipModel)
        {
            string qry = @"
INSERT INTO TIP (
    TIP_GROUP_ID
    , TIP_TITLE
    , TIP_CONTENT
    , REMARK
    , SORT_NO
    , DEL_FLAG
    , CREATE_DTTM
    , UPDATE_DTTM
) VALUES (
    @TIP_GROUP_ID
    , @TIP_TITLE
    , @TIP_CONTENT
    , @REMARK
    , @SORT_NO
    , @DEL_FLAG
    , datetime('now','localtime')
    , datetime('now','localtime')
)";
            Execute(Crud.Insert, qry, tipModel, false);
        }

    }
}
