create database Tikti
use TikTi
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
drop table orgRegisterHR
create table orgRegisterHR(
   orgRegisterHRID int identity primary key,
   registrationID int foreign key references orgRegister(registrationID),
   hiringManagerID int foreign key references HiringManager(hiringManagerID) on delete cascade
);


create table workCommitment(
	workCommitmentID int identity constraint workCommitment_pk primary key,
	Commitment varchar(255)
)

insert into workCommitment values ('Full Time')
insert into workCommitment values ('Part Time')
insert into workCommitment values ('Part Time Contract')
insert into workCommitment values ('Full Time Contract')


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
insert into certification values ('Google Certified Professional Cloud Architect')
insert into certification values ('Certified Scrum Master')
insert into certification values ('AWS Certified Developer')

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


--create table otherRequirement(
--	otherRequirementID int identity constraint otherRequirement_pk primary key,
--	otherRequirementName varchar(255)
--)


--insert into otherRequirement values ('Travel Requirement')
--insert into otherRequirement values ('Driving License')
--insert into otherRequirement values ('Flexible Hours')
--insert into otherRequirement values ('Sponsership Required')
--insert into otherRequirement values ('Overseas Travel Required')
--insert into otherRequirement values ('Drug Testing Required')
--insert into otherRequirement values ('Age > 18')

CREATE TABLE roleOpportunity (
    roleOpportunityID int identity constraint roleOpportunity_pk primary key,
	alternateTitleID int not null constraint alternateTitle_fk foreign key references alternateTitles(alternateTitleID),
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
	education int not null constraint education_fk foreign key references education(educationID) on delete cascade
	)

create table culture(
	cultureID int identity constraint culture_pk primary key,
	cultureName varchar(50),
	description varchar(max),
	isSelected bit not null default 0
)

insert into culture values ('Caring','Every person, in and outside of the organization, is valued',0)
insert into culture values ('Integrity','Truth based transparency in all things',0)
insert into culture values ('Respect','For similar and differing people and their points of view',0)
insert into culture values ('Trust','You can speak your truth and believe what is said to you',0)
insert into culture values ('Engagement','A workplace where everyone feels connected',0)
insert into culture values ('Sense Of Belonging','My contribution is recognized, appreciated and rewarded',0)
insert into culture values ('Meaningful Work','Work that is important to me and the people we serve',0)
insert into culture values ('Motivative Leader','Leaders are inspirational role models',0)
insert into culture values ('Learning Environment','Encourages and supports continuous self growth',0)
insert into culture values ('Collaborative TeamWork','Succeed as a team or fail individually',0)
insert into culture values ('Role Progression','Provide pathways for personal and professional growth',0)
insert into culture values ('Vision & Purpose Driven','Fueled by why we exist and why it’s important',0)
insert into culture values ('Agile','Pivot with a high degree of urgency, determination and confidence',0)


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

insert into benefit values ('PTO Vacation',0)
insert into benefit values ('PTO Sick Days',0)
insert into benefit values ('Health Insurance',0)
insert into benefit values ('Life Insurance',0)
insert into benefit values ('Dental Insurance',0)
insert into benefit values ('Vision Insurance',0)
insert into benefit values ('Retirement Benefits or Accounts',0)
insert into benefit values ('Healthcare Spending/Reimbursements',0)
insert into benefit values ('Long Term Disablity Insurance',0)
insert into benefit values ('Short Term Disablity Insurance',0)
insert into benefit values ('Tuition Reimbursement',0)
insert into benefit values ('ChildCare Benefits',0)
insert into benefit values ('Fitness Facilities Or Programs',0)
insert into benefit values ('Ergonomic Evaluations and Equipments',0)
insert into benefit values ('Wellness Incentives',0)
insert into benefit values ('Healthy Food Options',0)
insert into benefit values ('Stress Management Resources',0)
insert into benefit values ('OnSite Vaccincation or Health Screenings',0)
insert into benefit values ('Employee Recognition Programs',0)
insert into benefit values ('Relocation Assistance',0)
insert into benefit values ('Travel Assistance',0)
insert into benefit values ('TeleCommuting Options',0)
insert into benefit values ('Flexible Work Schedules',0)
insert into benefit values ('Workplace Perks (Eg. recreation activities, Coffe etc.)',0)


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
	description varchar(max),
	isSelected bit not null default 0
)

