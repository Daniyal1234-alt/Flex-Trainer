--Database Creation
Create Database PROJECT_DB;
--Tables Creation in PROJECT_DB
CREATE TABLE PROJECT_DB.dbo.Member(
    MemberID INT IDENTITY(1,1) PRIMARY KEY,
	NAME VARCHAR(100),
    Email VARCHAR(255),
    Pass VARCHAR(255),
    Phone_Number VARCHAR(255),
    CNIC VARCHAR(30),
	JOINING_DATE DATE,
	Address Varchar(50)
);

CREATE TABLE PROJECT_DB.dbo.Admin(
    AdminID INT IDENTITY(1,1) PRIMARY KEY,
	NAME VARCHAR(100) ,
    Email VARCHAR(255) ,
    Pass VARCHAR(255) ,
    Phone_Number VARCHAR(255) ,
    CNIC VARCHAR(30) 
);

CREATE TABLE PROJECT_DB.dbo.Owner(
    OwnerID INT IDENTITY(1,1) PRIMARY KEY,
	NAME VARCHAR(100),
    Email VARCHAR(255),
    Pass VARCHAR(255),
    Phone_Number VARCHAR(255),
    CNIC VARCHAR(30) ,
	Gym_loc varchar(100),
	regStatus bit
);
CREATE TABLE PROJECT_DB.dbo.Trainer(
    TrainerID INT IDENTITY(1,1) PRIMARY KEY,
	NAME VARCHAR(100),
    Email VARCHAR(255),
    Pass VARCHAR(255),
    Phone_Number VARCHAR(255),
    CNIC VARCHAR(30),
	Specialties varchar(50),
	Gyms varchar(50),
	RegBit int Default 0
);

CREATE TABLE PROJECT_DB.dbo.Exercise(
	ExerciseID int identity(1,1) primary key,
	workoutID int, --FK from workout table
	Name varchar(50),
	TargetMuscle varchar(50),
	Machine varchar(50),
	Rest Varchar(50),
	sets int,
	reps int
);

CREATE TABLE PROJECT_DB.dbo.Workout(
	WorkoutID int identity(1,1) primary key,
	name varchar(50),
	days int,
	purpose varchar(100),
	expLevel varchar(15),
	createdBy varchar(50)
);

CREATE TABLE PROJECT_DB.dbo.DietPlan(
	DietPlanID int identity(1,1) primary key,
	Name Varchar(50),
	Type varchar(50),
	Purpose varchar(50),
	createdBy varchar(50)
);

CREATE TABLE PROJECT_DB.dbo.Gym(
	GymID int identity(1,1) primary key,
	GymName varchar(50),
	GymLoc varchar(100),
	OwnerID int, --FK Owner
	AdminId int, --FK Admin
	RegStatus bit
);

CREATE TABLE PROJECT_DB.dbo.Appointment(
	AppID int identity(1,1) primary key,
	MemberID int,
	TrainerID int,
	Purpose varchar(50),
	Date_Time Varchar(50)
);

CREATE TABLE Member_Workout(
	MemberID int not null,		--Foreign key
	WorkoutID int not null		--Foreign key
);

CREATE TABLE Member_Trainer(
	MemberID int not null,
	TrainerID int not null
);

CREATE TABLE Member_Diet(
	MemberID int not null, --fk
	DietPlanID int not null --fk
);

CREATE TABLE food(
	DietPlanID int not null, --Foreign Key
	FoodID int not null Primary Key identity(1,1),
	name varchar(50),
	calories int, 
	protein int,
	fat int,
	carbs int,
	allergens varchar(50),
	time varchar(50)
);

CREATE TABLE Member_Gym(
	 MemberID int not null,
	 GymID int not null
);

CREATE TABLE Member_Rating(
 MemberID int ,
 TrainerID int,
 Rating int
);

CREATE TABLE Trainer_Gym(
	TrainerID int,
	GymID int
);
--Applying Foreign Constraints
-- Apply foreign keys

-- 1. Member_Workout table
ALTER TABLE Member_Workout
ADD CONSTRAINT FK_Member_Workout_Member FOREIGN KEY (MemberID) REFERENCES Member(MemberID),
ALTER TABLE Member_Workout
ADD CONSTRAINT FK_Member_Workout_Workout FOREIGN KEY (WorkoutID) REFERENCES Workout(WorkoutID);

