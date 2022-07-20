using System.Collections.Generic;
using UnityEngine;

public class Quirks : MonoBehaviour
{
    private List<string> quirkList = new List<string>();
    public void AddQuirk(string quirk)
    {
        if (quirkList.Contains(quirk))
        {
            Debug.LogWarning("'" + quirk + "' is already a quirk on object '" + gameObject.name + "', ignoring addition.");
            return;
        }

        quirkList.Add(quirk);
    }

    public void RemoveQuirk(string quirk)
    {
        if (!quirkList.Contains(quirk))
        {
            Debug.LogWarning("'" + quirk + "' is not a quirk on object '" + gameObject.name + "', ignoring removal.");
            return;
        }

        quirkList.Remove(quirk);
    }

    public void RemoveAllQuirks()
    {
        quirkList.Clear();
    }

    // Returns true if the object has the quirk
    public bool HasQuirk(string quirk)
    {
        if (quirkList.Contains(quirk)) return true;

        return false;
    }
}