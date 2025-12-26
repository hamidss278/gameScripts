using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endui : MonoBehaviour
{
    void Start()
    {
        ControlFreak2.CFCursor.lockState = CursorLockMode.None;
        ControlFreak2.CFCursor.visible = true;
    }
    public void exit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
