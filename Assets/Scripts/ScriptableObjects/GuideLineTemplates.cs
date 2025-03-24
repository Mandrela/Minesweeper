using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName="GuideLineTemplates", menuName="ScriptableObjects/GuideLineTemplates")]
public class GuideLineTemplates : ScriptableObject
{
    Kulebaka data = new Kulebaka();
    public TextAsset templateFile;
    System.Random random = new System.Random();

    private void OnEnable() {
        this.data = JsonUtility.FromJson<Kulebaka>(templateFile.text);
    }

    public string GetRandomTemplate() {
        return this.data.templates[this.random.Next(this.data.templates.Count - 1)];
    }

    public string GetRandomFiller() {
        return this.data.fillers[this.random.Next(this.data.fillers.Count)];
    }

}

[System.Serializable]
public class Kulebaka
{
    public List<string> templates = new List<string>();
    public List<string> fillers = new List<string>();
}