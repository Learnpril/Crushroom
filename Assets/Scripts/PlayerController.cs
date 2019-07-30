using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public Transform checkForGround;
    public LayerMask whatIsGround;

    public bool isOnGround;

    public float checkForGroundRadius;
    public float movementSpeed;
    public float jumpSpeed;

    private Rigidbody2D myRigidBody;


    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(checkForGround.position, checkForGroundRadius, whatIsGround);

        if(Input.GetAxisRaw("Horizontal") > 0f)
        {
            myRigidBody.velocity = new Vector3(movementSpeed, myRigidBody.velocity.y, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myRigidBody.velocity = new Vector3(-movementSpeed, myRigidBody.velocity.y, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector3(0f, myRigidBody.velocity.y, 0f);
        }

        if (Input.GetButtonDown("Jump") && isOnGround == true)
        {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpSpeed, 0f);
        }
    }
}
