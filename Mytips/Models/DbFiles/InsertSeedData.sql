INSERT INTO TIP_HEADER (
    PARENT_TIP_ID  
    , TIP_NAME
    , REMARK
    , SORT_NO
    , DEL_FLAG
    , CREATE_DTTM
    , UPDATE_DTTM
) VALUES (
    0
    , 'TEST'
    , 'TEST'
    , 1
    , 'N'
    , datetime('now','localtime')
    , datetime('now','localtime')
);
INSERT INTO TIP_DETAIL(
	TIP_CONTENT
	, TIP_CONTENT_FILE
	, REMARK
    , SORT_NO
    , DEL_FLAG
    , CREATE_DTTM
    , UPDATE_DTTM
) VALUES (
	'TEST'
	, NULL
	, 'TEST'
	, 0
	, 'N'
	, datetime('now','localtime')
	, datetime('now','localtime')
);
	