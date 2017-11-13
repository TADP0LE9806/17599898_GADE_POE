using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public PlayerSetup Info;

    public static PlayerSetup Default;

    void Start()
    {
        Info.ActiveUnits.Add(this.gameObject);
    }

    void OnDestroy()
    {
        Info.ActiveUnits.Remove(this.gameObject);
    }
}
