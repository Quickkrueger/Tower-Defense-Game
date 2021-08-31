using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrid : MonoBehaviour
{
    List<Transform> tiles;
    public Vector2 dimensions = new Vector2(100, 100);
    public GameObject tilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        tiles = new List<Transform>();
        GenerateGrid();
    }

    void GenerateGrid()
    {
        float xOffset = dimensions.x / 2;
        float yOffset = dimensions.y / 2;
        for( int x = 0; x < dimensions.x; x++)
        {
            for(int y = 0; y < dimensions.y; y++)
            {
                tiles.Add(Instantiate(tilePrefab, new Vector3(x - xOffset + 0.5f, 0f,  y - yOffset + 0.5f), Quaternion.identity, transform).transform);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
