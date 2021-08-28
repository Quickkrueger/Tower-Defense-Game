using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    int damage;
    float range;
    float attackSpeed;
    public TowerScriptableObject towerData;
    public GameObject rangeCollider;
    GameObject towerModel;
    GameObject turret;

    // Start is called before the first frame update
    void Start()
    {
        damage = towerData.damage;
        attackSpeed = towerData.attackSpeed;
        range = towerData.range;

        towerModel = Instantiate(towerData.towerPrefab);
        towerModel.transform.parent = rangeCollider.transform;
        turret = towerModel.transform.GetChild(0).gameObject;

        
    }

    // Update is called once per frame
    void Update()
    {
        turret.transform.Rotate(0f, 10 * Time.deltaTime, 0f);
    }
}
