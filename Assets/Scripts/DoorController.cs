using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{

    bool hasKey;
    bool canExit;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && hasKey && canExit) Destroy(this.gameObject);
        if (canExit)
        {
            GetComponent<MeshRenderer>().materials[0].color = new Color(0, 255, 0, 0);
        }
        else
        {
            GetComponent<MeshRenderer>().materials[0].color = new Color(255, 0, 0, 0);
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        hasKey = coll.gameObject.GetComponent<PlayerController>().hasKey;
        if (hasKey) canExit = true;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (hasKey) canExit = !canExit;
    }
}
