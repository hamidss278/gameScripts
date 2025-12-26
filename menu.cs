using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public GameObject Menu, advancee, setting, fade, PreeStart;
    void Update()
    {
        ControlFreak2.CFCursor.lockState = CursorLockMode.None;
        ControlFreak2.CFCursor.visible = true;
    }
    public void advance()
    {
        advancee.SetActive(true);
        Menu.SetActive(false);
    }
    public void back()
    {
        Menu.SetActive(true);
        advancee.SetActive(false);
        setting.SetActive(false);   
    }
    public void Settings()
    {
        setting.SetActive(true);
        Menu.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void PreStart()
    {
        Menu.SetActive(false);
        advancee.SetActive(false);
        setting.SetActive(false);
        PreeStart.SetActive(true);
    }
    public void Starter()
    {
        fade.SetActive(true);
        StartCoroutine("Load");
    }
    IEnumerator Load()
    {
        yield return new WaitForSeconds(1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

}
