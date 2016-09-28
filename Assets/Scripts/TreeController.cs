using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour {

    bool rotate;
	// Use this for initialization
	void Start () {
        rotate = false;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            rotate = true;
        }
    }
}
