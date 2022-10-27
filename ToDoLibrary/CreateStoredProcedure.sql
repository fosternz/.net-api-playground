CREATE PROCEDURE [dbo].[spToDo_Create]
	@Task nvarchar(50),
	@AssignedTo int
AS
BEGIN
	INSERT INTO dbo.ToDo (Task, AssignedTo)
	VALUES (@Task, @AssignedTo)
END