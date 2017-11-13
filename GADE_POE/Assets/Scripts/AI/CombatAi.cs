using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAi : AiBehaviour {

    public int UnitsRequired = 10;

    public float TimeDelay = 5;

    public float SquadSize = 0.5f;

    public int IncreasePerWave = 10;

    public override void Execute()
    {
        var ai = AiSupport.GetSupport(this.gameObject);
        Debug.Log(ai.Player.Name + " is attacking");

        int wave = (int)(ai.Units.Count * SquadSize);
        UnitsRequired += IncreasePerWave;

        foreach(var p in RtsManager.Current.Players)
        {
            if (p.IsAi)
                continue;

            for (int i = 0; i < wave; i++)
            {
                var unit = ai.Units[i];
                var nav = unit.GetComponent<RightClickNavigation>();
                nav.SendToTarget(p.Location.position);
            }
            return;
        }
    }

    public override float GetWeight()
    {
        if (TimePassed < TimeDelay)
            return 0;
        TimePassed = 0;

        var ai = AiSupport.GetSupport(this.gameObject);
        if (ai.Units.Count < UnitsRequired)
            return 0;

        return 1;
    }
}
