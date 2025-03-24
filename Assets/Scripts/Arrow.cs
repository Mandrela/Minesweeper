using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public bool IsRight = false;
    [SerializeField] bool disabled = false;
    
    GuideManager HostScript;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        HostScript = GetComponentInParent<GuideManager>();
        rend = GetComponent<Renderer>();
    }

    void OnMouseEnter() {
        if (!disabled) {
            rend.material.color = HostScript.HighlightColor;
        }
    }

    void OnMouseExit() {
        if (!disabled) {
            rend.material.color = HostScript.NormalColor;
        }
    }

    void OnMouseDown() {
        if (!disabled) {
            HostScript.ChangeText(IsRight);
        }
    }

    public void Disable() {
        this.disabled = true;
        this.rend.material.color = this.HostScript.DisableColor;
    }

    public void Enable() {
        this.disabled = false;
        this.rend.material.color = this.HostScript.NormalColor;
    }
}
