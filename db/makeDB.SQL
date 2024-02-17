CREATE TABLE [UserInfo] (
    [userID] INTEGER NOT NULL PRIMARY KEY,
    [userLat] REAL NOT NULL,
    [userLong] REAL NOT NULL
);

CREATE TABLE [ProfileInfo] (
    [ProfileID] INTEGER NOT NULL PRIMARY KEY,
    [userID] INTEGER NOT NULL,
    [ProfileFirstName] VARCHAR NOT NULL,
    [ProfileLastName] VARCHAR,
    [ProfileImgURL] VARCHAR,
    [ProfileHobbies] VARCHAR,
    [ProfileMajor] VARCHAR,
    [ProfileMinor] VARCHAR,
    [ProfileBio] VARCHAR
);