insert into competencyA values ('Insightful','You are keen and quick to understanding and deal with a business situation',0)
insert into competencyA values ('Tech-Savvy','You know how to use technology to solve challenges',0)
insert into competencyA values ('Problem Solver','You take actions necessary to find solutions to complex situations.',0)
insert into competencyA values ('Creative','You tap your imagination to solve problems',0)
insert into competencyA values ('Analytical','You consistently use analysis and logical reasoning',0)
insert into competencyA values ('Innovative','You look at different ways of solving challenges',0)
insert into competencyA values ('Broad Perspective','You have a broad perspective beyond your immediate role',0)
insert into competencyA values ('Curious','You’re consistently interested in learning about people or things around you',0)
insert into competencyA values ('Productive','You consistently produce expected positive results',0)
insert into competencyA values ('Resourceful','You find clever ways to overcome challenges',0)
insert into competencyA values ('Planner','You take actions to prepare for outcomes',0)
insert into competencyA values ('Self-Starter','You don’t seek direction to begin',0)
insert into competencyA values ('End user centric','Your actions reflect the impact on the end-customer',0)
insert into competencyA values ('Organized','You plan things carefully and keep things neat and orderly',0)
insert into competencyA values ('Opportunitistic','You take advantage of opportunities in the moment',0)
insert into competencyA values ('Builder','You bring together different parts of the solution',0)

create table role_competencyA(
	role_competencyAID int identity constraint role_competencyA_pk primary key,
	roleOpportunity int not null constraint roleOpportunity_frgnkey foreign key references roleOpportunity(roleOpportunityID),
	comptencyA int not null constraint competencyA_fk foreign key references competencyA(competencyID)
)


create table competencyB(
	competencyID int identity constraint competencyB_pk primary key,
	competencyName varchar(50),
	description varchar(max),
	isSelected bit not null default 0
)

insert into competencyB values ('Effective Communicator','You easily transfer mutually understood meaning',0)
insert into competencyB values ('Empathetic','You imagine and understand how someone else feels',0)
insert into competencyB values ('Respectful','You treat others better than the way you want to be treated',0)
insert into competencyB values ('Relationship Builder','You develop and maintain positive relationship with stakeholders',0)
insert into competencyB values ('Collaborative','You work well with others towards a common goal',0)
insert into competencyB values ('Open Minded','You work well with others that have diverse views from yours',0)
insert into competencyB values ('Authentic','Your actions consistently align with your values and beliefs',0)
insert into competencyB values ('Motivator','You connect with others to create energy and enthusiasm',0)
insert into competencyB values ('Trustworthy','Others see you as honest',0)
insert into competencyB values ('Self-Aware','You know how you’re feeling and how your emotions and actions impact others',0)
insert into competencyB values ('Risk Taker','You take actions most others would not take',0)
insert into competencyB values ('Constant Learner','You continuously strive to better yourself',0)
insert into competencyB values ('Confident','You are secure and vocal in knowing what you can and cannot do',0)
insert into competencyB values ('Agile','You’re able to change direction quickly to improve the outcome',0)
insert into competencyB values ('Accountable','You accept complete responsibility for what you do and can provide satisfactory reasons for doing what you do',0)
insert into competencyB values ('Resilient','You have the ability to recover quickly from adversities',0)
insert into competencyB values ('Purposeful','You’re engaged to contribute to the goal',0)
insert into competencyB values ('Leader','You willingly and confidently step up and take control of situations or people',0)
insert into competencyB values ('Drive','You’re determined to get to the end result',0)


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
insert into socCode values ('13-1111.00','Management Analysts')
insert into socCode values 
('13-1199.02','Security Management Analysts'),
('15-1121.00','Computer Systems Analysts'),
('15-1122.00','Information Security Analysts'),
('15-1131.00','Computer Programmers'),
('15-1132.00','Software Developers, Applications'),
('15-1133.00','Software Developers, System Software'),
('15-1134.00','Web Developers'),
('15-1141.00','Database Administrators'),
('15-1142.00','Network and Computer Systems Administrators'),
('15-1143.00','Computer Network Architects'),
('15-1143.01','Telecommunications Engineering Specialists'),
('15-1151.00','Computer User Support Specialists'),
('15-1152.00','Computer Network Support Specialists'),
('15-1199.00','Computer Occupations, All Other'),
('15-1199.01','Software quality assurance engineers and testers'),
('15-1199.02','Computer Systems Engineers/Architects'),
('15-1199.03','Web Administrators'),
('15-1199.04','Geospatial Information Scientists and Technologists'),
('15-1199.05','Geospatial Information System Technicians'),
('15-1199.06','Database Architects'),
('15-1199.07','Data Warehousing Specialists'),
('15-1199.08','Business Intelligence Analysts' ),
('15-1199.09','Information Technology Project Managers'),
('15-1199.10','Search Marketing Strategists'),
('15-1199.11','Video Game Designers'),
('15-1199.12','Document Management Specialists')


create table alternateTitles (
 alternateTitleID int identity primary key,
 Name varchar(max) not null,
 socCode varchar(10) not null foreign key references socCode(socCode)
)


--==================================================================================================================

create table otherRequirements(
	requirementID int identity not null primary key,
	roleOpportunityID int not null foreign key references roleOpportunity(roleOpportunityID),
	sponsorship bit not null default 0,
	overseasTravel bit not null default 0,
	drugTesting bit not null default 0,
	age18 bit not null default 0,
	Travel bit not null default 0,
	TravelDistance varchar(10),
	DriverLicense bit not null default 0,
	LicenseProvince varchar(20),
	WeekendWork bit not null default 0,
	Overnight bit not null default 0
)


