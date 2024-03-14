using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MoveToLevel : MonoBehaviour
{
    private bool nearBoat;
    public string levelName;
    public GameObject activator;


    protected virtual void Start()
    {
        activator.SetActive(false);
    }

    protected virtual void Update()
    {
        if (nearBoat && Input.GetKey(KeyCode.E) && GetCondition())
        {
            SceneManager.LoadScene(levelName);
        }

        if (nearBoat)
        {
            activator.SetActive(true);
        }
        else
        {
            activator.SetActive(false);
        }
    }

    protected abstract bool GetCondition();

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            nearBoat = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            nearBoat = false;
        }
    }


    public void MenuSwitch()
    {
        SceneManager.LoadScene(levelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
