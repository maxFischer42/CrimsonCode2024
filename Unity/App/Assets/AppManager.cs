using SQLite4Unity3d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using Mapbox.Unity.Map;
using Mapbox.Examples;
using System.Linq;
using UnityEngine.Networking;

public class AppManager : MonoBehaviour
{
    public enum current_state { login, map, inbox, messages, bio, settings, none };
    public current_state state = current_state.none;
    public bool isLoggedIn = false;
    public int loggedUserID = 0;

    public bool resetOnDebug = true;

    public UserSettings settings;
    public DataService service;
    public Animator animator;
    public GameObject mapObject;

    [Header("Login Page")]
    public GameObject notifyInvalidLogin;
    public TMP_InputField username_inputField;
    public TMP_InputField password_inputField;

    [Header("Map Info")]
    public double user_lat = 46.729836476807165;
    public double user_long = -117.15484245764313;
    public AbstractMap map;
    public SpawnOnMap spawnHandler;

    [Header("Bio Info")]
    public int currentUserIDInView = 0;
    public RawImage profile_image;    
    public TextMeshProUGUI u_nameField;
    public TextMeshProUGUI u_majorField;
    public TextMeshProUGUI u_HobbiesField;
    public TextMeshProUGUI u_ClubsField;
    public GameObject settingsButton;
    public GameObject editButton;
    public Texture imgTexture;

    public void Start()
    {
        PlayerPrefs.SetInt("login", 0);
        service = new DataService("existing_.db");

        StartCoroutine(LocationSetup());
        Handle_UpdateColorsEvent();
        if (GetLoginState() == false)
        {
            HandleInitialSetup();
        } else
        {
            Handle_ScreenMap();
        }
    }

