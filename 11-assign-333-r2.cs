#include "helpers.cs"

# AddResults(_333-r2, Persons((PsychSheetPosition(_333) <= 32)))

AssignScramblers(_333-r2, 1, 3)
AssignScramblers(_333-r2, 2, 3)
AssignCompetitors(_333-r2)
ReAssignScramblers(_333-r2)
AssignStaff(
	_333-r2,
	true,
	Persons(true),
	DefaultJobs(_333-r2),
	DefaultStaffScorers(_333-r2)
)
ManuallyAssign(Persons(And(ChillsEvent(_333), CompetingInRound(_333-r2))), _333-r2, "Salón de actos", 1, "staff-Chill")
AssignStaff(_333-r2, true, Persons(HasRole("staff-dataentry")), [Job("dataentry", 1)], DefaultStaffScorers(_333-r2))