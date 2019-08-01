using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavepointScript : MonoBehaviour
{
    public Sprite orbOn;
    public Sprite orbOff;
    public bool savepointOn;

    private SpriteRenderer spriteRender;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            savepointOn = true;
            spriteRender.sprite = orbOff;
        }
    }
}
