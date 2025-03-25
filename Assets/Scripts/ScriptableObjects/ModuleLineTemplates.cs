using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName="ModuleLineTemplates", menuName="ScriptableObjects/ModuleLineTemplates")]
public class ModuleLineTemplates : ScriptableObject
{
    Kulebaka data = new Kulebaka();
    public TextAsset templateFile;

    private void OnEnable() {
        this.data = JsonUtility.FromJson<Kulebaka>(templateFile.text);
    }

    public string GetRandomJohn() {
        Debug.Log("whaaat");
        return this.data.john[Utils.Next(this.data.john.Count)];
    }

    public string GetRandomGuide() {
        return this.data.guide[Utils.Next(this.data.guide.Count)];
    }

}

[System.Serializable]
public class Kulebaka
{
    public List<string> john = new List<string>();
    public List<string> guide = new List<string>();
}