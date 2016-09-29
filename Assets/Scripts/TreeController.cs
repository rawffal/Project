using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour {

    bool inTrigger;
    bool hasKey;
    bool triggered;
    bool stopRotating;
    Vector3 currentAngle;
	// Use this for initialization
	void Start () {
        inTrigger = false;
        triggered = true;
        stopRotating = false;
        currentAngle = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        //if (hasKey && inTrigger)
        if (inTrigger && Input.GetKeyDown(KeyCode.K))
        {
            triggered = false;
        }
        if (transform.rotation.z < -10f)
        {
            stopRotating = true;

        }
        if (inTrigger)
        {
            GetComponent<MeshRenderer>().materials[0].color = new Color(0, 255, 0, 0);
        }
        else
        {
            GetComponent<MeshRenderer>().materials[0].color = new Color(255, 0, 0, 0);
        }
	}

    void FixedUpdate()
    {        
        if (!triggered && !stopRotating)
        {
            currentAngle.z = Mathf.LerpAngle(currentAngle.z, -10f, Time.deltaTime);
            transform.eulerAngles = currentAngle;
            Debug.Log(stopRotating);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //if (GameObject.Find("Player").GetComponent<PlayerController>().hasKey)
        if (col.gameObject.CompareTag("Player"))
            inTrigger = true;
    }
    
    void OnTriggerExit2D(Collider2D col)
    {
        inTrigger = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {

    }
}
