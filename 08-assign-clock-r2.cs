#include "helpers.cs"

AddResults(_clock-r2, Persons((PsychSheetPosition(_clock) <= 10)))

AssignGroups(_clock-r2, EveryoneSet(), stationRules=[StationAssignmentRule(true, "ascending", RoundPosition(_clock-r1))])
AssignStaff(
	_clock-r2,
	true,
	Persons(true),
	FinalJobs(_clock-r2, 2),
	DefaultStaffScorers(_clock-r2)
)