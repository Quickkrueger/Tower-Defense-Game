using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntData", menuName = "ScriptableObjects/DataStorage/IntData", order = 1)]
public class IntData : ScriptableObject
{
    public float value;

    public void ChangeValue(int num)
    {
        value += num;
    }



    public void SetValue(int num)
    {
        value = num;
    }
}
