
CREATE TABLE OrgRegistration(
    registrationID int not null identity primary key ,
    email nvarchar(max) not null,
    pwd nvarchar(max) not null,
    confirmPassword nvarchar(max) not null,
    contactFirstName nvarchar(30) not null,
    contactLastName nvarchar(30) not null,
    contactTitle nvarchar(30) not null,
    Department nvarchar(30) not null
);

create table workCommitment(
	workCommitmentID int identity constraint workCommitment_pk primary key,
	Commitment varchar(255) 
)

create table currency(
	currencyID int identity constraint currency_pk primary key,
	currency varchar(255) 
)

create table certification(
	certificationID int identity constraint certification_pk primary key,
	certificationName varchar(255) 
)
create table experience(
	experienceID int identity constraint experience_pk primary key,
	experience varchar(255) 
)

create table education(
	educationID int identity constraint education_pk primary key,
	education varchar(255) 
)

create table otherRequirement(
	otherRequirementID int identity constraint otherRequirement_pk primary key,
	otherRequirementName varchar(255) 
)

create table culture(
	cultureID int identity constraint culture_pk primary key,
	cultureName varchar(50),
	isSelected bit not null default 0
)

insert into culture values ('caring',0)
insert into culture values ('integrity',0)
insert into culture values ('respect',0)
insert into culture values ('trust',0)
insert into culture values ('engagement',0)
insert into culture values ('senseOfBelonging',0)
insert into culture values ('meaningfulWork',0)
insert into culture values ('motivativeLeader',0)
insert into culture values ('learningEnvironment',0)
insert into culture values ('collaborativeTeamWork',0)
insert into culture values ('roleProgression',0)
insert into culture values ('vision_purposeDriven',0)
insert into culture values ('agile',0)

create table role_culture(
	role_cultureID int identity constraint role_culture_pk primary key,
	roleOpportunity int not null constraint roleOpportunity_fk foreign key references roleOpportunity(roleOpportunityID),
	culture int not null constraint culture_fk foreign key references culture(cultureID)
)

create table benefit(
	benefitID int identity constraint benefit_pk primary key,
	benefitName varchar(50),
	isSelected bit not null default 0
)

insert into benefit values ('PTOVacation',0)
insert into benefit values ('PTOSickDays',0)
insert into benefit values ('healthInsurance',0)
insert into benefit values ('lifeInsurance',0)
insert into benefit values ('dentalInsurance',0)
insert into benefit values ('visionInsurance',0)
insert into benefit values ('retirementBenefits_account',0)
insert into benefit values ('healthcareSpending',0)
insert into benefit values ('longtermDisablityInsurance',0)
insert into benefit values ('shorttermDisablityInsurance',0)
insert into benefit values ('tuitionReimbursement',0)
insert into benefit values ('childCareBenefits',0)
insert into benefit values ('fitnessFacilities',0)
insert into benefit values ('ergonomicEvaluations',0)
insert into benefit values ('wellnessIncentives',0)
insert into benefit values ('healthyFoodOption',0)
insert into benefit values ('stressManagementResources',0)
insert into benefit values ('onSiteVaccincation',0)
insert into benefit values ('employeeRecognitionProgram',0)
insert into benefit values ('employeeRecognitionProgram',0)
insert into benefit values ('relocationAssistance',0)
insert into benefit values ('travelAssistance',0)
insert into benefit values ('teleCommutingOption',0)
insert into benefit values ('workPlacePerks',0)


create table role_benefit(
	role_benefitID int identity constraint role_benefit_pk primary key,
	roleOpportunity int not null constraint roleOpportunity_fkey foreign key references roleOpportunity(roleOpportunityID),
	benefit int not null constraint benefit_fk foreign key references benefit(benefitID)
)


CREATE TABLE roleOpportunity (
    roleOpportunityID int identity constraint roleOpportunity_pk primary key,
    jobDescription varbinary(max) not null,
    desiredStartDate date not null,
	workCommitment int not null constraint workCommitment_fk foreign key references workCommitment(workCommitmentID),
	contractDuration varchar(30),
	currency int not null constraint currency_fk foreign key references currency(currencyID),
	salary varchar(30) not null,
	city varchar(30) not null,
	province varchar(30) not null,
	postal varchar(7) not null,
	telecommutingRoles bit not null default 0,
	weblink varchar(max),
	certification int not null constraint certification_fk foreign key references certification(certificationID) on delete cascade,
	extraCertificationRequired bit not null default 0,
	extraCertification varchar(max),
	experience int not null constraint experience_fk foreign key references experience(experienceID) on delete cascade,
	education int not null constraint education_fk foreign key references education(educationID) on delete cascade,
	otherRequirents int not null constraint otherRequirement_fk foreign key references otherRequirement(otherRequirementID) on delete cascade
	)


create table alternativeWorkLocation(
	workLocationID int identity constraint workLocation_pk primary key,
    city varbinary(30) not null,
	province varbinary(30) not null,
	postal varbinary(6) not null,
)

create table role_WorkLocation(
	role_WorkLocationID int identity constraint role_WorkLocation_pk primary key,
	roleOpportunity int not null constraint roleOpportunity_fk foreign key references roleOpportunity(roleOpportunityID),
	alternativeWorkLocation int not null constraint alternativeWorkLocation_fk foreign key references alternativeWorkLocation(workLocationID),
)


insert into workCommitment values ('full time')
insert into workCommitment values ('part time')
insert into workCommitment values ('part time contract')
insert into workCommitment values ('full time contract')

insert into currency values ('dollor')
insert into currency values ('euro')

insert into education values ('bachelors')
insert into education values ('masters')

insert into experience values ('1 yr')
insert into experience values ('3 yr')
insert into experience values ('5 yr')

insert into certification values ('MS Office')
insert into certification values ('Python')

insert into otherRequirement values ('must have a G2 License')
insert into otherRequirement values ('must have a car')

--=============================================================================
CREATE TABLE orgRegister (
    registrationID int identity primary key,
    organizationName varchar(30) not null,
    email varchar(max) not null,
    password varchar(max) not null,
    confirmPassword varchar(max) not null,
	contactFirstName varchar(max) not null,
	contactLastName varchar(max) not null,
	contactTitle varchar(max) not null,
	contactPhoneNumber varchar(max) not null,
	Department varchar(max) not null
);

create table HiringManager(
	hiringManagerID int identity primary key,
	FirstName varchar(max) not null,
	LastName varchar(max) not null,
	Title varchar(max),
	Department varchar(max),
	PhoneNumber varchar(max),
	email varchar(max)
);

create table orgRegisterHR(
   orgRegisterHRID int identity primary key,
   registrationID int foreign key references orgRegister(registrationID),
   hiringManagerID int foreign key references HiringManager(hiringManagerID)
);
