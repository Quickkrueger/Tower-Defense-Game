using UnityEngine;

[CreateAssetMenu(fileName = "FloatData", menuName = "ScriptableObjects/DataStorage/FloatData", order = 1)]
public class FloatData : ScriptableObject
{
    public float value;

    public void AddToValue(float num)
    {
        value += num;
    }

    public void ResetValue(float num)
    {
        value = num;
    }
}
