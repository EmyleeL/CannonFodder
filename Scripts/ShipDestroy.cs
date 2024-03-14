using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDestroy : MonoBehaviour
{
    private float ShipHitCounter;

    public float ShipHP;

    // Start is called before the first frame update
    void Start()
    {
        // set ship hit count to zero
        ShipHitCounter = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // detects when ball hits ship
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CannonBall") 
        {
            // hit count up and destroy ball on hit
            ShipHitCounter++;

            Destroy(collision.gameObject);

            // ship stops moving, wreck animation called, ship destroyed when hits = hp
            if (ShipHitCounter == ShipHP)
            {
                GetComponent<ShipPathing>().enabled = false;

                GetComponent<Animator>().enabled = true;

                Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);

            }

        }
        
    }
}
