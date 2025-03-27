#include "helpers.cs"

AddResults(_333-r3, Persons((PsychSheetPosition(_333) <= 12)))

AssignGroups(_333-r3, EveryoneSet(), stationRules=[StationAssignmentRule(true, "ascending", RoundPosition(_333-r2))])
AssignStaff(
	_333-r3,
	true,
	Persons(true),
	FinalJobs(_333-r3, 3),
	DefaultStaffScorers(_333-r3)
)