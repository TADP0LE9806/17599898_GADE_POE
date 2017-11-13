using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earnings : MonoBehaviour {

    public float ResourcesPerSecond = 1;
    private PlayerSetup player;

	// Use this for initialization
	void Start () {
        player = GetComponent<Player>().Info;
	}
	
	// Update is called once per frame
	void Update () {
        player.Resources += ResourcesPerSecond * Time.deltaTime;
	}
}
