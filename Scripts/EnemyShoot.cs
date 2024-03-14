using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    private Transform playerTarget;

    private float PirateTimer;

    public float PShootTime;

    private Transform BallSpawn;

    public GameObject CannonballPrefab;

    public float BallForce;

    [SerializeField] private AudioSource cannonAudio;

    // Start is called before the first frame update
    void Start()
    {

        //where the ball come from
        BallSpawn = transform.GetChild(0);

        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {

        PirateTimer += Time.deltaTime;

        if (PirateTimer >= PShootTime)
        {

            PirateTimer = 0;

           float Angle = Vector2.Angle(
               -transform.up,
               new Vector2(
                     playerTarget.position.x - transform.position.x, 
                     playerTarget.position.z - transform.position.z
               ).normalized
           );

            if (Angle > -30 && Angle < 30)
            {

                Shoot();

                cannonAudio.time = 0.3f;

                cannonAudio.Play();

            }

        }

    }

    void Shoot()

    {
        GameObject Cannonball = Instantiate(CannonballPrefab, BallSpawn.position, Quaternion.identity);

        Physics.IgnoreCollision(Cannonball.GetComponent<Collider>(), GetComponent<Collider>());

        Cannonball.GetComponent<Rigidbody>().AddForce(-transform.up * BallForce);

    }
}
