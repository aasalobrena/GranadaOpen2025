#include "helpers.cs"

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

# 8 is other-lunch
ManuallyAssignActivity(7, [2013ROCA01], "staff-Chef")
ManuallyAssignActivity(7, Persons(In("Lomoqueso", ArrayProperty("food"))), "staff-Lomoqueso")
ManuallyAssignActivity(7, Persons(In("Hamburguesa", ArrayProperty("food"))), "staff-Hamburguesa")
ManuallyAssignActivity(7, Persons(In("Perrito", ArrayProperty("food"))), "staff-Perrito")
ManuallyAssignActivity(7, Persons(In("Otro", ArrayProperty("food"))), "staff-Otro")

# 26 is other-multi
ManuallyAssignActivity(30, Persons(CompetingIn(_333mbf)))

AssignScramblers(_222-r1, 1, 3)
AssignScramblers(_222-r1, 2, 3)
AssignScramblers(_222-r1, 3, 3)
AssignScramblers(_222-r1, 4, 3)
AssignScramblers(_222-r1, 5, 3)
AssignCompetitors(_222-r1)
ReAssignScramblers(_222-r1)
AssignStaff(
	_222-r1,
	true,
	Persons(true),
	DefaultJobs(_222-r1),
	DefaultStaffScorers(_222-r1)
)

# MULTI

AssignScramblers(_333-r1, 1, 3)
AssignScramblers(_333-r1, 2, 3)
AssignScramblers(_333-r1, 3, 3)
AssignScramblers(_333-r1, 4, 3)
AssignScramblers(_333-r1, 5, 3)
AssignCompetitors(_333-r1)
ReAssignScramblers(_333-r1)
AssignStaff(
	_333-r1,
	true,
	Persons(true),
	DefaultJobs(_333-r1),
	DefaultStaffScorers(_333-r1)
)

AssignScramblers(_skewb-r1, 1, 3)
AssignScramblers(_skewb-r1, 2, 3)
AssignScramblers(_skewb-r1, 3, 3)
AssignCompetitors(_skewb-r1)
ReAssignScramblers(_skewb-r1)
AssignStaff(
	_skewb-r1,
	true,
	Persons(true),
	DefaultJobs(_skewb-r1),
	DefaultStaffScorers(_skewb-r1)
)

Table(
  Sort(Persons(Registered()), (LengthOfJobs() / LengthOfJobs("competitor"))),
  [Column("Name", Name()), Column("Ratio", (LengthOfJobs() / LengthOfJobs("competitor")))])
  
Table(
  Sort(Persons(Registered()), LengthOfJobs()),
  [Column("Name", Name()), Column("Horas", LengthOfJobs())])