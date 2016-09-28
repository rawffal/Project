using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float jumpHeight;

    float dx;
    float dy;
    bool grounded;
    bool canJump;

    [SerializeField]
    LayerMask whatIsGround;
    [SerializeField]
    Transform groundCircle;
    [SerializeField]
    float groundRadius;
    bool ground;    

    public bool hasKey;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            dx = 1f;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            dx = -1f;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            dx = 0f;
        }

        ground = Physics2D.OverlapCircle(groundCircle.position, groundRadius, whatIsGround);
        if (Input.GetKeyDown(KeyCode.J) && ground)
        {
            canJump = true;
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(dx * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);        
        if (canJump)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            canJump = false;
        }
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Key"))
        {
            Destroy(coll.gameObject);
            hasKey = true;
        }
    }
}
