Define("CompetitorsPerGroup",
	If((Mod(Length(Persons(CompetingInRound({1, Round}))), Length(Groups({1, Round}))) == 0),
		(Length(Persons(CompetingInRound({1, Round}))) / Length(Groups({1, Round}))),
		(IntDivision(Length(Persons(CompetingInRound({1, Round}))), Length(Groups({1, Round}))) + 1)
	)
)

# Useful Booleans(Person)

Define("ChillsEvent", (StringProperty("chill") == EventId({1, Event})))
Define("CanStaff", And(Registered(), Not(HasRole("delegate")), Not(HasRole("trainee-delegate")), Not(HasRole("organizer"))))
Define("CanStaffEvent", And(CanStaff(), Not(ChillsEvent({1, Event}))))
Define("IsInTop25Psych", And(CompetingIn({1, Event}), (PsychSheetPosition({1, Event}) < (0.25 * Length(Persons(CompetingIn({1, Event})))))))
Define("CanScrambleEvent", And(CanStaffEvent({1, Event}), Or(IsInTop25Psych({1, Event}), And(Or((EventId({1, Event}) == "333bf"), (EventId({1, Event}) == "333oh")), IsInTop25Psych(_333)))))
Define("CanScrambleEventRelaxed", In(Slice(Sort(Persons(And(CanStaffEvent({1, Event}), CompetingIn({1, Event}))), If(Or((EventId({1, Event}) == "333bf"), (EventId({1, Event}) == "333oh")), PsychSheetPosition(_333), PsychSheetPosition({1, Event}))), 0, {2, Number})))
Define("IsTopScrambler", (NumberProperty(("scrambles-" + RoundId({1, Round}))) == Length(Groups({1, Round}))))
# USAR ESTOS EN PROD
# Define("IsTopCompetitor", If((RoundNumber({1, Round}) == 1), (PsychSheetPosition(EventForRound({1, Round})) <= CompetitorsPerGroup({1, Round})), (RoundPosition({1, Round}) <= CompetitorsPerGroup({1, Round}))))
# Define("ScramblesFinal", And((Length(Persons(CompetingInRound({1, Round}))) < RoundPosition(RoundForEvent((RoundNumber({1, Round}) - 1), EventForRound({1, Round})))), (RoundPosition(RoundForEvent((RoundNumber({1, Round}) - 1), EventForRound({1, Round}))) <= (Length(Persons(CompetingInRound({1, Round}))) + {2, Number}))))
# USAR ESTOS EN DEV
Define("IsTopCompetitor", (PsychSheetPosition(EventForRound({1, Round})) <= CompetitorsPerGroup({1, Round})))
Define("ScramblesFinal", And((Length(Persons(CompetingInRound({1, Round}))) < PsychSheetPosition(EventForRound({1, Round}))), (PsychSheetPosition(EventForRound({1, Round})) <= (Length(Persons(CompetingInRound({1, Round}))) + {2, Number}))))

# AssignmentSets

Define("ChillSet", [AssignmentSet(EventId(EventForRound({1, Event})), (StringProperty("chill") == EventId(EventForRound({1, Round}))), (GroupNumber() == Length(Groups({1, Round}))))])
Define("DelegatesSet", [AssignmentSet("delegates", Or(HasRole("delegate"), HasRole("trainee-delegate")), true)])
Define("OrganizersSet", [AssignmentSet("organizers", HasRole("organizer"), true)])
Define("DeLaTorreSet", [AssignmentSet("delatorre", Or((WcaId() == "2023LAME03"), (WcaId() == "2024LAME01")), true)])
Define("UkuSet", [AssignmentSet("ukubom", Or((WcaId() == "2013ROCA01"), (WcaId() == "2014TEJA07")), true)])
Define("TopCompetitorsSet", [AssignmentSet("topcompetitors", And(IsTopCompetitor({1, Round}), Not(IsTopScrambler({1, Round}))), (GroupNumber() == Length(Groups({1, Round}))))])
Define("EveryoneSet", [AssignmentSet("everyone", true, true)])
Define("DefaultAssignmentSets", Concat(ChillSet({1, Round}), DelegatesSet(), OrganizersSet(), DeLaTorreSet(), UkuSet(), TopCompetitorsSet({1, Round}), EveryoneSet()))

