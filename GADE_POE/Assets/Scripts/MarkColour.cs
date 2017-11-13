using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkColour : MonoBehaviour {

    public MeshRenderer[] Renderers;
    
    // Use this for initialization
	void Start () {
        var color = GetComponent<Player>().Info.TeamColour;
        foreach(var r in Renderers)
        {
            r.material.color = color;
        }
	}
	

}