-- 2. Member_Trainer table
ALTER TABLE Member_Trainer
ADD CONSTRAINT FK_Member_Trainer_Member FOREIGN KEY (MemberID) REFERENCES Member(MemberID);
ALTER TABLE Member_Trainer
ADD CONSTRAINT FK_Member_Trainer_Trainer FOREIGN KEY (TrainerID) REFERENCES Trainer(TrainerID);

-- 3. Member_Diet table
ALTER TABLE Member_Diet
ADD CONSTRAINT FK_Member_Diet_Member FOREIGN KEY (MemberID) REFERENCES Member(MemberID);
ALTER TABLE Member_Diet
ADD CONSTRAINT FK_Member_Diet_DietPlan FOREIGN KEY (DietPlanID) REFERENCES DietPlan(DietPlanID);

-- 4. Member_Gym table
ALTER TABLE Member_Gym
ADD CONSTRAINT FK_Member_Gym_Member FOREIGN KEY (MemberID) REFERENCES Member(MemberID);
ALTER TABLE Member_Gym
ADD CONSTRAINT FK_Member_Gym_Gym FOREIGN KEY (GymID) REFERENCES Gym(GymID);

-- 5. Member_Rating table
ALTER TABLE Member_Rating
ADD CONSTRAINT FK_Member_Rating_Member FOREIGN KEY (MemberID) REFERENCES Member(MemberID);
ALTER TABLE Member_Rating
ADD CONSTRAINT FK_Member_Rating_Trainer FOREIGN KEY (TrainerID) REFERENCES Trainer(TrainerID);

