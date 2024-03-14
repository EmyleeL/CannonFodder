using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonMechanics : MonoBehaviour
{

    private Transform BallSpawn;

    public GameObject CannonballPrefab;

    public float BallForce;

    public float FireTime;

    private float Timer;

    public int MaxAmmo;

    private int CurrentAmmo;

    public Text AmmoText;

    [SerializeField] private AudioSource cannonAudio;


    // Start is called before the first frame update
    void Start()
    {
        //where the ball come from
        BallSpawn = transform.GetChild(0);

        CurrentAmmo = MaxAmmo;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Timer += Time.deltaTime;

        // player shoot
        if (Input.GetButton("Fire1") && Timer >= FireTime && CurrentAmmo >= 1)
        {

            Shoot();
            Timer = 0;
            CurrentAmmo--;
            cannonAudio.time = 0.3f;
            cannonAudio.Play();

        }

        AmmoText.text = CurrentAmmo + "/" + MaxAmmo;
        
    }
    // Code to shoot ball
    void Shoot()

    {
        GameObject Cannonball = Instantiate(CannonballPrefab, BallSpawn.position, Quaternion.identity);

        Physics.IgnoreCollision(Cannonball.GetComponent<Collider>(), GetComponent<Collider>());

        Cannonball.GetComponent<Rigidbody>().AddForce(-transform.up * BallForce);

    }

    public bool AddAmmo(int AmmoCount)
    {

        if (CurrentAmmo <= MaxAmmo)
        {

            CurrentAmmo += AmmoCount;

            if (CurrentAmmo >= MaxAmmo)
            {

                CurrentAmmo = MaxAmmo;

            }

            return true;

        }

        return false;

    }

}
