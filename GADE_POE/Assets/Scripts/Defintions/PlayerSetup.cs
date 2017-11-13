using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSetup  {

    public string Name;
    public Transform Location;
    public Color TeamColour;
    public List<GameObject> StartUnits = new List<GameObject>();
    private List<GameObject> activeUnits = new List<GameObject>();
    public List<GameObject> ActiveUnits { get { return activeUnits; } }
    public bool IsAi;
    public float Resources;

    
}
