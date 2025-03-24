using System.Collections.Generic;
using UnityEngine;

public class RuntimeSet<T> : ScriptableObject
{
    public List<T> Items = new List<T>();

    public void Add(T t) {
        if (!Items.Contains(t)) Items.Add(t);
    }

    public void Remove(T t) {
        if (Items.Contains(t)) Items.Remove(t);
    }

    public void Clear() {
        Items = new List<T>();
    }

    public T GetItem(int index) {
        return Items[index];
    }

    public int GetCount() {
        return Items.Count;
    }

    public List<T> GetCopy() {
        return Items;
    }
}
