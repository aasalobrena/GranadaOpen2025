#include "helpers.cs"

AddResults(_222-r3, Persons((PsychSheetPosition(_222) <= 12)))

AssignGroups(_222-r3, EveryoneSet(), stationRules=[StationAssignmentRule(true, "ascending", RoundPosition(_222-r2))])
AssignStaff(
	_222-r3,
	true,
	Persons(true),
	FinalJobs(_222-r3, 3),
	DefaultStaffScorers(_222-r3)
)