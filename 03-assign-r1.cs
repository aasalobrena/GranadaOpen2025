#include "helpers.cs"

# 1 is other-checkin
ManuallyAssignActivity(1, Persons(true))

# 2 is other-tutorial
ManuallyAssignActivity(2, Persons(IsNull(WcaId())), "staff-Alumno")
ManuallyAssignActivity(2, [2018CAST11], "staff-judge")
ManuallyAssignActivity(2, [2010GARC02])

Map(Events(), AddResults(RoundForEvent(1), Persons(CompetingIn())))

AssignScramblers(_pyram-r1, 1, 3)
AssignScramblers(_pyram-r1, 2, 3)
AssignScramblers(_pyram-r1, 3, 3)
AssignScramblers(_pyram-r1, 4, 3)
AssignCompetitors(_pyram-r1)
ReAssignScramblers(_pyram-r1)
AssignStaff(
	_pyram-r1,
	true,
	Persons(true),
	DefaultJobs(_pyram-r1),
	DefaultStaffScorers(_pyram-r1)
)
ManuallyAssign(Persons(ChillsEvent(_pyram)), _pyram-r1, "Salón de actos", 1, "staff-Chill")
ManuallyAssign(Persons(ChillsEvent(_pyram)), _pyram-r1, "Salón de actos", 2, "staff-Chill")
ManuallyAssign(Persons(ChillsEvent(_pyram)), _pyram-r1, "Salón de actos", 3, "staff-Chill")
AssignStaff(_pyram-r1, true, Persons(HasRole("staff-dataentry")), [Job("dataentry", 1)], DefaultStaffScorers(_pyram-r1))

AssignScramblers(_444-r1, 1, 3)
AssignScramblers(_444-r1, 2, 3)
AssignScramblers(_444-r1, 3, 3)
AssignCompetitors(_444-r1)
ReAssignScramblers(_444-r1)
AssignStaff(
	_444-r1,
	true,
	Persons(true),
	DefaultJobs(_444-r1),
	DefaultStaffScorers(_444-r1)
)
ManuallyAssign(Persons(ChillsEvent(_444)), _444-r1, "Salón de actos", 1, "staff-Chill")
ManuallyAssign(Persons(ChillsEvent(_444)), _444-r1, "Salón de actos", 2, "staff-Chill")
AssignStaff(_444-r1, true, Persons(HasRole("staff-dataentry")), [Job("dataentry", 1)], DefaultStaffScorers(_444-r1))

AssignScramblers(_sq1-r1, 1, 3)
AssignScramblers(_sq1-r1, 2, 3)
AssignCompetitors(_sq1-r1)
ReAssignScramblers(_sq1-r1)
AssignStaff(
	_sq1-r1,
	true,
	Persons(true),
	DefaultJobs(_sq1-r1),
	DefaultStaffScorers(_sq1-r1)
)
ManuallyAssign(Persons(ChillsEvent(_sq1)), _sq1-r1, "Salón de actos", 1, "staff-Chill")
AssignStaff(_sq1-r1, true, Persons(HasRole("staff-dataentry")), [Job("dataentry", 1)], DefaultStaffScorers(_sq1-r1))

AssignScramblers(_333bf-r1, 1, 2)
AssignScramblers(_333bf-r1, 2, 2)
AssignCompetitors(_333bf-r1)
ReAssignScramblers(_333bf-r1)
AssignStaff(
	_333bf-r1,
	true,
	Persons(true),
	DefaultJobs(_333bf-r1),
	DefaultStaffScorers(_333bf-r1)
)
ManuallyAssign(Persons(ChillsEvent(_333bf)), _333bf-r1, "Salón de actos", 1, "staff-Chill")
AssignStaff(_333bf-r1, true, Persons(HasRole("staff-dataentry")), [Job("dataentry", 1)], DefaultStaffScorers(_333bf-r1))

AssignScramblers(_clock-r1, 1, 3)
AssignScramblers(_clock-r1, 2, 3)
AssignScramblers(_clock-r1, 3, 3)
AssignCompetitors(_clock-r1)
ReAssignScramblers(_clock-r1)
AssignStaff(
	_clock-r1,
	true,
	Persons(true),
	DefaultJobs(_clock-r1),
	DefaultStaffScorers(_clock-r1)
)
ManuallyAssign(Persons(ChillsEvent(_clock)), _clock-r1, "Salón de actos", 1, "staff-Chill")
ManuallyAssign(Persons(ChillsEvent(_clock)), _clock-r1, "Salón de actos", 2, "staff-Chill")
AssignStaff(_clock-r1, true, Persons(HasRole("staff-dataentry")), [Job("dataentry", 1)], DefaultStaffScorers(_clock-r1))

