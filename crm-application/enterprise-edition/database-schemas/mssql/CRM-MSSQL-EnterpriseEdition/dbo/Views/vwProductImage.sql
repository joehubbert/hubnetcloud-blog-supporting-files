CREATE VIEW [dbo].[vwProductImage]
AS

SELECT
P.[ProductId] AS [Product Id],
P.[ProductName] AS [Product Name],
PI.[ProductImageId] AS [Product Image Id],
PI.[ProductImage] AS [Product Image],
PI.[ProductImageAltText] AS [Product Image Alt Text],
PI.[ProductImageCaption] AS [Product Image Caption],
PI.[ProductImageDisplayOrder] AS [Product Image Display Order],
PI.[ProductImageIsThumbnail] AS [Product Image Is Thumbnail],
P.[ActiveStatus] AS [Product Active Status],
PI.[CreatedTimestampUTC] AS [Created Timestamp UTC],
PI.[CreatedBy] AS [Created By],
PI.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PI.[ModifiedBy] AS [Modified By]
FROM [dbo].[ProductImage] PI
INNER JOIN [dbo].[Product] P ON PI.[ProductId] = P.[ProductId]