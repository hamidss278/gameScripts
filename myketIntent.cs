using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myketIntent : MonoBehaviour
{
    public string link;
    public void CLICK()
    {
        Application.OpenURL  (link);
    }
}
