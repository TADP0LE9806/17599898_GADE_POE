using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSupport : MonoBehaviour {

    public List<GameObject> Units = new List<GameObject>();
    public List<GameObject> Buildings = new List<GameObject>();

    public PlayerSetup Player = null;

    public static AiSupport GetSupport (GameObject go)
    {
        return go.GetComponent<AiSupport>();
    }

    public void Refresh()
    {
        Units.Clear();
        Buildings.Clear();
        foreach(var u in Player.ActiveUnits)
        {
            if (u.name.Contains("Unit")) Units.Add(u);
            if (u.name.Contains("Factory")) Buildings.Add(u);
        }
    }
}
