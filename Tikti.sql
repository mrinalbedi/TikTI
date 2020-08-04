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


create table workCommitment(
	workCommitmentID int identity constraint workCommitment_pk primary key,
	Commitment varchar(255)
)

insert into workCommitment values ('full time')
insert into workCommitment values ('part time')
insert into workCommitment values ('part time contract')
insert into workCommitment values ('full time contract')


create table currency(
	currencyID int identity constraint currency_pk primary key,
	currency varchar(255)
)

insert into currency values ('US Dollar')
insert into currency values ('Canadian Dollar')
insert into currency values ('Euro')
insert into currency values ('Pound')
insert into currency values ('Franc')
insert into currency values ('Indian Rupee')


create table certification(
	certificationID int identity constraint certification_pk primary key,
	certificationName varchar(255)
)

insert into certification values ('MsOffice Certification ')
insert into certification values ('ASP.net Certified')
insert into certification values ('Advanced Java Certified')
insert into certification values ('Python(Django) Certified')


create table experience(
	experienceID int identity constraint experience_pk primary key,
	experience varchar(255)
)

insert into experience values ('<1 year')
insert into experience values ('1-3 years')
insert into experience values ('4-6 years')
insert into experience values ('7-10 years')
insert into experience values ('10+ years')


create table education(
	educationID int identity constraint education_pk primary key,
	education varchar(255)
)

insert into education values ('High School')
insert into education values ('Under Graduate')
insert into education values ('Diploma')
insert into education values ('Advanced Diploma')
insert into education values ('Post Graduate')
insert into education values ('Masters')
insert into education values ('PhD')
insert into education values ('Certification')


create table otherRequirement(
	otherRequirementID int identity constraint otherRequirement_pk primary key,
	otherRequirementName varchar(255)
)

insert into otherRequirement values ('Travel Requirement')
insert into otherRequirement values ('Driving License')
insert into otherRequirement values ('Flexible Hours')
insert into otherRequirement values ('Sponsership Required')
insert into otherRequirement values ('Overseas Travel Required')
insert into otherRequirement values ('Drug Testing Required')
insert into otherRequirement values ('Age > 18')

CREATE TABLE roleOpportunity (
    roleOpportunityID int identity constraint roleOpportunity_pk primary key,
    jobDescription varbinary(max) not null,
	hiringManagerID int foreign key references HiringManager(hiringManagerID),
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


create table alternativeWorkLocation(
	workLocationID int identity constraint workLocation_pk primary key,
    city varchar(max) not null,
	province varchar(max) not null,
	postal varchar(max) not null
)


create table alterWorkRoleOpportunity(
	alterWorkRoleOpportunityId int identity primary key,
	roleOpportunityID int foreign key references roleOpportunity(roleOpportunityID),
	workLocationID int foreign key references alternativeWorkLocation(workLocationID)
)

--============================================================================================

create table competencyA(
	competencyID int identity constraint competency_pk primary key,
	competencyName varchar(50),
	isSelected bit not null default 0
)

insert into competencyA values ('Insightful',0)
insert into competencyA values ('Tech-Savvy',0)
insert into competencyA values ('Problem Solver',0)
insert into competencyA values ('Creative',0)
insert into competencyA values ('Analytical',0)
insert into competencyA values ('Innovative',0)
insert into competencyA values ('Broad Perspective',0)
insert into competencyA values ('Curious',0)
insert into competencyA values ('Productive',0)
insert into competencyA values ('Resourceful',0)
insert into competencyA values ('Planner',0)
insert into competencyA values ('Self-Starter',0)
insert into competencyA values ('End user centric',0)
insert into competencyA values ('Organized',0)
insert into competencyA values ('Opportunitistic',0)
insert into competencyA values ('Builder',0)

create table role_competencyA(
	role_competencyAID int identity constraint role_competencyA_pk primary key,
	roleOpportunity int not null constraint roleOpportunity_frgnkey foreign key references roleOpportunity(roleOpportunityID),
	comptencyA int not null constraint competencyA_fk foreign key references competencyA(competencyID)
)


create table competencyB(
	competencyID int identity constraint competencyB_pk primary key,
	competencyName varchar(50),
	isSelected bit not null default 0
)

insert into competencyB values ('Effective Communicator',0)
insert into competencyB values ('Empathetic',0)
insert into competencyB values ('Respectful',0)
insert into competencyB values ('Relationship Builder',0)
insert into competencyB values ('Collaborative',0)
insert into competencyB values ('Open Minded',0)
insert into competencyB values ('Authentic',0)
insert into competencyB values ('Motivator',0)
insert into competencyB values ('Trustworthy',0)
insert into competencyB values ('Self-Aware',0)
insert into competencyB values ('Risk Taker',0)
insert into competencyB values ('Constant Learner',0)
insert into competencyB values ('COnfident',0)
insert into competencyB values ('Agile',0)
insert into competencyB values ('Accountable',0)
insert into competencyB values ('Resilient',0)
insert into competencyB values ('Purposeful',0)
insert into competencyB values ('Leader',0)
insert into competencyB values ('Drive',0)


create table role_competencyB(
	role_competencyBID int identity constraint role_competencyB_pk primary key,
	roleOpportunity int not null constraint roleOpportunity_frnkey foreign key references roleOpportunity(roleOpportunityID),
	comptencyB int not null constraint competencyB_fk foreign key references competencyA(competencyID)
)

--=========================================================================================

create table socCode(
	socCode varchar(10) constraint socCode_pk primary key,
	Description varchar(max) not null
)

insert into socCode values ('11-3021.00','Computer and Information Systems Manager')
insert into socCode values ('13-1111.00','Management Analysis')

create table alternateTitles (
 alternateTitleID int identity primary key,
 Name varchar(max) not null,
 socCode varchar(10) not null foreign key references socCode(socCode)
)

insert into alternateTitles values ('Applciation Development Director','11-3021.00')
insert into alternateTitles values ('Chief Information Officer','11-3021.00')
insert into alternateTitles values ('Chief Innovative Officer','11-3021.00')
insert into alternateTitles values ('Adminsitrative Analysis','13-1111.00')
insert into alternateTitles values ('Adviser Sales','13-1111.00')
insert into alternateTitles values ('Analyst Sales','13-1111.00')
