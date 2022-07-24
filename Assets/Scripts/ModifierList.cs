using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierList
{
    // SKY: This is intended as a utility for combining multiple modifiers that effect one variable together cleanly. 
    private List<float> modifiers = new List<float>();
    private List<string> keys = new List<string>();
    
    // Read from this to skip recalculating the mod. 
    public float lastMod = 1;

    // For adding or changing modifiers. They must be named using key strings.
    public void SetMod(float mod, string key)
    {
        // If we already have something called that, remove it first!
        if (keys.IndexOf(key) != -1)
        {
            RemoveMod(key);
        }

        modifiers.Add(mod);
        keys.Add(key);
    }

    // For removing modifiers. They must be removed by name.
    public void RemoveMod(string key)
    {
        int index = keys.IndexOf(key);

        if (index != -1)
        {
            modifiers.RemoveAt(index);
            keys.RemoveAt(index);
        }
        else Debug.LogWarning("Failed to remove modifier " + key.ToString() + " from a ModifierList, as it doesn't exist!");
    }

    // Clears ALL modifiers and resets to 1. Dangerous.
    public void ClearAllMods()
    {
        modifiers.Clear();
        keys.Clear();

        // This being 1 could be an issue in addition based lists
        lastMod = 1;
    }

    // Multiplies all modifiers, then return their value.
    public float Get()
    {
        float outputModifier = 1;

        modifiers.ForEach(mod => outputModifier*=mod);

        lastMod = outputModifier;
        return outputModifier;
    }

    // Divides all, then returns mod.
    public float GetDiv()
    {
        float outputModifier = 1;

        modifiers.ForEach(mod => outputModifier/=mod);

        lastMod = outputModifier;
        return outputModifier;
    }

    // Adds all, then returns mod. Starts at 0 rather than 1.
    // Add negatives for subtraction.
    public float GetAdd()
    {
        float outputModifier = 0;

        modifiers.ForEach(mod => outputModifier*=mod);
        
        lastMod = outputModifier;
        return outputModifier;
    }
}
