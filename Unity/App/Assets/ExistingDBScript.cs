using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ExistingDBScript : MonoBehaviour
{

    public TextMeshProUGUI DebugText;

    // Use this for initialization
    void Start()
    {
        var ds = new DataService("existing.db");
        //ds.CreateDB ();
        var people = ds.GetPersons();
        ToConsole(people);

        people = ds.GetPersonsNamedMonado();
        ToConsole("Searching for monado ...");
        ToConsole(people);

        var p = ds.GetProfiles();
        foreach (var v in p)
        {
            Debug.Log(p);
        }

        /* ds.CreatePerson();
         ToConsole("New person has been created");
         var p = ds.GetJohnny();
         ToConsole(p.ToString()); */

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