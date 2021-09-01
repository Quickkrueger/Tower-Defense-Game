using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private int damage;
    private float range;
    private float attackSpeed;

    private TowerScriptableObject towerData;

    public ScriptObjList towersAvailable;
    public GameObject rangeCollider;

    private GameObject towerModel;
    private List<GameObject> targets = null;
    private GameObject currentTarget = null;
    private bool canFire = true;
    private float recharging = 0;
    private Transform projectileSpawn;
    private const float rotateSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public Transform InitializeTower(Transform tile)
    {

        towerData = (TowerScriptableObject)towersAvailable.objectList[towersAvailable.Index];

        damage = towerData.damage;
        attackSpeed = 10f / towerData.attackSpeed;
        range = towerData.range;

        towerModel = Instantiate(towerData.towerPrefab);
        towerModel.transform.parent = rangeCollider.transform;

        towerModel.transform.localPosition = Vector3.zero;

        projectileSpawn = transform.GetChild(1);

        targets = new List<GameObject>();

        return gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget == null)
        {
            towerModel.transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
        }
        else
        {
            TrackTarget();
            
            if (canFire)
            {
                FireAtTarget();
                canFire = false;
            }
        }
        
        if (recharging > attackSpeed && !canFire)
        {
            canFire = true;
            recharging = 0;
        }
        else if(!canFire)
        {
            recharging += Time.deltaTime;
        }
    }

    void TrackTarget()
    {
        towerModel.transform.LookAt(new Vector3(currentTarget.transform.position.x, towerModel.transform.position.y, currentTarget.transform.position.z));
    }

    void FireAtTarget()
    {
        Instantiate(towerData.projectilePrefab, projectileSpawn.position, towerModel.transform.rotation);
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
