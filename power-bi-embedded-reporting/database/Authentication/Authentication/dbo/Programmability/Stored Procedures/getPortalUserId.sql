CREATE PROCEDURE [dbo].[getPortalUserId]
	@portalUserEmailAddress NVARCHAR(50),
	@portalUserId INT OUTPUT
AS

SELECT @portalUserId = [portalUserId]
FROM [dbo].[portalUser]
WHERE [portalUserEmailAddress] = @portalUserEmailAddress

RETURN