using UnityEngine;
using System.Collections;

public class BridgeController : MonoBehaviour {

    public GameObject airField;
    GameObject bridgeStop;
	// Use this for initialization
	void Start () {
        bridgeStop = GameObject.Find("BridgeStop");
        bridgeStop.SetActive(false);
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //TODO: THERE IS A BUG GO FIX IT WHEN YOU HAVE THE TIME 
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            bridgeStop.SetActive(true);
            airField.SetActive(false);
        }

    }
}