-- 6. Trainer_Gym table
ALTER TABLE Trainer_Gym
ADD CONSTRAINT FK_Trainer_Gym_Trainer FOREIGN KEY (TrainerID) REFERENCES Trainer(TrainerID);
ALTER TABLE Trainer_Gym
ADD CONSTRAINT FK_Trainer_Gym_Gym FOREIGN KEY (GymID) REFERENCES Gym(GymID);
--Inserting Into Tables
--Inserting into Member
INSERT INTO PROJECT_DB.dbo.Member (NAME, Email, Pass, Phone_Number, CNIC, JOINING_DATE, Address) 
VALUES 
('John Doe', 'john@example.com', 'password123', '1234567890', '12345-6789012-3', '2024-01-01', '123 Main St'),
('Alice Smith', 'alice@example.com', 'password456', '0987654321', '54321-0987654-3', '2024-02-15', '456 Elm St'),
('Bob Johnson', 'bob@example.com', 'password789', '9876543210', '67890-1234567-8', '2024-03-20', '789 Oak St'),
('Charlie Brown', 'charlie@example.com', 'passwordabc', '2345678901', '98765-4321098-7', '2024-04-10', '987 Pine St'),
('Emma Garcia', 'emma@example.com', 'passworddef', '3456789012', '65432-1098765-4', '2024-05-05', '654 Cedar St'),
('Grace Martinez', 'grace@example.com', 'passwordghi', '4567890123', '54321-9876543-2', '2024-06-15', '321 Birch St'),
('Henry Lee', 'henry@example.com', 'passwordjkl', '5678901234', '43210-9876543-2', '2024-07-20', '876 Maple St'),
('Isabella Nguyen', 'isabella@example.com', 'passwordmno', '6789012345', '32109-8765432-1', '2024-08-25', '234 Oak St'),
('Jacob Taylor', 'jacob@example.com', 'passwordpqr', '7890123456', '21098-7654321-0', '2024-09-30', '543 Pine St'),
('Liam Martinez', 'liam@example.com', 'passwordstu', '8901234567', '10987-6543210-9', '2024-10-05', '789 Cedar St'),
('Olivia Jackson', 'olivia@example.com', 'passwordvwx', '9012345678', '09876-5432109-8', '2024-11-10', '876 Elm St'),
('Noah White', 'noah@example.com', 'passwordyz1', '0123456789', '98765-4321098-7', '2024-12-15', '123 Birch St'),
('Sophia Harris', 'sophia@example.com', 'password234', '1234567890', '87654-3210987-6', '2025-01-20', '432 Pine St'),
('William Brown', 'william@example.com', 'password567', '2345678901', '76543-2109876-5', '2025-02-25', '567 Oak St'),
('Ava Wilson', 'ava@example.com', 'password890', '3456789012', '65432-1098765-4', '2025-03-30', '345 Maple St'),
('Michael Rodriguez', 'michael@example.com', 'passwordabc1', '4567890123', '54321-0987654-3', '2025-04-05', '789 Birch St'),
('Ethan Lewis', 'ethan@example.com', 'passworddef1', '5678901234', '43210-9876543-2', '2025-05-10', '876 Cedar St'),
('Mia Clark', 'mia@example.com', 'passwordghi1', '6789012345', '32109-8765432-1', '2025-06-15', '654 Elm St'),
('Alexander Lee', 'alexander@example.com', 'passwordjkl1', '7890123456', '21098-7654321-0', '2025-07-20', '123 Pine St'),
('Charlotte Walker', 'charlotte@example.com', 'passwordmno1', '8901234567', '10987-6543210-9', '2025-08-25', '321 Maple St');
--Insert into Admin
INSERT INTO PROJECT_DB.dbo.Admin (NAME, Email, Pass, Phone_Number, CNIC) 
VALUES 
('Admin1', 'admin1@example.com', 'adminpass1', '1111111111', '11111-1111111-1'),
('Admin2', 'admin2@example.com', 'adminpass2', '2222222222', '22222-2222222-2'),
('Admin3', 'admin3@example.com', 'adminpass3', '3333333333', '33333-3333333-3'),
('Admin4', 'admin4@example.com', 'adminpass4', '4444444444', '44444-4444444-4'),
('Admin5', 'admin5@example.com', 'adminpass5', '5555555555', '55555-5555555-5');
--Insert into Owner
INSERT INTO PROJECT_DB.dbo.Owner (NAME, Email, Pass, Phone_Number, CNIC, Gym_loc, Regstatus) 
VALUES 
('Owner1', 'owner1@example.com', 'ownerpass1', '1111111111', '11111-1111111-1', 'Location1', 1),
('Owner2', 'owner2@example.com', 'ownerpass2', '2222222222', '22222-2222222-2', 'Location2', 1),
('Owner3', 'owner3@example.com', 'ownerpass3', '3333333333', '33333-3333333-3', 'Location3', 1),
('Owner4', 'owner4@example.com', 'ownerpass4', '4444444444', '44444-4444444-4', 'Location4', 1),
('Owner5', 'owner5@example.com', 'ownerpass5', '5555555555', '55555-5555555-5', 'Location5', 1),
('Owner6', 'owner6@example.com', 'ownerpass6', '6666666666', '66666-6666666-6', 'Location6',1),
('Owner7', 'owner7@example.com', 'ownerpass7', '7777777777', '77777-7777777-7', 'Location7', 1),
('Owner8', 'owner8@example.com', 'ownerpass8', '8888888888', '88888-8888888-8', 'Location8',1 ),
('Owner9', 'owner9@example.com', 'ownerpass9', '9999999999', '99999-9999999-9', 'Location9',1 ),
('Owner10', 'owner10@example.com', 'ownerpass10', '1010101010', '10101-1010101-0', 'Location10',1);
--Insert into Gym Table
INSERT INTO PROJECT_DB.dbo.Gym (GymName, GymLoc, OwnerID, AdminId, RegStatus) 
VALUES 
('Gym1', 'Location1', 1, 1, 1),
('Gym2', 'Location2', 2, 2, 1),
('Gym3', 'Location3', 3, 3, 1),
('Gym4', 'Location4', 4, 4, 0),
('Gym5', 'Location5', 5, 5, 0),
('Gym6', 'Location6', 6, 6, 1),
('Gym7', 'Location7', 7, 7, 1),
('Gym8', 'Location8', 8, 8, 0),
('Gym9', 'Location9', 9, 9, 0),
('Gym10', 'Location10', 10, 10, 1);
--Insert into Workout
INSERT INTO PROJECT_DB.dbo.Workout (name, days, purpose, expLevel, createdBy) 
VALUES 
('Full Body Strength', 3, 'Strength', 'Intermediate', 'Trainer1'),
('Cardio Blast', 5, 'Weight Loss', 'Beginner', 'Trainer2'),
('Core Conditioning', 4, 'Muscle Gain', 'Advanced', 'Trainer3'),
('Leg Day Intensity', 3, 'Strength', 'Intermediate', 'Trainer4'),
('HIIT Circuit', 3, 'Weight Loss', 'Advanced', 'Trainer5'),
('Upper Body Sculpt', 4, 'Muscle Gain', 'Intermediate', 'Trainer6'),
('Yoga Flow', 5, 'Flexibility', 'Beginner', 'Trainer7'),
('Powerlifting Routine', 4, 'Strength', 'Advanced', 'Trainer8'),
('Pilates Core Workout', 3, 'Muscle Tone', 'Intermediate', 'Trainer9'),
('Endurance Run', 6, 'Weight Loss', 'Beginner', 'Trainer10');
--Insert into Exercises
INSERT INTO PROJECT_DB.dbo.Exercise (workoutID, Name, TargetMuscle, Machine, Rest, sets, reps) 
VALUES 
(1, 'Squats', 'Legs', 'Barbell', '1 minute', 4, 10),
(1, 'Deadlifts', 'Back', 'Barbell', '2 minutes', 4, 8),
(1, 'Bench Press', 'Chest', 'Barbell', '1.5 minutes', 4, 8),
(2, 'Running', 'Cardio', 'Treadmill', '1 minute', 5, NULL),
(2, 'Jumping Jacks', 'Full body', 'None', '1 minute', 5, NULL),
(2, 'Burpees', 'Full body', 'None', '1.5 minutes', 5, NULL),
(3, 'Plank', 'Core', 'None', '1 minute', 3, 60),
(3, 'Russian Twists', 'Obliques', 'Medicine Ball', '1 minute', 3, 20),
(3, 'Leg Raises', 'Lower abs', 'None', '1 minute', 3, 15),
(4, 'Lunges', 'Legs', 'None', '1 minute', 4, 12);
--Insert into DietPlan
INSERT INTO PROJECT_DB.dbo.DietPlan (Name, Type, Purpose, createdBy) 
VALUES 
('Low Carb Diet', 'Balanced', 'Weight Loss', 'Nutritionist1'),
('High Protein Diet', 'Protein-rich', 'Muscle Gain', 'Nutritionist2'),
('Vegetarian Diet', 'Plant-based', 'General Health', 'Nutritionist3'),
('Intermittent Fasting', 'Fasting', 'Weight Loss', 'Nutritionist4'),
('Mediterranean Diet', 'Balanced', 'Heart Health', 'Nutritionist5'),
('Keto Diet', 'High fat', 'Weight Loss', 'Nutritionist6'),
('Paleo Diet', 'Whole foods', 'General Health', 'Nutritionist7'),
('Flexitarian Diet', 'Plant-based', 'Weight Management', 'Nutritionist8'),
('DASH Diet', 'Low sodium', 'Blood Pressure', 'Nutritionist9'),
('Vegan Diet', 'Plant-based', 'Ethical reasons', 'Nutritionist10');
--Insert into Food
INSERT INTO PROJECT_DB.dbo.Food (DietPlanID, Name, Calories, Protein, Fat, Carbs, Allergens, Time) 
VALUES 
(1, 'Grilled Chicken Breast', 120, 25, 3, 0, 'None', 'Lunch'),
(1, 'Broccoli', 50, 5, 0.5, 10, 'None', 'Dinner'),
(2, 'Salmon Fillet', 200, 20, 12, 0, 'Fish', 'Dinner'),
(2, 'Greek Yogurt', 100, 15, 2, 8, 'Dairy', 'Breakfast'),
(3, 'Quinoa Salad', 150, 5, 5, 25, 'None', 'Lunch'),
(3, 'Spinach', 30, 3, 0.5, 5, 'None', 'Dinner'),
(4, 'Black Coffee', 5, 0, 0, 0, 'Caffeine', 'Breakfast'),
(4, 'Green Tea', 0, 0, 0, 0, 'Caffeine', 'Breakfast'),
(5, 'Olive Oil', 120, 0, 14, 0, 'None', 'Breakfast'),
(5, 'Whole Grain Bread', 100, 4, 1, 20, 'Gluten', 'Breakfast');
--Insert into Trainers
INSERT INTO PROJECT_DB.dbo.Trainer (NAME, Email, Pass, Phone_Number, CNIC, Specialties, Gyms, RegBit) 
VALUES 
('Jennifer Smith', 'jennifer@example.com', 'password123', '1234567890', '12345-6789012-3', 'Weight Training', 'Gym1', 1),
('Michael Johnson', 'michael@example.com', 'password456', '0987654321', '54321-0987654-3', 'Yoga', 'Gym2', 1),
('Emily Davis', 'emily@example.com', 'password789', '9876543210', '67890-1234567-8', 'Cardio', 'Gym3', 1),
('Daniel Wilson', 'daniel@example.com', 'passwordabc', '2345678901', '98765-4321098-7', 'CrossFit', 'Gym1', 1),
('Sarah Brown', 'sarah@example.com', 'passworddef', '3456789012', '65432-1098765-4', 'Pilates', 'Gym1', 1),
('David Martinez', 'david@example.com', 'passwordghi', '4567890123', '54321-9876543-2', 'Functional Training', 'Gym3', 1),
('Jessica Thompson', 'jessica@example.com', 'passwordjkl', '5678901234', '43210-9876543-2', 'HIIT', 'Gym3', 1),
('Matthew White', 'matthew@example.com', 'passwordmno', '6789012345', '32109-8765432-1', 'Zumba', 'Gym2', 1),
('Laura Lee', 'laura@example.com', 'passwordpqr', '7890123456', '21098-7654321-0', 'Martial Arts', 'Gym2', 1),
('Ryan Clark', 'ryan@example.com', 'passwordstu', '8901234567', '10987-6543210-9', 'Spinning', 'Gym4', 1);


