using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDronesAi : AiBehaviour {

    public int UnitsPerBase = 5;
    public float Cost = 25;
    private AiSupport support;

    public override float GetWeight()
    {
        if (support == null)
            support = AiSupport.GetSupport(gameObject);

        if (support.Player.Resources < Cost)
            return 0;

        var units = support.Units.Count;
        var bases = support.Buildings.Count;

        if (bases == 0)
            return 0;

        if (units >= bases * UnitsPerBase) return 0;

        return 1;
    }

    public override void Execute()
    {
        Debug.Log(support.Player.Name + " is creating a unit");

        var bases = support.Buildings;
        var index = UnityEngine.Random.Range(0, bases.Count);
        var building = bases[index];
        building.GetComponent<CreateUnitAction>().GetClickAction()();
    }
}
