using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCatcher : MonoBehaviour
{
    public string id = "None";

    // Start is called before the first frame update
    public void Log(string message) {
        Debug.Log("[" + id + "] Caught Event with message: " + message);
    }
}
