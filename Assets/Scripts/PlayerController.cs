using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public Transform checkForGround;
    public LayerMask whatIsGround;

    public bool isOnGround;
    public Vector3 respawnPosition;

    public float checkForGroundRadius;
    public float movementSpeed;
    public float jumpSpeed;

    public LevelManager theLevelManager;

    private Rigidbody2D myRigidBody;


    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        respawnPosition = transform.position;
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SavePoint")
        {
            respawnPosition = other.transform.position;
        }

        if (other.tag == "KillPlane")
        {
            //gameObject.SetActive(false);
            //transform.position = respawnPosition;
            theLevelManager.Respawn();
        }
    }
}
