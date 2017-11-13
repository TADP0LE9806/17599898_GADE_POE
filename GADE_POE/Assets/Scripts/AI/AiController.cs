using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour {


    public string PlayerName;
    public float Confusion = 0.3f;
    public float Frequency = 1;

    private PlayerSetup player;
    private float waited = 0;
    private List<AiBehaviour> Ais = new List<AiBehaviour>();

    public PlayerSetup Player { get { return player; } }

	// Use this for initialization
	void Start () {
        foreach (var ai in GetComponents<AiBehaviour>())
            Ais.Add(ai);

        foreach(var p in RtsManager.Current.Players)
        {
            if (p.Name == PlayerName) player = p;
        }
        gameObject.AddComponent<AiSupport>().Player = player;
	}
	
	// Update is called once per frame
	void Update () {
        waited += Time.deltaTime;
        if (waited < Frequency)
            return;

        string ailog = "";
        float bestAiValue = float.MinValue;
        AiBehaviour bestAi = null;
        AiSupport.GetSupport(gameObject).Refresh();
        foreach(var ai in Ais)
        {
            ai.TimePassed += waited;
            var aiValue = ai.GetWeight() * ai.WeightMultiplier + Random.Range(0, Confusion);
            ailog += ai.GetType().Name + ": " + aiValue + "\n";
            if (aiValue > bestAiValue)
            {
                bestAiValue = aiValue;
                bestAi = ai;
            }
        }

        Debug.Log(ailog);
        bestAi.Execute();
        waited = 0;
	}
}
