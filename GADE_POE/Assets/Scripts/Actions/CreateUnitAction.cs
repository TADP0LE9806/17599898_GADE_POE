using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUnitAction : ActionBehavior {

    public GameObject Prefab;
    public float Cost = 0;
    private PlayerSetup player;

	// Use this for initialization
	void Start () {
        player = GetComponent<Player>().Info;
	}

    public override Action GetClickAction()
    {
        return delegate ()
        {

            if (player.Resources < Cost)
            {
                Debug.Log("Cannot create, it costs " + Cost);
                return;
            }

            var go = (GameObject)GameObject.Instantiate(
                Prefab,
                transform.position,
                Quaternion.identity);
            go.AddComponent<Player>().Info = player;
            go.AddComponent<RightClickNavigation>();
            go.AddComponent<ActionSelect>();
            player.Resources -= Cost;

        };




    }
}
