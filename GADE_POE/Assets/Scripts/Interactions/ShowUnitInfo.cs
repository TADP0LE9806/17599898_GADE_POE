using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUnitInfo : Interaction {

    public string Name;
    public float MaxHealth, CurrentHealth;

    bool show = false;

    public override void Select()
    {
        show = true;
    }

    void Update()
    {
        if (!show)
            return;
        InfoManager.Current.SetLines(
          Name,
          CurrentHealth + "/" + MaxHealth,
          "Owner:" + GetComponent<Player>().Info.Name);


    }

    public override void Deselect()
    {
        InfoManager.Current.ClearLines();
        show = false;
    }
}
