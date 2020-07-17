-- ================================================
-- Template generated from Template Explorer using:
-- Create Trigger (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- See additional Create Trigger templates for more
-- examples of different Trigger statements.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		c137-max
-- Create date: 2020/7/10
-- Description:	保护网站管理员不被删光
-- =============================================
CREATE TRIGGER ProtectAdminUser 
   ON  users 
   AFTER DELETE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @userid int
	declare @DeletedUserId int
	set @userid = 126
	SELECT @DeletedUserId = user_id From deleted
	if @userid = @DeletedUserId
		ROLLBACK
	else
		print '不是126号管理员'
	
		
    -- Insert statements for trigger here

END
GO
