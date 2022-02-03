using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterBehavior : MonoBehaviour
{
    public Vector3 SpeedUp;
    [ReadOnly]
    public Vector3 SpeedForward;
    [ReadOnly]
    public float Height;

    public Vector3 GetVector3SpeedUp()
    {
        return SpeedUp;
    }
    public Vector3 GetVector3SpeedForward()
    {
        return SpeedForward;
    }
    public void SetVector3SpeedForward(Vector3 speedForward)
    {
        SpeedForward = speedForward;
    }
}
