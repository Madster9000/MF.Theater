create procedure dbo.SelectPerfomancesPage
@offset int,
@fetch int
as
	
begin
	SELECT 
    p.[Id] AS [Id], 
    p.[Name] AS [Name], 
    p.[Description] AS [Description]
    FROM [dbo].[Perfomances] AS p
    ORDER BY p.[Name] ASC
    
	OFFSET @offset ROWS FETCH NEXT @fetch ROWS ONLY 
end

