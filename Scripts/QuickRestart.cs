using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuickRestart : MonoBehaviour
{
   
    void Update()
    {

        //quick restart to menu
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene("MainMenu");
            Cursor.visible = true;

            Cursor.lockState = CursorLockMode.None;
        }

        //Quit game
        if (Input.GetKey(KeyCode.O))
        {
            Application.Quit();
        }
    }
}
