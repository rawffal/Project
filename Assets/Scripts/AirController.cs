using UnityEngine;
using System.Collections;

public class AirController : MonoBehaviour {

    public GameObject player;

    public GameObject airField;
    public GameObject bridgeVent;
    Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {        
        rb2d = player.GetComponent<Rigidbody2D>();

        airField = this.transform.FindChild("AirField").gameObject;
        airField.SetActive(false);
        bridgeVent = GameObject.Find("Bridge");
        bridgeVent.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            airField.SetActive(true);
            bridgeVent.SetActive(true);
        }
    }
}
