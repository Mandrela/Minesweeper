using UnityEngine;

[CreateAssetMenu(menuName="ScriptableObjects/StringSet")]
public class StringSet : RuntimeSet<string>
{
    public void AddNonUnique(string s) {
        this.Items.Add(s);
    }
}