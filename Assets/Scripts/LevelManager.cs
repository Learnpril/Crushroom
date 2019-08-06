using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float waitToRespawn;
    public PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Respawn()
    {
        //RespawnCo();
        StartCoroutine(RespawnCo());
    }
    public IEnumerator RespawnCo()
    {
        thePlayer.gameObject.SetActive(false);
        thePlayer.transform.position = thePlayer.respawnPosition;
        yield return new WaitForSeconds(1f);
        thePlayer.gameObject.SetActive(true);
    }
}
