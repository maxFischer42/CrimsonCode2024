using SQLite4Unity3d;

public class ProfileInfo
{
    public int ProfileID { get; set; }
    public int userID { get; set; }
    public string ProfileFirstName { get; set; }
    public string ProfileLastName { get; set; }
    public string ProfileImgUrl { get; set; }
    public string ProfileHobbies { get; set; }
    public string ProfileClubs { get; set; }
    public string ProfileMajor { get; set; }
    public string ProfileMinor { get; set; }
    
    // No profile bio, not needed

    public override string ToString()
    {
        return string.Format("[ProfileInfo: ProfileID={0}, userID={1}, ProfileFirstName={2}, ProfileLastName={3}, ProfileImgUrl={4}, ProfileHobbies={5}, ProfileClubs={6}, ProfileMajor={7}, ProfileMinor={8}]", 
            ProfileID, userID, ProfileFirstName, ProfileLastName, ProfileImgUrl, ProfileHobbies, ProfileMajor, ProfileClubs, ProfileMinor);
    }
}