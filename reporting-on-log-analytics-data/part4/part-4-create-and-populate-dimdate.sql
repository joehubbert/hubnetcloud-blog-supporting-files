--Run in the context of reportingDatabase
--1. Create DimDate table

CREATE TABLE [dbo].[DimDate] 
(
	[Date_Value] DATE NOT NULL,
	[Day_Number_Month] TINYINT NOT NULL,
	[Day_Number_Week] TINYINT NOT NULL,
	[Week_Number_CY] TINYINT NOT NULL,
	[Month_Number_CY] TINYINT NOT NULL,
	[Quarter_Number_CY] TINYINT NOT NULL,
	[Day_Name_Long] NVARCHAR(9) NOT NULL,
	[Day_Name_Short] NCHAR(3) NOT NULL,
	[Month_Name_Long] NVARCHAR(9) NOT NULL,
	[Month_Name_Short] NCHAR(3) NOT NULL,
	[Quarter_Name_CY] NCHAR(2) NOT NULL,
	[Year_Quarter_Name_CY] NVARCHAR(7) NOT NULL,
	[IsWeekday] BIT NOT NULL,
	[IsWeekend] BIT NOT NULL,

CONSTRAINT [PK_DimDate] PRIMARY KEY CLUSTERED 
(
	[Date_Value] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--Populate DimDate

DECLARE @StartDate AS DATE
SET @StartDate = '2020-01-01'

DECLARE @EndDate AS DATE
SET @EndDate = '2025-12-31'

DECLARE @LoopDate AS DATE
SET @Loopdate = @StartDate

--Sets Monday to be the first day of the week
SET DATEFIRST 1

WHILE @Loopdate < @EndDate
BEGIN
	INSERT INTO [dbo].[DimDate]
	VALUES (
		-- [Date_Value]
		@LoopDate,
		--[Day_Number_Month]
        DATEPART(DAY, @LoopDate),
		-- [Day_Number_Week]
		DATEPART(WEEKDAY, @LoopDate),
		-- [Week_Number_CY]		
		DATENAME(WEEK, @LoopDate),
		-- [Month_Number_CY]
		MONTH(@LoopDate),
		--[Quarter_Number_CY]
		DATEPART(QUARTER, @LoopDate),
		-- [Day_Name_Long]
		DATENAME(WEEKDAY, @LoopDate),
		--[Day_Name_Short] 
		FORMAT(@LoopDate, 'ddd'),
		-- [Month_Name_Long]
		DATENAME(MONTH, @LoopDate),
		-- [Month_Name_Short]
		FORMAT(@LoopDate, 'MMM'),
		-- [Quarter_Name_CY]
		CONCAT ('Q',DATEPART(QUARTER, @LoopDate)),
		-- [Year_Quarter_Name_CY]
		CONCAT (YEAR(@LoopDate),'-Q',DATEPART(QUARTER, @LoopDate)),
		--[IsWeekday]
		CASE WHEN DATEPART(WEEKDAY, @LoopDate) IN (1,2,3,4,5) THEN 1 ELSE 0 END,
		-- [IsWeekend]
		CASE WHEN DATEPART(WEEKDAY, @LoopDate) IN (6,7) THEN 1 ELSE 0 END
		)
	SET @Loopdate = DATEADD(DAY, 1, @LoopDate)
END