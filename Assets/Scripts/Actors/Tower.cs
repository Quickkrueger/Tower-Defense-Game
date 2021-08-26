using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    int damage;
    float range;
    float attackSpeed;
    public TowerScriptableObject towerData;

    // Start is called before the first frame update
    void Start()
    {
        damage = towerData.damage;
        attackSpeed = towerData.attackSpeed;
        range = towerData.range;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