--Insert into Trainer_Gym
INSERT INTO PROJECT_DB.dbo.Trainer_Gym (TrainerID, GymID) 
VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 1),
(5, 1),
(6, 3),
(7, 3),
(8, 2),
(9, 2),
(10, 4);
--Insert into Member_Trainer
INSERT INTO PROJECT_DB.dbo.Member_Trainer (MemberID, TrainerID) 
VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 1),
(5, 1),
(6, 3),
(7, 3),
(8, 2),
(9, 2),
(10, 4);
--Insert into Member_Rating
Insert into Member_Rating (MemberID, TrainerID, Rating)
Values
(1, 1, 5),
(2, 2, 3),
(3, 3, 1),
(4, 1, 3),
(5, 1, 2),
(6, 3, 5),
(7, 3, 5),
(8, 2, 4),
(9, 2, 3),
(10, 4, 4);
--Insert into Member_Workout
Insert into Member_Workout(MemberID, WorkoutID)
Values
(1, 1),
(2, 2),
(3, 3),
(4, 1),
(5, 1),
(6, 3),
(7, 3),
(8, 2),
(9, 2),
(10, 3);
--Insert into Member_Diet
Insert into Member_Diet(MemberID, DietPlanID)
Values
(1, 1),
(2, 2),
(3, 3),
(4, 1),
(5, 1),
(6, 3),
(7, 3),
(8, 2),
(9, 2),
(10, 3);
--Insert into Member_Gym
Insert into Member_Gym(MemberID, GymID)
Values
(1, 1),
(2, 2),
(3, 3),
(4, 1),
(5, 1),
(6, 3),
(7, 3),
(8, 2),
(9, 2),
(10, 3);
--Inserting into Appointments
Insert into PROJECT_DB.dbo.Appointment 
Values
(1,1,'Rehab','08/06/2024'),
(2,1,'Counselling','02/05/2024'),
(3,1,'Exercise','01/08/2024'),
(4,1,'Physio','12/01/2024'),
(5,1,'Therapy','23/05/2024'),
(6,1,'Rehab','20/07/2024');