    IEnumerator LocationSetup()
    {
        // Check if the user has location service enabled.
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Location not enabled on device or app does not have permission to access location");
        }
        // Starts the location service.
        Input.location.Start();
        // Waits until the location service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        // If the service didn't initialize in 20 seconds this cancels location service use.
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }
        // If the connection failed this cancels location service use.
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.LogError("Unable to determine device location");
            yield break;
        }
        else
        {
            // If the connection succeeded, this retrieves the device's current location and displays it in the Console window.
            //Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            user_lat = Input.location.lastData.latitude;
            user_long = Input.location.lastData.longitude;
        }
        // Stops the location service if there is no need to query location updates continuously.
        Input.location.Stop();
    }

    public void HandleInitialSetup()
    {
        notifyInvalidLogin.SetActive(false);
        state = current_state.login;
        if (isLoggedIn)
        {
            Handle_ScreenLogin();
        } else
        {
            loggedUserID = PlayerPrefs.GetInt("uid");
            Handle_ScreenMap();
        }        
    }

    public void SubmitLogitRequest()
    {
        // Handle Login Request
        bool _success = false;

        string attempt_name = username_inputField.text;
        string attempt_pass = password_inputField.text;
        if (attempt_name == "" || attempt_pass == "") return;

        // Request for user of username "attempt_name", and then compare passwords.
        // This is extremely not secure but its a hackathon so gg
        // People next to me are watching revenge of the sith with ai generated dialogue and its funny but distracting
        // its 4:30 AM :D WE MOOOOVE!!!!!
        var user = service.GetRequestedUser(attempt_name);
        if(user != null)
        {
            if(user.userPassword == attempt_pass)
            {
                _success = true;
                PlayerPrefs.SetInt("uid", user.userID);
                loggedUserID = user.userID;
            }
        }

        if (_success == false)
        {
            notifyInvalidLogin.SetActive(true);
        } else
        {
            HandleLoginSuccess();
        }
    }

    public void RefreshMap()
    {
        map.SetCenterLatitudeLongitude(new Mapbox.Utils.Vector2d(user_lat, user_long));
    }


    public void HandleLoginSuccess()
    {
        notifyInvalidLogin.SetActive(false);
        SetLoginState(isLoggedIn);
        Handle_ScreenMap();
    }

    public bool GetLoginState()
    {
        if (PlayerPrefs.GetInt("login") == 1) return true;
        return false;
    }

    public void SetLoginState(bool isLoggedIn)
    {
        int s = isLoggedIn ? 1 : 0;
        PlayerPrefs.SetInt("login", s);
    }

    public void UpdateBackgroundColor(Color c)
    {
        var obj = FindObjectsOfType<Image>();
        foreach (Image i in obj)
        {
            if (i.tag == "COLOR_BACKGROUND")
            {
                i.color = c;
            }
        }
    }

    public void PopulateMap()
    {
        RefreshMap();
        while(!spawnHandler.gameObject.activeInHierarchy) { /* lmao this is so bad right here */}
        foreach(GameObject o in spawnHandler._spawnedObjects)
        {
            Destroy(o);
        }
        
        List<Mapbox.Utils.Vector2d> positions = new List<Mapbox.Utils.Vector2d>();
        Mapbox.Utils.Vector2d userMarkerPos = new Mapbox.Utils.Vector2d(user_lat, user_long);
        positions.Add(userMarkerPos);

        List<int> uids = new List<int>();

        // Right now, we only have users in the database who are considered nearby.
        // In the future, we'd have a check every so often to see who you are close to and
        // parse the results that way.

        var userList = service.GetPersons();
        foreach(UserInfo u in userList)
        {
            if (u.userID == loggedUserID) continue;
            double x = u.userLat;
            double y = u.userLong;
            Mapbox.Utils.Vector2d coords = new Mapbox.Utils.Vector2d(x, y);
            positions.Add(coords);
            Debug.Log(u);
            uids.Add(u.userID);
        }
        spawnHandler.SpawnObjects(positions, uids, this);
    }

    public void UpdatePrimaryColor(Color c)
    {
        var obj = FindObjectsOfType<Image>();
        foreach (Image i in obj)
        {
            if (i.tag == "COLOR_PRIMARY")
            {
                i.color = c;
            }
        }
    }

    public void UpdateSecondaryColor(Color c)
    {
        var obj = FindObjectsOfType<Image>();
        foreach (Image i in obj)
        {
            if (i.tag == "COLOR_SECONDARY")
            {
                i.color = c;
            }
        }
    }

    public string formatListString(string input, char delimiter, int limit)
    {
        List<string> list = input.Split(delimiter).ToList<string>();
        string final = "";
        for(int i = 0; i < limit && i < list.Count; i++)
        {
            if (i != 0) final += ", ";
            final += list[i];
        }
        return final;
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            imgTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            profile_image.texture = imgTexture;
        }
    }

    public void Handle_ScreenLogin()
    {
        mapObject.SetActive(false);
        animator.SetInteger("current_state_id", 0);
    }

    public void Handle_ScreenMap()
    {
        mapObject.SetActive(true);
        animator.SetInteger("current_state_id", 1);
        PopulateMap();
    }

    public void Handle_ScreenInbox()
    {
        mapObject.SetActive(false);
        animator.SetInteger("current_state_id", 2);
    }

    public void Handle_ScreenMessages()
    {
        mapObject.SetActive(false);
        animator.SetInteger("current_state_id", 3);
    }

    public void Handle_ScreenBio()
    {


        mapObject.SetActive(false);
        animator.SetInteger("current_state_id", 4);

        if(currentUserIDInView == loggedUserID)
        {
            editButton.SetActive(true);
            settingsButton.SetActive(true);
        } else
        {
            editButton.SetActive(false);
            settingsButton.SetActive(false);
        }

        ProfileInfo profile = service.GetRequestedUserByID(currentUserIDInView);
        Debug.Log(profile);
        string hobbies = profile.ProfileHobbies;
        if(hobbies != "0")
        {
            hobbies = "Hobbies: " + formatListString(hobbies, ',', 3);
        } else { hobbies = ""; }
        u_HobbiesField.text = hobbies;

        string clubs = profile.ProfileClubs;
        if (clubs != "0")
        {
            clubs = "Clubs: " + formatListString(clubs, ',', 3);
        }
        else { clubs = ""; }
        u_ClubsField.text = clubs;

        string major = profile.ProfileMajor;
        if(major != "0")
        {
            major = "Major: " + major;
        } else { major = ""; }
        u_majorField.text = major;

        string img = profile.ProfileMinor;
        if(img != "0")
        {
            profile_image.gameObject.SetActive(true);
            StartCoroutine(DownloadImage(img));
        } else
        {
            profile_image.gameObject.SetActive(false);
        }

        string name = "" + profile.ProfileFirstName + " " + profile.ProfileLastName;
        u_nameField.text = name;
    }

    public void Handle_ScreenSettings()
    {
        mapObject.SetActive(false);
        animator.SetInteger("current_state_id", 5);
    }

    public void Handle_OnLogoutEvent()
    {
        SetLoginState(false);
        loggedUserID = 0;
        HandleInitialSetup();
    }

    public void Handle_OnRadarSelectEvent(int userID)
    {
        currentUserIDInView = userID;
        Handle_ScreenBio();
    }

    public void Handle_UpdateColorsEvent()
    {
        UpdateBackgroundColor(settings.backgroundColor);
        UpdatePrimaryColor(settings.primaryColor);
        UpdateSecondaryColor(settings.secondaryColor);
    }

    public void Handle_SelfProfileEvent()
    {
        currentUserIDInView = loggedUserID;
        Handle_ScreenBio();
    }
}
