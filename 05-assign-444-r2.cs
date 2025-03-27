#include "helpers.cs"

AddResults(_444-r2, Persons((PsychSheetPosition(_444) <= 24)))

AssignScramblers(_444-r2, 1, 3)
AssignScramblers(_444-r2, 2, 3)
AssignCompetitors(_444-r2)
ReAssignScramblers(_444-r2)
AssignStaff(
	_444-r2,
	true,
	Persons(true),
	DefaultJobs(_444-r2),
	DefaultStaffScorers(_444-r2)
)
ManuallyAssign(Persons(And(ChillsEvent(_444), CompetingInRound(_444-r2))), _444-r2, "Salón de actos", 1, "staff-Chill")
AssignStaff(_444-r2, true, Persons(HasRole("staff-dataentry")), [Job("dataentry", 1)], DefaultStaffScorers(_444-r2))