--Displaying all information
SELECT * FROM PROJECT_DB.dbo.Member;
SELECT * FROM PROJECT_DB.dbo.Admin;
SELECT * FROM PROJECT_DB.dbo.Owner;
SELECT * FROM PROJECT_DB.dbo.Trainer;
SELECT * FROM PROJECT_DB.dbo.Exercise;
SELECT * FROM PROJECT_DB.dbo.Workout;
SELECT * FROM PROJECT_DB.dbo.DietPlan;
SELECT * FROM PROJECT_DB.dbo.food;
SELECT * FROM PROJECT_DB.dbo.Gym;
SELECT * FROM PROJECT_DB.dbo.Appointment;
SELECT * FROM PROJECT_DB.dbo.Audit;
SELECT * FROM PROJECT_DB.dbo.Member_Workout;
SELECT * FROM PROJECT_DB.dbo.Member_Trainer;
SELECT * FROM PROJECT_DB.dbo.Member_Diet;
SELECT * FROM PROJECT_DB.dbo.Member_Gym;
SELECT * FROM PROJECT_DB.dbo.Trainer_Gym;
SELECT * FROM PROJECT_DB.dbo.Member_Rating;
--Audit
USE PROJECT_DB CREATE TABLE PROJECT_DB.DBO.Audit(
	AuditID int Primary key Identity(1,1),
	TableName varchar(50),
	ID int,
	Action varchar(50),
	ActionTime Date 
);
USE PROJECT_DB
GO 
CREATE TRIGGER NewMember
ON Project_DB.DBO.Member
AFTER INSERT 
AS 
BEGIN 
	INSERT INTO PROJECT_DB.dbo.AUDIT(TableName, ID, Action, ActionTime) 
    SELECT 'Member', I.MemberID, 'Member Added ' + CAST(I.MemberID AS VARCHAR(50)), GETDATE()
    FROM inserted I;
