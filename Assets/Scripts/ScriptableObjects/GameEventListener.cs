using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent Event;
    public UnityEvent<string> Response;

    private void OnEnable() { Event.RegisterListener(this); }
    private void OnDisable() { Event.UnregisterListener(this); }
    public void OnEventRaised(string message) { Response.Invoke(message); }
}
