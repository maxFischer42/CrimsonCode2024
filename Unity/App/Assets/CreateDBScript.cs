using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateDBScript : MonoBehaviour
{
    public TextMeshProUGUI DebugText;

    // Use this for initialization
    void Start()
    {
        StartSync();
    }

    private void StartSync()
    {
        var ds = new DataService("tempDatabase.db");
        ds.CreateDB();

        var people = ds.GetPersons();
        ToConsole(people);
        people = ds.GetPersonsNamedMonado();
        ToConsole("Searching for monado ...");
        ToConsole(people);
    }

    private void ToConsole(IEnumerable<UserInfo> people)
    {
        foreach (var person in people)
        {
            ToConsole(person.ToString());
        }
    }

    private void ToConsole(string msg)
    {
        DebugText.text += System.Environment.NewLine + msg;
        Debug.Log(msg);
    }
}
