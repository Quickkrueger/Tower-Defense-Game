using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatData", menuName = "ScriptableObjects/Test/FloatData", order = 1)]
public class FloatData : ScriptableObject
{
    public float value;

    public void AddToValue(float num)
    {
        value += num;
    }
}
