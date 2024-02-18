--add a new user
INSERT INTO UserInfo(username, userPassword, userEmail, userLat,userLong) VALUES ("cMan", "steve", "charles@cmail.net",46.72381, -117.16551);
INSERT INTO ProfileInfo(UserID, ProfileFirstName, ProfileLastName, ProfileBio, ProfileClubs, ProfileHobbies, ProfileImgURL, ProfileMajor, ProfileMinor) 
    VALUES (1,"Carston", "Phillips", "Hi, I'm Carston a bookworm andplant enthusiast!", "Book Club, Garden Cougs", "reading, baking, gardening", "img/", "English Literature", "Theatre");

INSERT INTO UserInfo(username, userPassword, userEmail, userLat,userLong) VALUES ("jeffster", "Thompson", "thompson@clook.com", 46.92381, -117.16851);
INSERT INTO ProfileInfo(UserID, ProfileFirstName, ProfileLastName, ProfileBio, ProfileClubs, ProfileHobbies, ProfileImgURL, ProfileMajor, ProfileMinor) 
    VALUES (2,"Jeff", "Thompson", "I like Trains", "WSUTC, Cougs Make a Difference", "fitness, hiking, activism", "img/", "Political Science", "American History");

INSERT INTO UserInfo(username, userPassword, userEmail, userLat,userLong) VALUES ("FlowerPower809", "linda", "munson@clook.com",46.72291, -127.16611);
INSERT INTO ProfileInfo(UserID, ProfileFirstName, ProfileLastName, ProfileBio, ProfileClubs, ProfileHobbies, ProfileImgURL, ProfileMajor, ProfileMinor) 
    VALUES (3,"Linda", "Munson", "Living a blessed and natural life", "Yoga Club, Garden Cougs", "yoga, baking, gardening", "img/", "kinesiology", "0");

INSERT INTO UserInfo(username, userPassword, userEmail, userLat,userLong) VALUES ("CiaraSings", "muse", "CiaraSings@cmail.com",56.72381, -127.16551);
INSERT INTO ProfileInfo(UserID, ProfileFirstName, ProfileLastName, ProfileBio, ProfileClubs, ProfileHobbies, ProfileImgURL, ProfileMajor, ProfileMinor) 
    VALUES (4,"Ciara", "Miller", "Find me on Soundcloud", "Music Club, Rocking Cougs", "singing, guitar", "img/", "Music", "0");

INSERT INTO UserInfo(username, userPassword, userEmail, userLat,userLong) VALUES ("AnonymousAxlotl", "hidd3n", "anonymous@cmail.com",56.72311, -127.16551);
INSERT INTO ProfileInfo(UserID, ProfileFirstName, ProfileLastName, ProfileBio, ProfileClubs, ProfileHobbies, ProfileImgURL, ProfileMajor, ProfileMinor) 
    VALUES (5,"Blanche", "Boring", "0", "0", "0", "img/", "Accounting", "0");

INSERT INTO UserInfo(username, userPassword, userEmail, userLat,userLong) VALUES ("Dannebrog", "Margrethe", "aksel@ebrev.dk",56.72281, -127.16751);
INSERT INTO ProfileInfo(UserID, ProfileFirstName, ProfileLastName, ProfileBio, ProfileClubs, ProfileHobbies, ProfileImgURL, ProfileMajor, ProfileMinor) 
    VALUES (6,"Aksel", "Christiansen", "Hej, I'm Aksel, an exchange student from Denmark", "Language Club, Soccer Club", "Soccer, ", "img/", "Linguistics", "0");

INSERT INTO UserInfo(username, userPassword, userEmail, userLat,userLong) VALUES ("AnonymousAxlotl", "hidd3n", "anonymous@cmail.com",56.72889, -127.16749);
INSERT INTO ProfileInfo(UserID, ProfileFirstName, ProfileLastName, ProfileBio, ProfileClubs, ProfileHobbies, ProfileImgURL, ProfileMajor, ProfileMinor) 
    VALUES (7,"Maria", "Lopez", "I'm New to campus and eager to meet new friends", "0", "Soccer, biology, reading", "img/", "Biology", "Chemistry");

--add users and ProfileInfo

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



