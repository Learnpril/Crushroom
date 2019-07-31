using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public bool followingTarget;

    public float cameraOffset;
    public float smoothForCamera;
    public GameObject target;

    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {// 8====D~~~~~~~~~~~SPLASH 0___0;
        //<3
    }

    void Update()
    {
        // gather data.

        // use data.

        if(followingTarget)
        {
            targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);

            //moves target ahead of player
            //Debug.Log(target.transform.localScale.x);
            // moving left/right
            // i think this might work...
            float left = Input.GetKey("a") ? -cameraOffset : 0;
            float right = Input.GetKey("d") ? cameraOffset : 0;

            targetPosition = new Vector3(targetPosition.x + left + right, targetPosition.y, targetPosition.z);
            //if (target.transform.localScale.x > 0f)
            //{
            //}
            //else
            //{
            //    targetPosition = new Vector3(targetPosition.x + , targetPosition.y, targetPosition.z);
            //}

            //transform.position = targetPosition;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothForCamera * Time.deltaTime);
        }
    }
}
