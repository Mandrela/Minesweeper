using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName="GuideLineTemplates", menuName="ScriptableObjects/GuideLineTemplates")]
public class GuideLineTemplates : ScriptableObject
{
    Kuleboka data = new Kuleboka();
    public TextAsset templateFile;

    private void OnEnable() {
        this.data = JsonUtility.FromJson<Kuleboka>(templateFile.text);
    }

    public string GetRandomTemplate() {
        return this.data.templates[Utils.Next(this.data.templates.Count)];
    }

    public string GetRandomFiller() {
        return this.data.fillers[Utils.Next(this.data.fillers.Count)];
    }

}

[System.Serializable]
public class Kuleboka
{
    public List<string> templates = new List<string>();
    public List<string> fillers = new List<string>();
}