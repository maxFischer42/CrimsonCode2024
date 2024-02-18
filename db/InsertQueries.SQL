--add a new user
INSERT INTO UserInfo(username, userPassword, userEmail, userLat,userLong) VALUES ("cMan", "steve", "charles@cmail.net",46.72381, -117.16551);
INSERT INTO UserInfo(username, userPassword, userEmail, userLat,userLong) VALUES ("jeffster", "linda", "munson@clook.com",56.72381, -127.16551);
INSERT INTO UserInfo(userLat, userLong) VALUES (45.67889, -117.3456);

INSERT INTO ProfileInfo(ProfileFirstName, ProfileLastName) VALUES ("Caleb", "Thomas");

--login Query
select userID from UserInfo WHERE username = $VAR AND userPassword = $PASSVAR;

--Retrieve UserID by username
select userID from UserInfo WHERE username = $VAR;

--update Lattitude by UserID
update UserInfo SET userLat = $Val WHERE userID = $ID;

--update Longitude by UserID
update UserInfo SET userLat = $al WHERE userID = $ID;

--update password by UserEmail
update UserInfo SET userPassword = $string WHERE userEmail == $Email;

--change userEmail
update UserInfo SET userEmail = $String WHERE userID = $ID;

--change User Profile Options
update UserProfile SET ProfileFirstName = $String WHERE userID = $ID;

update UserProfile SET ProfileLastName = $String WHERE user = $ID;

update UserProfile SET ProfileBio = $String WHERE user = $ID;

update UserProfile SET ProfileClubs = $String WHERE user = $ID;

update UserProfile SET ProfileHobbies = $String WHERE user = $ID;

update UserProfile SET ProfileHobbies = $String WHERE user = $ID;

update UserProfile SET ProfileImgURL = $ProfileImgURL WHERE user = $ID;

update UserProfile SET ProfileMajor = $major WHERE user = $ID;

update UserProfile SET ProfileMinor = $minor WHERE user =$ID;



