using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MarkerInfo : MonoBehaviour
{
    public Image icon_img;
    public Color primaryColor;
    public GameObject userObj;
    public GameObject nearObj;
    public int userID;

    private AppManager manager;

    public void Setup(bool isUser, int _userID, AppManager caller)
    {
        if(isUser)
        {
            userObj.SetActive(true);
            nearObj.SetActive(false);
            icon_img.color = primaryColor;
        } else
        {
            userObj.SetActive(false);
            nearObj.SetActive(true);
            userID = _userID;
        }
        manager = caller;
    }

    public void HandleCallback()
    {
        manager.Handle_OnRadarSelectEvent(userID);
    }
}
