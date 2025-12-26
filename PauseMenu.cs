using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{


    public GameObject Pause;

    void Update()
    {
        if(ControlFreak2.CF2Input.GetKeyDown(KeyCode.Escape))
        {
            Pause.SetActive(true);
            ControlFreak2.CFCursor.visible = true;
            ControlFreak2.CFCursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }

    }
    public void Resume()
    {
        Pause.SetActive(false);
        ControlFreak2.CFCursor.visible = false;
        ControlFreak2.CFCursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
    public void quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
