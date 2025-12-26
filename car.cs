using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    public float motorforce;
    public float brakeforce;
    public float maxSteer;
    public AudioSource so;

    public WheelCollider fr, fl, rr, rl;
    public Transform FR, FL, RR, RL, far, camPos;
    public float horizontal;
    public float vertical;
    public float currentSteer;
    float currentbrake;
    public bool isBrake;
    public Vector3 vecc;

    void Update()
    {
        vecc = camPos.transform.eulerAngles;
        GetInput();
        HandleMotor();
        Steer();
        allw(); 
        if(vertical >0 || vertical <0)
        {
            so.enabled = true;
        }
        else
        {
            so.enabled = false;
        }
        
    }
    void GetInput()
    {
        horizontal = ControlFreak2.CF2Input.GetAxis("Horizontal");
        vertical = ControlFreak2.CF2Input.GetAxis("Vertical");
        isBrake = ControlFreak2.CF2Input.GetKeyDown(KeyCode.Space);
    }
    void HandleMotor()
    {
        fr.motorTorque = vertical * motorforce;
        fl.motorTorque = vertical * motorforce;
            
        


        currentbrake = isBrake? brakeforce : 0f;
        ApplyBrake();
    }

    void ApplyBrake()
    {
        rr.brakeTorque = currentbrake;
        rl.brakeTorque = currentbrake;
        fr.brakeTorque = currentbrake;
        fl.brakeTorque = currentbrake;
    }
    void Steer()
    {
        float X = vecc.x;
        float Y = vecc.y;
        currentSteer = maxSteer * horizontal;
        fr.steerAngle = currentSteer;
        fl.steerAngle = currentSteer;
        far.transform.rotation = Quaternion.Euler(X,Y,- horizontal * 30f);
    }
    void SingleWheel(WheelCollider col, Transform wheel)
    {
        Vector3 pos;
        Quaternion rot;
        col.GetWorldPose(out pos, out rot);
        wheel.position = pos;
        wheel.rotation = rot;
             
    }
    void allw()
    {
        SingleWheel(fr, FR);
        SingleWheel(fl, FL);
        SingleWheel(rr, RR);
        SingleWheel(rl, RL);
    }
}
