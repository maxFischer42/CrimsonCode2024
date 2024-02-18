--add a new user
INSERT INTO UserInfo(username, userPassword, userEmail, userLat,userLong) VALUES ("cMan", "steve", "charles@cmail.net",46.72381, -117.16551);
INSERT INTO UserInfo(username, userPassword, userEmail, userLat,userLong) VALUES ("jeffster", "linda", "munson@clook.com",56.72381, -127.16551);
INSERT INTO UserInfo(userLat, userLong) VALUES (45.67889, -117.3456);

INSERT INTO ProfileInfo(ProfileFirstName, ProfileLastName) VALUES ("Caleb", "Thomas");


--login Query
select * from UserInfo WHERE username = "VAR" AND userPassword = "PASSVAR";

--