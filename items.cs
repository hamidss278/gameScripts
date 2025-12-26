using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour
{
    public bool inhand;
    public GameObject Drop;

    void Update()
    {
        if(inhand == true)
        {
            Drop.SetActive(true);
        }
        if (inhand == false)
        {
            Drop.SetActive(false);
        }
    }
}
