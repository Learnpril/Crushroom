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
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(followingTarget)
        {
            targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);

            //moves target ahead of player
            Debug.Log(target.transform.localScale.x);

            if (target.transform.localScale.x > 0f)
            {
                targetPosition = new Vector3(targetPosition.x + cameraOffset, targetPosition.y, targetPosition.z);
            }
            else
            {
                targetPosition = new Vector3(targetPosition.x - cameraOffset, targetPosition.y, targetPosition.z);
            }

            //transform.position = targetPosition;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothForCamera * Time.deltaTime);
        }
    }
}
