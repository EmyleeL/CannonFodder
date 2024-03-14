using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadNote : MonoBehaviour
{

    private bool near;

    public GameObject readUI;
    public GameObject noteUI;

    public Text noteText;
    public string noteTextString;


    [SerializeField] private MouseyLook freezeMouse;
    [SerializeField] private PlayerController freezePlayer;


    private void Start()
    {
        noteText.text = noteTextString;
        readUI.SetActive(false);
    }

    void Update()
    {
        if (near)
        {
            readUI.SetActive(true);
        }
        else
        {
            readUI.SetActive(false);
        }

        if(near && Input.GetKeyDown(KeyCode.E))
        {
            noteUI.SetActive(true);
            freezePlayer.playerSpeed = 0;
            freezeMouse.MouseSpeed = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            noteUI.SetActive(false);
            freezePlayer.playerSpeed = 10;
            freezeMouse.MouseSpeed = 5;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            near = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            near = false;
        }
    }
}
