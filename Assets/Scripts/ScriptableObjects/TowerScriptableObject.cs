using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "ScriptableObjects/Towers/TowerScriptableObject", order = 1)]
public class TowerScriptableObject : ScriptableObject
{
    public GameObject projectilePrefab;
    public GameObject towerPrefab;
    public int damage;
    public float range;
    public float attackSpeed;

}
