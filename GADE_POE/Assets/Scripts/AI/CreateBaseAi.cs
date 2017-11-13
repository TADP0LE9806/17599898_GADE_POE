using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreateBaseAi : AiBehaviour {

    private AiSupport support = null;

    public float Cost = 200;

    public int UnitsPerBase = 5;

    public float RangeFromUnit = 0.2f;

    public int TriesPerUnit = 3;

    public GameObject BasePrefab;

    public override float GetWeight()
    {
        if (support == null)
            support = AiSupport.GetSupport(gameObject);

        if (support.Player.Resources < Cost || support.Units.Count == 0)
            return 0;

        if (support.Buildings.Count * UnitsPerBase <= support.Units.Count)
            return 1;

        return 0;
    }

    public override void Execute()
    {
        Debug.Log("Creating Base");

        var go = GameObject.Instantiate(BasePrefab);
        go.AddComponent<Player>().Info = support.Player;

        foreach(var unit in support.Units)
        {
            for (int i = 0; i < TriesPerUnit; i++)
            {
                var pos = unit.transform.position;
                pos += UnityEngine.Random.insideUnitSphere * RangeFromUnit;
                pos.y = Terrain.activeTerrain.SampleHeight(pos); //NB
               

                go.transform.position = pos;

                if (RtsManager.Current.IsGameObjectSafeToPlace(go))
                {
                    support.Player.Resources -= Cost;
                    return;
                }
            }
        }

        Destroy(go);
    }
}
