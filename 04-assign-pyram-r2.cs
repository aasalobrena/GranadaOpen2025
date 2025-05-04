#include "helpers.cs"

# AddResults(_pyram-r2, Persons((PsychSheetPosition(_pyram) <= 32)))

AssignScramblers(_pyram-r2, 1, 3)
AssignScramblers(_pyram-r2, 2, 3)
AssignCompetitors(_pyram-r2)
ReAssignScramblers(_pyram-r2)
AssignStaff(
	_pyram-r2,
	true,
	Persons(true),
	DefaultJobs(_pyram-r2),
	DefaultStaffScorers(_pyram-r2)
)
ManuallyAssign(Persons(And(ChillsEvent(_pyram), CompetingInRound(_pyram-r2))), _pyram-r2, "Salón de actos", 1, "staff-Chill")
AssignStaff(_pyram-r2, true, Persons(HasRole("staff-dataentry")), [Job("dataentry", 1)], DefaultStaffScorers(_pyram-r2))