# 8 is other-lunch
ManuallyAssignActivity(8, [2013ROCA01], "staff-Chef")
ManuallyAssignActivity(8, Persons(In("Lomoqueso", ArrayProperty("food"))), "staff-Lomoqueso")
ManuallyAssignActivity(8, Persons(In("Hamburguesa", ArrayProperty("food"))), "staff-Hamburguesa")
ManuallyAssignActivity(8, Persons(In("Perrito", ArrayProperty("food"))), "staff-Perrito")
ManuallyAssignActivity(8, Persons(In("Otro", ArrayProperty("food"))), "staff-Otro")

# 26 is other-multi
ManuallyAssignActivity(26, Persons(CompetingIn(_333mbf)))
# 27 is 333mbf-r1-a1
ManuallyAssignActivity(27, Persons(CompetingIn(_333mbf)))

AssignScramblersWithMbf(_222-r1, 1, 3)
AssignScramblersWithMbf(_222-r1, 2, 3)
AssignScramblersWithMbf(_222-r1, 3, 3)
AssignScramblersWithMbf(_222-r1, 4, 3)
AssignScramblersWithMbf(_222-r1, 5, 3)
AssignGroups(_222-r1,
	Concat(ChillSet(_222-r1), DelegatesSet(), OrganizersSet(), DeLaTorreSet(), UkuSet(), EveryoneSet()),
	ScramblingCompetingScorers(_222-r1),
	[StationAssignmentRule(true, "ascending", PsychSheetPosition(_222))],
	overwrite=true
)
ReAssignScramblers(_222-r1)
AssignStaff(
	_222-r1,
	true,
	Persons(true),
	DefaultJobs(_222-r1),
	DefaultStaffScorers(_222-r1)
)
ManuallyAssign(Persons(ChillsEvent(_222)), _222-r1, "Salón de actos", 1, "staff-Chill")
ManuallyAssign(Persons(ChillsEvent(_222)), _222-r1, "Salón de actos", 2, "staff-Chill")
ManuallyAssign(Persons(ChillsEvent(_222)), _222-r1, "Salón de actos", 3, "staff-Chill")
ManuallyAssign(Persons(ChillsEvent(_222)), _222-r1, "Salón de actos", 4, "staff-Chill")
AssignStaff(_222-r1, true, Persons(HasRole("staff-dataentry")), [Job("dataentry", 1)], DefaultStaffScorers(_222-r1))

AssignScramblersWithMbf(_333-r1, 1, 3)
AssignScramblersWithMbf(_333-r1, 2, 3)
AssignScramblersWithMbf(_333-r1, 3, 3)
AssignScramblersWithMbf(_333-r1, 4, 3)
AssignScramblersWithMbf(_333-r1, 5, 3)
AssignGroups(_333-r1,
	Concat(ChillSet(_333-r1), [AssignmentSet("delegates", HasRole("delegate"), In(GroupNumber(), [4, 5]))], OrganizersSet(), DeLaTorreSet(), UkuSet(), EveryoneSet()),
	ScramblingCompetingScorers(_333-r1),
	[StationAssignmentRule(true, "ascending", PsychSheetPosition(_333))],
	overwrite=true
)
ReAssignScramblers(_333-r1)
AssignStaff(
	_333-r1,
	true,
	Persons(true),
	DefaultJobs(_333-r1),
	DefaultStaffScorers(_333-r1)
)
ManuallyAssign(Persons(ChillsEvent(_333)), _333-r1, "Salón de actos", 1, "staff-Chill")
ManuallyAssign(Persons(ChillsEvent(_333)), _333-r1, "Salón de actos", 2, "staff-Chill")
ManuallyAssign(Persons(ChillsEvent(_333)), _333-r1, "Salón de actos", 3, "staff-Chill")
ManuallyAssign(Persons(ChillsEvent(_333)), _333-r1, "Salón de actos", 4, "staff-Chill")
AssignStaff(_333-r1, true, Persons(HasRole("staff-dataentry")), [Job("dataentry", 1)], DefaultStaffScorers(_333-r1))

AssignScramblers(_skewb-r1, 1, 3)
AssignScramblers(_skewb-r1, 2, 3)
AssignScramblers(_skewb-r1, 3, 3)
AssignScramblers(_skewb-r1, 4, 3)
AssignCompetitors(_skewb-r1)
ReAssignScramblers(_skewb-r1)
AssignStaff(
	_skewb-r1,
	true,
	Persons(true),
	DefaultJobs(_skewb-r1),
	DefaultStaffScorers(_skewb-r1)
)
ManuallyAssign(Persons(ChillsEvent(_skewb)), _skewb-r1, "Salón de actos", 1, "staff-Chill")
ManuallyAssign(Persons(ChillsEvent(_skewb)), _skewb-r1, "Salón de actos", 2, "staff-Chill")
ManuallyAssign(Persons(ChillsEvent(_skewb)), _skewb-r1, "Salón de actos", 3, "staff-Chill")
AssignStaff(_skewb-r1, true, Persons(HasRole("staff-dataentry")), [Job("dataentry", 1)], DefaultStaffScorers(_skewb-r1))

# 25 is other-awards
ManuallyAssignActivity(25, Persons(HasRole("organizer")), "staff-announcer")