END;
CREATE TRIGGER NewAdmin
ON Project_DB.DBO.Admin
AFTER INSERT 
AS 
BEGIN 
    INSERT INTO PROJECT_DB.dbo.AUDIT(TableName, ID, Action, ActionTime) 
    SELECT 'Admin', I.AdminID, 'Admin Added ' + CAST(I.AdminID AS VARCHAR(50)), GETDATE()
    FROM inserted I;
END;
Go
CREATE TRIGGER NewTrainer
ON Project_DB.DBO.Trainer
AFTER INSERT 
AS 
BEGIN 
    INSERT INTO PROJECT_DB.dbo.AUDIT(TableName, ID, Action, ActionTime) 
    SELECT 'Trainer', I.TrainerID, 'Trainer Added ' + CAST(I.TrainerID AS VARCHAR(50)), GETDATE()
    FROM inserted I;
END;
GO
--
CREATE TRIGGER NewMemberGym
ON Project_DB.dbo.Member_Gym
AFTER INSERT 
AS 
BEGIN 
    INSERT INTO PROJECT_DB.dbo.AUDIT(TableName, ID, Action, ActionTime) 
    SELECT 'Member_Gym', I.MemberID, 'Member added to Gym ' + CAST(I.GymID AS VARCHAR(50)), GETDATE()
    FROM inserted I;
END;
GO
CREATE TRIGGER NewMemberDiet
ON Project_DB.dbo.Member_Diet
AFTER INSERT 
AS 
BEGIN 
    INSERT INTO PROJECT_DB.dbo.AUDIT(TableName, ID, Action, ActionTime) 
    SELECT 'Member_Diet', I.MemberID, 'Member adds Diet ' + CAST(I.DietPlanID AS VARCHAR(50)), GETDATE()
    FROM inserted I;
END;
GO
CREATE TRIGGER NewMemberTrainer
ON Project_DB.dbo.Member_Trainer
AFTER INSERT 
AS 
BEGIN 
    INSERT INTO PROJECT_DB.dbo.AUDIT(TableName, ID, Action, ActionTime) 
    SELECT 'Member_Trainer', I.MemberID, 'Member assigned to Trainer ' + CAST(I.TrainerID AS VARCHAR(50)), GETDATE()
    FROM inserted I;
END;
GO
CREATE TRIGGER NewMemberRating
ON Project_DB.dbo.Member_Rating
AFTER INSERT 
AS 
BEGIN 
    INSERT INTO PROJECT_DB.dbo.AUDIT(TableName, ID, Action, ActionTime) 
    SELECT 'Member_Rating', I.MemberID, 'Member rated Trainer ' + CAST(I.TrainerID AS VARCHAR(50)), GETDATE()
    FROM inserted I;
END;
GO

CREATE TRIGGER NewGym
ON Project_DB.dbo.Gym
AFTER INSERT 
AS 
BEGIN 
    INSERT INTO PROJECT_DB.dbo.AUDIT(TableName, ID, Action, ActionTime) 
    SELECT 'Gym', I.GymID, 'Gym Added ' + CAST(I.GymID AS VARCHAR(50)), GETDATE()
    FROM inserted I;
END;
GO
CREATE TRIGGER NewDietPlan
ON Project_DB.dbo.DietPlan
AFTER INSERT 
AS 
BEGIN 
    INSERT INTO PROJECT_DB.dbo.AUDIT(TableName, ID, Action, ActionTime) 
    SELECT 'DietPlan', I.DietPlanID, 'Diet Plan Added ' + CAST(I.DietPlanID AS VARCHAR(50)), GETDATE()
    FROM inserted I;
