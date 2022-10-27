CREATE PROCEDURE [dbo].[spToDo_GetOneAssigned]
	@AssignedTo int,
	@TodoId int
AS
BEGIN
	SELECT *
	FROM dbo.Todo
	Where AssignedTo = @AssignedTo
		AND Id = @TodoId;
END