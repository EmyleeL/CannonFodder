using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballDespawn : MonoBehaviour
{

    public float DespawnTime;

    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
       
        

    }

    // Update is called once per frame
    void Update()
    {

        Timer += Time.deltaTime;
        //ball despawn like the name of the code
        if (Timer > DespawnTime)
        {

            Destroy(gameObject);

        }
        
    }
}
