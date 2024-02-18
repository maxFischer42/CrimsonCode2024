using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService
{

    private SQLiteConnection _connection;

    public DataService(string DatabaseName)
    {

#if UNITY_EDITOR
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);
#elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                // then save to Application.persistentDataPath
                File.Copy(loadDb, filepath);

#elif UNITY_WINRT
		var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
		
#elif UNITY_STANDALONE_OSX
		var loadDb = Application.dataPath + "/Resources/Data/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
		// then save to Application.persistentDataPath
		File.Copy(loadDb, filepath);
#else
	var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
	// then save to Application.persistentDataPath
	File.Copy(loadDb, filepath);

#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
        _connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        Debug.Log("Final PATH: " + dbPath);

    }

    public void CreateDB()
    {
        _connection.DropTable<UserInfo>();
        _connection.CreateTable<UserInfo>();

        _connection.InsertAll(new[]{
            new UserInfo{
                userID = 1,
                username = "monado",
                userPassword = "12345",
                userEmail = "monadokami@gmail.com",
                userLat = 46.7290157f,
                userLong = -117.1559427f,

            },
        });
    }

    public IEnumerable<UserInfo> GetPersons()
    {
        return _connection.Table<UserInfo>();
    }

    public IEnumerable<ProfileInfo> GetProfiles()
    {
        return _connection.Table<ProfileInfo>();
    }

    public IEnumerable<UserInfo> GetPersonsNamedMonado()
    {
        return _connection.Table<UserInfo>().Where(x => x.username == "monado");
    }

    public UserInfo GetJohnny()
    {
        return _connection.Table<UserInfo>().Where(x => x.username == "Johnny").FirstOrDefault();
    }

    public UserInfo GetRequestedUser(string uName)
    {
        return _connection.Table<UserInfo>().Where(x => x.username == uName).FirstOrDefault();
    }

    public ProfileInfo GetRequestedUserByID(int uID)
    {
        return _connection.Table<ProfileInfo>().Where(x => x.userID == uID).First();
    }

    public UserInfo CreatePerson()
    {
        var p = new UserInfo
        {
            username = "Johnny",
            userEmail = "test@test.co",
        };
        _connection.Insert(p);        
        return p;
    }

    // use _connection.Update(p) for editing profile
}