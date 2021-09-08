using UnityEngine;
using UnityEngine.EventSystems;

public class GridTile : MonoBehaviour
{
    Transform currentTower;
    bool isPath;
    public GameObject towerPrefab;
    public IntData wallet;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsPath
    {
        get { return isPath; }
        set { 
            isPath = value;
            if (isPath)
            {
                GetComponent<MeshRenderer>().material.color = Color.black;
            }
            else
            {
                GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
    }

    private void OnMouseDown()
    {
        EventSystem eventSystem = EventSystem.current;
        if (eventSystem != null && eventSystem.IsPointerOverGameObject())
        {
            return;
        }

        if (currentTower == null && !isPath)
        {
            GameObject newTower = Instantiate(towerPrefab);
            Tower newTowerScript = newTower.GetComponent<Tower>();
            if (wallet.value >= ((TowerScriptableObject)newTowerScript.towersAvailable.GetCurrentItem()).cost)
            {
                wallet.ChangeValue(-1 * ((TowerScriptableObject)newTowerScript.towersAvailable.GetCurrentItem()).cost);
                currentTower = newTowerScript.InitializeTower(transform);
                currentTower.parent = transform;
                currentTower.localPosition = Vector3.zero;
            }
            else
            {
                Destroy(newTower);
            }
        }

    }
}
