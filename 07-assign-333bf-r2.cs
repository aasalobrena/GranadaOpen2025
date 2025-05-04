#include "helpers.cs"

# AddResults(_333bf-r2, Persons((PsychSheetPosition(_333bf) <= 12)))

AssignGroups(_333bf-r2, EveryoneSet(), stationRules=[StationAssignmentRule(true, "ascending", RoundPosition(_333bf-r1))])
AssignStaff(
	_333bf-r2,
	true,
	Persons(true),
	FinalJobs(_333bf-r2, 2),
	DefaultStaffScorers(_333bf-r2)
)