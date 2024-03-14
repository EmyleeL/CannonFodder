using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {

            bool ShouldDestroy = other.GetComponentInChildren<CannonMechanics>().AddAmmo(Random.Range(1, 8));

            if (ShouldDestroy)
            {

                Destroy(gameObject);

            }

        }

    }
}
