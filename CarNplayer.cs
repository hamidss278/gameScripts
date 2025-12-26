using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarNplayer : MonoBehaviour
{
    public Transform fps, part;
    public Vector3 rotate ;

    void Update()
    {
        rotate = fps.transform.eulerAngles;
        part.transform.position = fps.position;
        part.transform.eulerAngles = (rotate);
    }
}