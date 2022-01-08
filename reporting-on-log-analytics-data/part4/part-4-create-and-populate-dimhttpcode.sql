USE [reportingDatabase]

--1.Create DimHttpCode table
CREATE TABLE [dbo].[DimHTTPCode] (
    
    [Http_Code_Key] INT IDENTITY(1,1) NOT NULL,
    [Http_Error_Code] INT NOT NULL,
    [Http_Error_Code_Description] NVARCHAR(150) NOT NULL,

CONSTRAINT [PK_DimHTTPCode] PRIMARY KEY CLUSTERED 
(
	[Http_Code_Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

--2.Populate DimHttpCode table
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('100','Continue')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('101','Switching Protocols')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('102','Processing')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('103','Early Hints')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('200','OK')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('201','Created')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('202','Accepted')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('203','Non-Authoritative Information')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('204','No Content')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('205','Reset Content')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('206','Partial Content')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('207','Multi-Status')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('208','Already Reported')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('226','IM Used')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('300','Multiple Choices')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('301','Moved Permanently')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('302','Found')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('303','See Other')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('304','Not Modified')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('305','Use Proxy')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('306','(Unused)')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('307','Temporary Redirect')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('308','Permanent Redirect')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('400','Bad Request')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('401','Unauthorized')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('402','Payment Required')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('403','Forbidden')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('404','Not Found')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('405','Method Not Allowed')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('406','Not Acceptable')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('407','Proxy Authentication Required')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('408','Request Timeout')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('409','Conflict')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('410','Gone')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('411','Length Required')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('412','Precondition Failed')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('413','Content Too Large')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('414','URI Too Long')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('415','Unsupported Media Type')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('416','Range Not Satisfiable')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('417','Expectation Failed')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('418','(Unused)')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('421','Misdirected Request')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('422','Unprocessable Content')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('423','Locked')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('424','Failed Dependency')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('425','Too Early')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('426','Upgrade Required')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('427','Unassigned')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('428','Precondition Required')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('429','Too Many Requests')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('430','Unassigned')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('431','Request Header Fields Too Large')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('451','Unavailable For Legal Reasons')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('500','Internal Server Error')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('501','Not Implemented')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('502','Bad Gateway')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('503','Service Unavailable')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('504','Gateway Timeout')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('505','HTTP Version Not Supported')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('506','Variant Also Negotiates')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('507','Insufficient Storage')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('508','Loop Detected')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('509','Unassigned')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('510','Not Extended (OBSOLETED)')
INSERT INTO [dbo].[DimHTTPCode] ([Http_Error_Code], [Http_Error_Code_Description]) VALUES ('511','Network Authentication Required')