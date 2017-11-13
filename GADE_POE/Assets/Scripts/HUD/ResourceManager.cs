using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {

    public Text CashField;

	
	// Update is called once per frame
	void Update () {
        CashField.text = "Resources: " + (int)Player.Default.Resources;
	}
}
