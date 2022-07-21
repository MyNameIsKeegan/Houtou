using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public static PrefabManager Instance { get; private set; }
    [Header("Prefabs on this list are automatically registered on startup")]
    public List<GameObject> prefabObjectList = new List<GameObject>();
    [Space]
    [Header("Currently registered prefabs")]
    [SerializeField] private List<string> prefabNameList = new List<string>();
    
    private void Awake() 
    { 
        // Kill new instances if there is already one present
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
            return;
        } 
        else 
        { 
            Instance = this; 
            // DontDestroyOnLoad(this);
        } 

        for(int i = 0; i < prefabObjectList.Count; i++)
        {
            Register(prefabObjectList[i]);
        }
    }
    
    public void Register(GameObject prefab)
    {
        if (prefabNameList.Contains(prefab.name.ToLower()))
        {
            Debug.LogWarning("Prefab " + prefabNameList.IndexOf(prefab.name.ToLower()) + " is already registered using name \"" + prefab.name.ToLower() + "\"");
            return;
        }
        prefabNameList.Add(prefab.name.ToLower());
        
        Debug.Log("Prefab " + prefabNameList.Count + " registered using name \"" + prefab.name.ToLower() + "\"");
    }

    public GameObject Spawn(string prefabName)
    {
        int prefabIndex = prefabNameList.IndexOf(prefabName.ToLower());

        if (prefabIndex == -1) 
        {
            Debug.LogError("Prefab \"" + prefabName.ToLower() + "\" not found!");
            return Instantiate(prefabObjectList[0]);
        }

        return Instantiate(prefabObjectList[prefabIndex]);
    }

    public GameObject Spawn(string prefabName, Transform targetTransform)
    {
        int prefabIndex = prefabNameList.IndexOf(prefabName.ToLower());

        if (prefabIndex == -1) 
        {
            Debug.LogError("Prefab \"" + prefabName.ToLower() + "\" not found!");
            return Instantiate(prefabObjectList[0], targetTransform);
        }
        
        return Instantiate(prefabObjectList[prefabIndex], targetTransform);
    }

    public GameObject Spawn(string prefabName, Vector3 targetPos)
    {
        int prefabIndex = prefabNameList.IndexOf(prefabName.ToLower());

        if (prefabIndex == -1) 
        {
            Debug.LogError("Prefab \"" + prefabName.ToLower() + "\" not found!");
            return Instantiate(prefabObjectList[0], targetPos, Quaternion.identity);
        }

        return Instantiate(prefabObjectList[prefabIndex], targetPos, Quaternion.identity);
    }

    public GameObject Spawn(int prefabIndex)
    {
        return Instantiate(prefabObjectList[prefabIndex]);
    }
}
