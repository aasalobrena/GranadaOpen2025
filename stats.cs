#include "helpers.cs"

Table(
  Sort(Persons(Registered()), (LengthOfJobs(DefaultStaffCodes()) / LengthOfJobs("competitor"))),
  [Column("Name", Name()), Column("Ratio", (LengthOfJobs(DefaultStaffCodes()) / LengthOfJobs("competitor")))])
  
Table(
  Sort(Persons(Registered()), LengthOfJobs(DefaultStaffCodes())),
  [Column("Name", Name()), Column("Horas", LengthOfJobs(DefaultStaffCodes()))])