END;
GO
CREATE TRIGGER NewWorkout
ON Project_DB.dbo.Workout
AFTER INSERT 
AS 
BEGIN 
    INSERT INTO PROJECT_DB.dbo.AUDIT(TableName, ID, Action, ActionTime) 
    SELECT 'Workout', I.WorkoutID, 'Workout Added ' + CAST(I.WorkoutID AS VARCHAR(50)), GETDATE()
    FROM inserted I;
END;
GO
CREATE TRIGGER NewAppointment
ON Project_DB.dbo.Appointment
AFTER INSERT 
AS 
BEGIN 
    INSERT INTO PROJECT_DB.dbo.AUDIT(TableName, ID, Action, ActionTime) 
    SELECT 'Appointment', I.AppID, 'Appointment Added ' + CAST(I.AppID AS VARCHAR(50)), GETDATE()
    FROM inserted I;
END;
GO
CREATE TRIGGER DeleteMembersAndTrainersOnGymDelete
ON Project_DB.dbo.Gym
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DeletedGymID INT;

    -- Get the deleted GymID
    SELECT @DeletedGymID = GymID
    FROM deleted;

    -- Delete members associated with the deleted gym
    DELETE FROM Project_DB.dbo.Member_Gym
    WHERE GymID = @DeletedGymID;

    -- Delete trainers associated with the deleted gym
    DELETE FROM Project_DB.dbo.Trainer_Gym
    WHERE GymID = @DeletedGymID;

    -- Log the action in the AUDIT table
    INSERT INTO PROJECT_DB.dbo.AUDIT(TableName, ID, Action, ActionTime) 
    VALUES ('Gym', @DeletedGymID, 'Gym Deleted ' + CAST(@DeletedGymID AS VARCHAR(50)), GETDATE());
END;
GO
CREATE TRIGGER DeleteTrainerReferences
ON Project_DB.dbo.Trainer
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DeletedTrainerID INT;

    -- Get the deleted TrainerID
    SELECT @DeletedTrainerID = TrainerID
    FROM deleted;

    -- Update Member_Trainer table
    UPDATE Project_DB.dbo.Member_Trainer
    SET TrainerID = NULL
    WHERE TrainerID = @DeletedTrainerID;

    -- Update Trainer_Gym table
    UPDATE Project_DB.dbo.Trainer_Gym
    SET TrainerID = NULL
    WHERE TrainerID = @DeletedTrainerID;

    -- Update Member_Rating table
    UPDATE Project_DB.dbo.Member_Rating
    SET TrainerID = NULL
    WHERE TrainerID = @DeletedTrainerID;

    -- Log the action in the AUDIT table
    INSERT INTO PROJECT_DB.dbo.AUDIT(TableName, ID, Action, ActionTime) 
    VALUES ('Trainer', @DeletedTrainerID, 'Trainer Deleted ' + CAST(@DeletedTrainerID AS VARCHAR(50)), GETDATE());
END;
GO
CREATE TRIGGER DeleteMembersAndTrainersOnOwnerDelete
ON Project_DB.dbo.Owner
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DeletedOwnerID INT;

    -- Get the deleted OwnerID
    SELECT @DeletedOwnerID = OwnerID
    FROM deleted;

    -- Get the GymID associated with the deleted owner
    DECLARE @DeletedGymID INT;
    SELECT @DeletedGymID = GymID
    FROM Project_DB.dbo.Gym
    WHERE OwnerID = @DeletedOwnerID;

    -- Delete members associated with the deleted owner's gym
    DELETE FROM Project_DB.dbo.Member_Gym
    WHERE GymID = @DeletedGymID;

    -- Delete trainers associated with the deleted owner's gym
    DELETE FROM Project_DB.dbo.Trainer_Gym
    WHERE GymID = @DeletedGymID;

    -- Log the action in the AUDIT table
    INSERT INTO PROJECT_DB.dbo.AUDIT(TableName, ID, Action, ActionTime) 
    VALUES ('Owner', @DeletedOwnerID, 'Owner Deleted ' + CAST(@DeletedOwnerID AS VARCHAR(50)), GETDATE());
END;
--

SELECT * FROM Audit