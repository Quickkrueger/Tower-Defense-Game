using UnityEngine;

[CreateAssetMenu(fileName = "ScriptObjectList", menuName = "ScriptableObjects/Test/ScriptObjectList", order = 1)]
public class ScriptObjList : ScriptableObject
{
    public ScriptableObject[] objectList;
    private int currentObjectIndex = 0;
    public int Index
    {
        get { return currentObjectIndex; }
    }

    public void SetCurrentObject(int index)
    {
        currentObjectIndex = index;
    }
}
