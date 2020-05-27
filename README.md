# FedtFitness
1. Download and open in Visual Studios
2. Click on Tools at the top navigate to NuGet package manager then click on Manage NuGet packages for solution
3. Check that Newtonsoft.Json is installed and updated as well as EntityFramework
4. If it is still set to run from "Any CPU" to x86
5. Click on View at the top Open SQL Server Object Explorer
6. Create a new DB under localdb with the name "FedtDB"
7. Query the two Scripts at the below seperately and if it does not work try to copy and paste them into word and run them again. The first
script is to make the tables, and the second is to provide them with data. Further instructions will be below 

---COPY BELOW THIS LINE AND CONTINUE COPYING UNTIL LINE 109 FOR THE FIRST SCRIPT---

CREATE TABLE [dbo].[Account] (

[Idregister] INT NOT NULL,

[Username] VARCHAR (50) NOT NULL,

[Password] VARCHAR (50) NOT NULL,

[Email] VARCHAR (50) NOT NULL,

PRIMARY KEY CLUSTERED ([Idregister] ASC)

);

CREATE TABLE [dbo].[Equipment] (

[Equipment_ID] INT NOT NULL,

[Name] VARCHAR (50) NULL,

PRIMARY KEY CLUSTERED ([Equipment_ID] ASC)

);

CREATE TABLE [dbo].[Excercise] (

[Excercise_ID] INT NOT NULL,

[ExName] VARCHAR (50) NULL,

[Length] INT NULL,

[Equipment_ID] INT NULL,

[Muscles_ID] INT NULL,

[Description] VARCHAR (500) NULL,

PRIMARY KEY CLUSTERED ([Excercise_ID] ASC)

);

GO

CREATE NONCLUSTERED INDEX [FK]

ON [dbo].[Excercise]([Equipment_ID] ASC, [Muscles_ID] ASC);

CREATE TABLE [dbo].[MuscleGroups] (

[Muscles_ID] INT NOT NULL,

[MGName] VARCHAR (50) NULL,

PRIMARY KEY CLUSTERED ([Muscles_ID] ASC)

);

CREATE TABLE [dbo].[Profile] (

[Profile_ID] INT NOT NULL,

[Account_ID] INT NULL,

[Username] VARCHAR (20) NULL,

PRIMARY KEY CLUSTERED ([Profile_ID] ASC)

);

GO

CREATE NONCLUSTERED INDEX [FK]

ON [dbo].[Profile]([Account_ID] ASC);

CREATE TABLE [dbo].[Workout] (

[Workout_ID] INT NOT NULL,

[Profile_ID] INT NULL,

[Excercise_ID] INT NULL,

[Length] INT NULL,

[Date] DATETIME NULL,

PRIMARY KEY CLUSTERED ([Workout_ID] ASC)

);

GO

CREATE NONCLUSTERED INDEX [FK]

ON [dbo].[Workout]([Profile_ID] ASC, [Excercise_ID] ASC);





---------------------END OF TABLE SCRIPT (DO NOT COPY THIS LINE)--------------------------
------COPY BELOW THIS LINE AND CONTINUE COPYING UNTIL LINE 262 FOR THE SECOND SCRIPT------





INSERT INTO [dbo].[Equipment] ([Equipment_ID], [Name]) VALUES (1, N'None')

INSERT INTO [dbo].[Equipment] ([Equipment_ID], [Name]) VALUES (2, N'Dumbbells')

INSERT INTO [dbo].[Equipment] ([Equipment_ID], [Name]) VALUES (3, N'Chair')

INSERT INTO [dbo].[Equipment] ([Equipment_ID], [Name]) VALUES (4, N'Resistance band')

INSERT INTO [dbo].[Equipment] ([Equipment_ID], [Name]) VALUES (5, N'Medicine ball')

INSERT INTO [dbo].[Equipment] ([Equipment_ID], [Name]) VALUES (6, N'Sandbag')

