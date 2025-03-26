using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEmitter : MonoBehaviour
{
    public GameEvent Ivent;
    public string defaultString;

    public void Emit(string message = "")
    {
        Ivent.Raise(message == "" ? defaultString : message);
    }
}
