#include "helpers.cs"

AddResults(_444-r3, Persons((PsychSheetPosition(_444) <= 10)))

AssignGroups(_444-r3, EveryoneSet(), stationRules=[StationAssignmentRule(true, "ascending", RoundPosition(_444-r2))])
AssignStaff(
	_444-r3,
	true,
	Persons(true),
	FinalJobs(_444-r3, 3),
	DefaultStaffScorers(_444-r3)
)