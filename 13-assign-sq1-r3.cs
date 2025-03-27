#include "helpers.cs"

AddResults(_sq1-r3, Persons((PsychSheetPosition(_sq1) <= 10)))

AssignGroups(_sq1-r3, EveryoneSet(), stationRules=[StationAssignmentRule(true, "ascending", RoundPosition(_sq1-r2))])
AssignStaff(
	_sq1-r3,
	true,
	Persons(true),
	FinalJobs(_sq1-r3, 3),
	DefaultStaffScorers(_sq1-r3)
)