﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnNoHealth : MonoBehaviour {

    private ShowUnitInfo info;

	// Use this for initialization
	void Start () {
        info = GetComponent<ShowUnitInfo>();
	}
	
	// Update is called once per frame
	void Update () {
		if (info.CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
