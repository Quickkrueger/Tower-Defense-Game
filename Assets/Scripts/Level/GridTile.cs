using UnityEngine;
using UnityEngine.EventSystems;

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
        EventSystem eventSystem = EventSystem.current;
        if (eventSystem != null && eventSystem.IsPointerOverGameObject())
        {
            return;
        }

        if (currentTower == null)
        {
            GameObject newTower = Instantiate(towerPrefab);
            Tower newTowerScript = newTower.GetComponent<Tower>();
            currentTower = newTower.GetComponent<Tower>().InitializeTower(transform);
            currentTower.parent = transform;
            currentTower.localPosition = Vector3.zero;
        }

    }
}
