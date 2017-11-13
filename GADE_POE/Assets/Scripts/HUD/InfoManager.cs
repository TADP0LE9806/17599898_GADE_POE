using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour {

    public static InfoManager Current;

    public Text Line1, Line2, Line3;

    public InfoManager()
    {
        Current = this;
    }

    public void SetLines(string line1, string line2, string line3)
    {
        Line1.text = line1;
        Line2.text = line2;
        Line3.text = line3;
    }

    public void ClearLines()
    {
        SetLines("", "", "");
    }


	// Use this for initialization
	void Start () {
        ClearLines();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
