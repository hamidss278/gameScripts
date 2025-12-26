using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTire : MonoBehaviour
{
    public bool a1, a2, a3, a4, a5;
    public bool done;
    public tires sc, cs, cc, dd;

    void Update()
    {
        if (sc.att == true)
        {
            a1 = true;
        }
        if (cs.att == true)
        {
            a2 = true;

            if (cc.att == true)
            {
                a3 = true;

                if (dd.att == true)
                {
                    a4 = true;
                }
            }
        }

        if (a1)
        {
            if (a2)
            {
                if (a3)
                {
                    if (a4)
                    {
                        if (a5)
                        {
                            done = true;
                        }
                    }
                }
            }
        }
    }
}
