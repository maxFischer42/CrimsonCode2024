using SQLite4Unity3d;

public class UserInfo
{

    [PrimaryKey, AutoIncrement]
    public int userID { get; set; }
    public string username{ get; set; }
    public string userPassword { get; set; }
    public string userEmail { get; set; }
    public double userLat { get; set; }
    public double userLong { get; set; }

    public override string ToString()
    {
        return string.Format("[UserInfo: userID={0}, username={1},  userPassword={2}, userEmail={3}, userLat={4}, userLong={5}]", userID, username, userPassword, userEmail, userLat, userLong);
    }
}