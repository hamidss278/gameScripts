using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouching : MonoBehaviour
{
    public CharacterController csh;
    public SC_FPSController sc;
    public bool toggle;

    void Update()
    {
        if(ControlFreak2.CF2Input.GetKeyDown(KeyCode.C))
        {
          toggle = !toggle;
          if (toggle == true)
          {
              csh.height = 0;
              sc.walkingSpeed = 1f;
              sc.runningSpeed = 1f;
          }
            if(toggle == false)
            {
                csh.height = 2;
                sc.walkingSpeed = 2.5f;
                sc.runningSpeed = 2.5f;
            }
        }
    }
}