# Scorers

Define("ScramblingCompetingScorers",
	[
		PropertyScorer(And(HasProperty(("scrambles-" + RoundId({1, Round}))), (NumberProperty(("scrambles-" + RoundId({1, Round}))) == GroupNumber())), -999)
	]
)

Define("DefaultStaffScorers",
	[
		#PriorAssignmentScorer(-3, 3),
		#SameJobScorer(60, -5, 4),
		#ConsecutiveJobScorer(90, -3, 0),
		#FollowingGroupScorer(-50),
		ComputedWeightScorer(If(IsNull(WcaId()), 0, 10), ["judge", "runner"]),
		ComputedWeightScorer((-10 * LengthOfJobs()), ["judge", "runner"]),
		ComputedWeightScorer(If(CompetingInRound({1, Round}), 999, -999), ["judge", "runner"]),
		ComputedWeightScorer(If(CompetingIn(EventForRound({1, Round})), 999, -999), ["judge", "runner"])
	]
)

# Scrambling and competing assignments

Define("AssignScramblers",
	Tuple(
		AssignStaff(
			{1, Round},
			(GroupNumber() == {2, Number}),
			If(
				(Length(Persons(CanScrambleEvent(EventForRound({1, Round})))) >= ({3, Number} * Length(Groups({1, Round})))),
				Persons(And(CanScrambleEvent(EventForRound({1, Round})), (NumJobsInRound({1, Round}, "scrambler") == 0))),
				Persons(And(CanScrambleEventRelaxed(EventForRound({1, Round}), ({3, Number} * Length(Groups({1, Round})))), (NumJobsInRound({1, Round}, "scrambler") == 0)))
			),
			[Job("scrambler", {3, Number})],
			DefaultStaffScorers({1, Round})
		),
		SetProperty(Persons(And((NumJobsInRound({1, Round}) > 0), Not(HasProperty(("scrambles-" + RoundId({1, Round})))))), ("scrambles-" + RoundId({1, Round})), {2, Number})
	)
)

Define("ReAssignScramblersGroup",
	ManuallyAssign(
		Persons((NumberProperty(("scrambles-" + RoundId({1, Round}))) == {2, Number})),
		{1, Round},
		"Salón de actos",
		{2, Number},
		"staff-scrambler"
	)
)

Define("ReAssignScramblers",
	Map(Groups({1, Round}),
		ReAssignScramblersGroup({1, Round}, GroupNumber())
	)
)

Define("AssignCompetitors",
	AssignGroups({1, Round},
		DefaultAssignmentSets({1, Round}),
		ScramblingCompetingScorers({1, Round}),
		[StationAssignmentRule(true, "ascending", If((RoundNumber({1, Round}) == 1), PsychSheetPosition(EventForRound({1, Round})), RoundPosition(RoundForEvent((RoundNumber({1, Round}) - 1), EventForRound({1, Round})))))],
		overwrite=true
	)
)

# JobSets

# CUIDADO: Le he metido {1, Round} que antes no lo tenía
Define("DefaultJobs",
	[
		Job("runner", 3, eligibility=CanStaffEvent(EventForRound({1, Round}))),
		Job("judge", CompetitorsPerGroup({1, Round}), eligibility=CanStaffEvent(EventForRound({1, Round}))),
		Job("delegate", 1, eligibility=Or(HasRole("delegate"), HasRole("trainee-delegate")))
	]
)

Define("FinalJobs",
	[
		Job("scrambler", {2, Number}, eligibility=ScramblesFinal({1, Round}, {2, Number})),
		Job("judge", CompetitorsPerGroup({1, Round}), eligibility=CanStaffEvent(EventForRound({1, Round}))),
		Job("runner", 2, eligibility=CanStaffEvent(EventForRound({1, Round})))
	]
)