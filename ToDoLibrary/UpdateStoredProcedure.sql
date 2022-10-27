CREATE PROCEDURE [dbo].[spToDo_UpdateTask]
	@Task nvarchar(50),
	@AssignedTo int,
	@TodoId int
AS
BEGIN
	UPDATE dbo.Todo
	SET Task = @Task
	WHERE Id = @TodoId AND AssignedTo =@AssignedTo
END