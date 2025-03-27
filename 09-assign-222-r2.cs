#include "helpers.cs"

AddResults(_222-r2, Persons((PsychSheetPosition(_222) <= 48)))

AssignScramblers(_222-r2, 1, 3)
AssignScramblers(_222-r2, 2, 3)
AssignScramblers(_222-r2, 3, 3)
AssignCompetitors(_222-r2)
ReAssignScramblers(_222-r2)
AssignStaff(
	_222-r2,
	true,
	Persons(true),
	DefaultJobs(_222-r2),
	DefaultStaffScorers(_222-r2)
)
ManuallyAssign(Persons(And(ChillsEvent(_222), CompetingInRound(_222-r2))), _222-r2, "Salón de actos", 1, "staff-Chill")
ManuallyAssign(Persons(And(ChillsEvent(_222), CompetingInRound(_222-r2))), _222-r2, "Salón de actos", 2, "staff-Chill")
AssignStaff(_222-r2, true, Persons(HasRole("staff-dataentry")), [Job("dataentry", 1)], DefaultStaffScorers(_222-r2))