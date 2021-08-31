using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    Transform currentTower;
    public GameObject towerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (currentTower == null)
        {
            GameObject newTower = Instantiate(towerPrefab);
            currentTower = newTower.GetComponent<Tower>().InitializeTower(transform);
            currentTower.parent = transform;
            currentTower.localPosition = Vector3.zero;
        }

    }
}
