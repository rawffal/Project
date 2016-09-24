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
        dx = Input.GetAxis("Horizontal");
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