INSERT INTO [dbo].[Equipment] ([Equipment_ID], [Name]) VALUES (7, N'Ab wheel')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (1, N'T Raises', NULL, 2, 3, N'Grab a pair of light-weight dumbbells and stand with feet hip-width apart. Take a slight bend in knees as you shift hips back and lower torso until it''s parallel to the floor. Bring weights together and turn palms to face forward. Keeping arms straight, lift weights up to shoulder height then lower back down. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (2, N'Single-Arm Dumbbell Rows', NULL, 2, 3, N'Holding a medium-weight?dumbbell in one hand, stand with feet hip-width apart, bend knees, and shift hips back, lowering torso until nearly parallel with the ground. Place right hand on a wall in front of you for balance. Draw the weight up toward chest by bending left elbow straight up toward the ceiling. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (3, N'Delt Raise', NULL, 2, 3, N'Holding a pair of light-weight?dumbbells, stand with feet hip-width apart, knees slightly bent. Shift hips back as you lower torso until nearly parallel with the ground. Turn palms to face each other, bend elbows, and lift weights up to shoulder height. Gently lower back down, keeping core and glutes engaged during the entire movement. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (4, N'Plank with Lateral Arm Raise', NULL, 1, 3, N'Start in a straight-arm plank with hands below and in line with shoulders, feet slightly wider than hip-width apart. Keeping hips as still as possible, lift one arm up to shoulder height. Return to center, then lift the other arm to shoulder height. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (5, N'Push-Up Hold', NULL, 1, 6, N'Start in pushup position with hands slightly wider than shoulder width, feet hip-width apart. Your body should form a straight line from heels to head. Bend elbows and lower body until hovering a few inches above the ground. Hold for 1 deep breath, and then press half-way up and hold for 1 deep breath. Lower back down to your lowest point, holding for 1 deep breath. Return to your half-way point for one more hold. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (6, N'Back Blaster', NULL, 1, 3, N'Lay flat on your stomach. Lift your chest up, arching your back and interlacing your hands behind your back. Lift your hands and legs up, touching your heels together. Slowly move your legs apart and bring them back together. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (7, N'Twister', NULL, 1, 3, N'Squat into chair position

with hands in prayer pose in front of chest. Twist your torso to the right while remaining in chair pose, and place the left elbow on the outside of the right knee. The?other elbow should be pointing to the ceiling. Hold for three breaths, then return to center. Repeat on the other side. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (8, N'Pilates Press', NULL, 1, 3, N'Start in push-up position and bend one leg behind you so the bottom of the foot is facing toward the ceiling. Lower your body to the ground by bending your elbows, keeping your back straight. Push yourself back up. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (9, N'Triceps Dip', NULL, 1, 2, N'Sit on the floor with knees bent and feet flat. Place hands behind you, elbows bent, wrists underneath shoulders, and fingertips facing in toward body. Straighten arms and lift butt off the floor. Slowly bend elbows to lower body toward the floor. Straighten arms again, using triceps to push yourself up. Repeat. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (10, N'Reverse Plank', NULL, 1, 4, N'Sit on the floor with legs extended in front of you. Place hands slightly behind you, palms on the floor underneath shoulders, fingertips facing in toward body.

Press into palms to lift hips and torso off the floor. Keep arms and legs straight and make sure abs and glutes are engaged. Pause for a few seconds.

Lower back down to the ground. Repeat. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (11, N'Plank Shoulder Tap', NULL, 1, 7, N'Start in a high plank position with hands flat on the floor about shoulder-width apart, wrists stacked under shoulders.

Tap right hand to left shoulder, then return to start, keeping abs and glutes engaged to keep hips as stable as possible.

Repeat, tapping left hand to right shoulder. Continue alternating. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (12, N'Up-down plank', NULL, 1, 5, N'Start in a high plank position with hands flat on the floor about shoulder-width apart, wrists stacked under shoulders. Place right forearm down on the ground, maintaining a plank. Then come down to left forearm and pause in a forearm plank. Press back into right hand, then left hand to return to

a high plank. Move as quickly as you can while keeping abs and glutes engaged, hips stable, and a straight line from shoulders to heels. Repeat, alternating which arm you start with each time. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (13, N'Arm Circles', NULL, 3, 7, N'Sit on the chair with your back straight, legs bent at the knees 90 degrees and feet planted on the floor. Touch your shoulders with your fingers, and without moving any other parts of your body, roll your arms backward continuously in a circular motion. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (14, N'Biceps curl', NULL, 2, 1, N'Stand straight with a weight in each hand and both arms at your sides.

Rotate your forearm so that your palms face up, your thumbs face out, and your elbows are tight by your body. Bend at the elbow to lift the weight towards your shoulder. Slowly squeeze your biceps once your hand reaches its final position. Lower your hand back down to your side to return to the start position. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (15, N'Overhead triceps extension', NULL, 2, 2, N'Stand with your feet hip-width apart, holding the dumbbells in each hand, raise your arms up straight above your head. With your elbows close to your ears, bend at your elbow and lower the weights behind your head. Keep elbows tight, straighten arms and slowly lift the dumbbells towards the ceiling. Squeeze your triceps muscles once at the top position and hold for a second. Slowly lower your hands back down to the start position. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (16, N'Bend-over row', NULL, 2, 3, N'Stand with your feet hip-width apart and with your palms facing your body. Keep knees slightly bent, then hinge at the hips until your torso is almost parallel to the floor and your arms hang perpendicular to the floor. While keeping your torso stationary, lift your weights to drive your elbows behind your body. Squeeze your shoulder blades together to engage your back muscles at the top of the movement and hold for a second. Slowly lower your weights to the start position. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (17, N'Lateral raise', NULL, 2, 7, N'Stand with your feet hip-width apart, arms hanging by your sides, with the dumbbells in your hands and palms facing your body. Engage your core, keeping a slight bend in the arms before slowly lifting your arms up sideways with your palms facing the floor. Once your arms reach shoulder-height, pause at the top of the movement. Slowly lower your hands back down to the start position. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (18, N'Chair squat', NULL, 3, 4, N'Stand in front of the chair with your legs shoulder-width apart. Squat down like you are sitting on the chair but

without actually touching it. Maintain a proper position: back straight, knees above the feet, weight on the heels. Keep your hands together, arms bent at the elbows. Straighten your legs to go back to the starting position. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (19, N'Bulgarian split squat', NULL, 3, 4, N'Stand in front of the chair. Put your left foot on the chair behind you. Bend your right leg at the knee until the left knee almost touches the floor. Keep your back straight, arms on the hips. Straighten your right leg and go back to the starting position. Change legs and put your right foot on the chair behind you. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (20, N'Squat', NULL, 1, 4, N'Stand with your feet hip-width apart. Keeping your chest up and back straight throughout, bend your knees and lower, pushing your hips back until your thighs are parallel to the ground. Then drive through your heels to return to standing. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (21, N'Lunges', NULL, 1, 4, N'From standing, take a big step forwards with your right foot and lower until both your knees are bent at 90°. Push back up through your right foot to standing. Do all your reps on one leg, then switch to the other. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (22, N'Glute bridge', NULL, 1, 4, N'Lie on your back with your knees bent and feet planted close to your glutes. Raise your hips until you form a straight line with your body from your knees to your neck, pause for a moment, then lower back to the start. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (23, N'Dumbbell swing through', NULL, 2, 4, N'Hold one dumbbell with both hands between your legs and crouch down until your knees are at 90 degree angles. Lift yourself to a standing position while bringing the dumbbell up above your head and slowly return to starting position after a short pause. Keep your back straight throughout. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (24, N'Toe raise', NULL, 2, 4, N'Stand up and hold one dumbbell in each hand against the sides of your body, palms facing each other.

Lift your heels from the ground by pushing on your toes and lower yourself back down after a short pause. Keep the rest of your body still throughout. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (25, N'Side leg raises', NULL, 4, 4, N'Lie down on your side with a looped resistance band above your knees. With your bottom leg bent,

straighten your top leg. Keeping your hips level and core tight, slowly raise your leg as high as you can, then lower it so it’s hovering above the floor. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (26, N'Lying leg curl', NULL, 4, 4, N'Lie on your stomach with your toes pointed down and a resistance band around your ankles.

Bend your right leg at the knee, bringing your foot to a 90-degree angle. Pause, then lower back down to the floor. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (27, N'Bent Leg V-Up', NULL, 1, 5, N'Start lying on back with legs in air and bent at 90-degrees (shins parallel to floor) and hands clasped over chest. In one movement, straighten legs and lift torso up, extending arms and trying to touch toes with hands. Lower back down to start. That’s one rep. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (28, N'Dead bug', NULL, 1, 5, N'Lay face up on the floor with arms straight above your shoulders. To start, bring your knees directly over your hips and bend at the knee so that your calf forms a 90-degree angle with your thigh. Next, simultaneously lower your left arm above your head while straightening your right leg and sending it towards the floor. Pause, return to the starting position, and then repeat on the opposite side. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (29, N'Dumbbell side bend', NULL, 2, 5, N'Stand with your feet hip-width apart and hold a dumbbell in your right hand, palm facing inwards towards the torso. Keep your back straight, activate your core, and then bend to the side as far as possible—but only at the waist. Hold for one second at the bottom of your range of motion, and return to start for one rep. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (30, N'Bird dog', NULL, 1, 5, N'Think of this as an upside-down dead bug. Start in a tabletop position, with your shoulders over wrists and hips over knees. Engage your core while simultaneously lifting your right arm and left leg. Your foot should be flexed as you kick back, and your palm should face in towards your body. Pause for one second when your arm and leg are at the same height as your torso, and then bring your elbow and knee to touch underneath the body ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (31, N'Medicine ball slam ', NULL, 5, 5, N'Standing up with your knees slightly bent lift the?medicine ball?directly over your head with your arms extended. Rise up on the balls of your feet and use your?core muscles?to throw the ball to the ground as you bend forwards at the waist. Catch the ball and repeat. The motion will not only train your abs but will also give you powerful shoulders. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (32, N'Side Jackknife', NULL, 1, 5, N'Lay on your side with your left arm extended out on the floor and you right arm bent to your head with your elbow bent out. Make sure your right leg is on top of your left. Bring your right

elbow to your left leg as you raise your body up, contracting your obliques and slowly lower down before swapping sides after reps ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (33, N'Sandbag sit up', NULL, 6, 5, N'Lie with your back on the ground and your knees bent upwards. Hold?a sandbag up above you with both extended arms and crunch forwards as you tense your core so your body performs a V shape with your thighs. Carefully lower down and repeat. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (34, N'Ab Wheel Rollout', NULL, 7, 5, N'Kneel on the floor and hold an?ab wheel?beneath your shoulders. Brace your abs and roll the wheel forward until you feel you’re about to lose tension in your core and your hips might sag. Roll yourself back to start. Do as many reps as you can with perfect form and end the set when you think you might break form. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (35, N'Medicine Ball Russian Twist', NULL, 5, 5, N'Sit on the floor in the top position of a sit-up and, holding a?medicine ball?with both hands, extend your arms in front of you. Explosively twist your body to one side and then twist back. Alternate sides. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (36, N'Medicine Ball Mountain Climber', NULL, 5, 5, N'Hold the?medicine ball?with both hands and get into pushup position on the floor. Drive one knee up to your chest, then quickly drive it back while you raise the opposite knee. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (37, N'Plank', NULL, 1, 5, N'Get into pushup position and bend your elbows to lower your forearms to the floor. Hold the position with abs braced. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (38, N'Resisted Reverse Crunch', NULL, 4, 5, N'Lie on your back on the floor and wrap the resistance band around the arches of your feet. Cross the ends of the band over each other to make an “X” and grasp the ends with opposite hands. Bend your hips and knees so that your knees are near your chest and then crunch your torso off the floor. Extend your legs while you raise your arms overhead—keep your shoulder blades off the floor. That’s one rep. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (39, N'Wide Press-up', NULL, 1, 6, N'Perform a standard press-up, but with your hands placed wider than shoulder-width apart. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (40, N'Diamond Press-up', NULL, 1, 6, N'Perform a press-up with your hands close enough for the tips of your thumbs and index fingers to touch. That''s the diamond shape. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (41, N'Offset press-up', NULL, 3, 6, N'Get in a press-up position with one hand elevated on a stable surface. Keeping your core engaged, bend your elbows to lower your chest, keeping your elbows close to your sides, then press back up to return to the start. At the end of the set, switch hands and do the same number of reps again. Brace your abs and squeeze your glutes to keep your entire torso stable to make the most of each rep. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (42, N'Spider-Man press-man', NULL, 1, 6, N'Start in a press-up position. Keeping your weight on your arms, bend your elbows to lower your chest. As you lower, draw one knee in towards your elbow. Pause at the bottom, then press back up and return your leg as you do, then repeat with your other knee. Engage your core before each set by pulling in your bellybutton to tense your abs and deep core muscles. Being fully engaged will keep your body stable and let you draw your knee all the way in. ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (43, N'Chest fly', NULL, 2, 6, N'Lie on your back, with your knees bent and feet placed flat on the ground. Hold a dumbbell in each hand, and extend your arms upward, palms facing toward each other. Keeping a slight bend in

your elbows, lower your arms to the side of your body, parallel with your shoulders, until your hands are about six inches off the ground. Slowly reverse the movement and return to start.? ')

INSERT INTO [dbo].[Excercise] ([Excercise_ID], [ExName], [Length], [Equipment_ID], [Muscles_ID], [Description]) VALUES (44, N'Bridge With Chest Press', NULL, 2, 6, N'Lie on your back, with your knees bent and feet placed flat on the ground. Lift your hips so your body forms a straight line from your knees to shoulders. Hold a dumbbell in each hand, and extend your arms upward, with palms facing toward your feet. Slowly bend your arms and lower your them to the side, parallel with your shoulders, until your elbows nearly touch the ground. Slowly reverse the movement and return to start. ')

INSERT INTO [dbo].[MuscleGroups] ([Muscles_ID], [MGName]) VALUES (1, N'Bicep')

INSERT INTO [dbo].[MuscleGroups] ([Muscles_ID], [MGName]) VALUES (2, N'Tricep')

INSERT INTO [dbo].[MuscleGroups] ([Muscles_ID], [MGName]) VALUES (3, N'Back')

INSERT INTO [dbo].[MuscleGroups] ([Muscles_ID], [MGName]) VALUES (4, N'Legs')

INSERT INTO [dbo].[MuscleGroups] ([Muscles_ID], [MGName]) VALUES (5, N'Abs')

INSERT INTO [dbo].[MuscleGroups] ([Muscles_ID], [MGName]) VALUES (6, N'Chest')

INSERT INTO [dbo].[MuscleGroups] ([Muscles_ID], [MGName]) VALUES (7, N'Shoulders')



------END OF DATA ENTRY SCRIPT (DO NOT COPY THIS LINE)------
8. Once queries were run successfully update the SQL Server Object Explorer
9. Rebuild the application 
10. Open Solution Explorer
11. Right click on "Solution 'FedtFitness' (2 of 2 projects) and click on "Set Startup Projects..."
12. Click on "Multiple startup projects" then under action change "FedtFitness" and "FedtWebAPIService" both to Start
click Apply and then OK
13. Run the Application by clicking on the Start button
14. Once the application and WebAPI have launched click on "Register"
15. Enter a Username, Password, and E-mail and then Click Register (if this does not work close the application and open it again)
16. Once you have registered click on Login
17. Your username is case sensitive so if you made it with all lower case then do all lower case during the login proccess
18. If you are still having trouble, check the data in the account table using SQL Server Object Explorer
19. Once logged in click on the lowest button in the hamburger menu (the one below the home icon)
20. Then select equipment at the top ( i reccomend selecting none because it will return the most excercises) and then select 
a Muscle Group from the other dropdown
21. A list of filtered Excercises will be displayed on the left, you can click on them to see the excercises details
22. Once equipment and muscle group have been selected you can click on start workout 
23. This is as far we got for the initial demo so now you can click home and play around with the filters more if you'd like

END



