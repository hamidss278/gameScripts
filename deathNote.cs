using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class deathNote : MonoBehaviour
{
    public TMP_InputField i;
    GameObject obj;


    void Update()
    {
        obj = GameObject.Find(i.text);
        Destroy(obj, 3);
    }
}
