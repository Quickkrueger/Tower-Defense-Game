using System;
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
    private GameObject towerModel;
    private GameObject turret;
    private List<GameObject> targets = null;
    private GameObject currentTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        damage = towerData.damage;
        attackSpeed = towerData.attackSpeed;
        range = towerData.range;

        towerModel = Instantiate(towerData.towerPrefab);
        towerModel.transform.parent = rangeCollider.transform;
        turret = towerModel.transform.GetChild(0).gameObject;

        targets = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        turret.transform.Rotate(0f, 10 * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            targets.Add(other.gameObject);
            if (currentTarget == null)
            {
                currentTarget = targets[0];
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            targets.Remove((other.gameObject));
            if (targets.Count > 0)
            {
                if (currentTarget == other.gameObject)
                {
                    currentTarget = targets[0];
                }
            }
            else
            {
                currentTarget = null;
            }
        }
    }
}
