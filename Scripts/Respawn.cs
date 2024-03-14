using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public GameObject playerRespawnPoint;
    public GameObject player;
    private bool oceanTouch;


    void FixedUpdate()
    {
        if (oceanTouch == true)
        {
            player.transform.position = playerRespawnPoint.transform.position;
            oceanTouch = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            oceanTouch = true;
        }
    }
}
