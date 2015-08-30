create procedure dbo.SelectPerfomancesPage
@offset int,
@fetch int,
@startDate datetime2,
@endDate datetime2,
@name nvarchar(50)
as
	
begin
	SELECT 
    p.[Id] AS [Id], 
    p.[Name] AS [Name], 
    p.[Description] AS [Description]
    FROM [dbo].[Perfomances] AS p
	left join [dbo].[PlayPeriods] as pp
		on
			pp.PerfomanceId = p.Id
	Where
		p.Name like  '%' + @name+ '%'
		and
		pp.StartDate >= @startDate
		and
		pp.EndDate <= @endDate

    ORDER BY p.[Name] ASC
    
	OFFSET @offset ROWS FETCH NEXT @fetch ROWS ONLY 
end

