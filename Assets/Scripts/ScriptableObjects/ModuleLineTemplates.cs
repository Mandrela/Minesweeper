using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName="ModuleLineTemplates", menuName="ScriptableObjects/ModuleLineTemplates")]
public class ModuleLineTemplates : ScriptableObject
{
    public TextAsset templateFile;
    FuckedArray data;

    void OnEnable()
    {
        this.data = JsonUtility.FromJson<FuckedArray>(templateFile.text);
        this.data._loaded = true;
    }

    public string GetRandom()
    {
        return this.data.str[Utils.Next(this.data.str.Count)];
    }

}

class FuckedArray
{
    public List<string> str;
    public bool _loaded = false;
}
