#include "helpers.cs"

AddResults(_pyram-r3, Persons((PsychSheetPosition(_pyram) <= 12)))

AssignGroups(_pyram-r3, EveryoneSet(), stationRules=[StationAssignmentRule(true, "ascending", RoundPosition(_pyram-r2))])
AssignStaff(
	_pyram-r3,
	true,
	Persons(true),
	FinalJobs(_pyram-r3, 3),
	DefaultStaffScorers(_pyram-r3)
)