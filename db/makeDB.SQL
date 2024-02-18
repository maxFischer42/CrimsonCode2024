PRAGMA foreign_keys = ON;

CREATE TABLE [UserInfo] (
    [userID] INTEGER PRIMARY KEY,
    [username] CHAR(32) UNIQUE NOT NULL,
    [userPassword] CHAR(32) NOT NULL,
    [userEmail] CHAR(64) NOT NULL,
    [userLat] REAL,
    [userLong] REAL
);

CREATE TABLE [ProfileInfo] (
    [ProfileID] INTEGER PRIMARY KEY,
    [userID] INTEGER NOT NULL,
    [ProfileFirstName] VARCHAR NOT NULL,
    [ProfileLastName] VARCHAR,
    [ProfileImgURL] VARCHAR,
    [ProfileHobbies] VARCHAR,
    [ProfileClubs] VARCHAR,
    [ProfileMajor] VARCHAR,
    [ProfileMinor] VARCHAR,
    [ProfileBio] VARCHAR,
    FOREIGN KEY (userID) REFERENCES UserInfo(userID)
);
