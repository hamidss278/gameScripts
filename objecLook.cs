using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objecLook : MonoBehaviour
{
    public Transform Tile, Fps;

    void Update()
    {
        Tile.transform.LookAt(Fps.position);
    }
}
