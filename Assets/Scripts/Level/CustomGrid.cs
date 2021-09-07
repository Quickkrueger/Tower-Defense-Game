using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrid : MonoBehaviour
{
    List<GridTile> tiles;
    public Vector2 dimensions = new Vector2(100, 100);
    public GameObject tilePrefab;
    private int pathLength;
    List<GridTile> path;
    // Start is called before the first frame update
    void Start()
    {
        tiles = new List<GridTile>();
        path = new List<GridTile>();
        pathLength = (int)(dimensions.x * dimensions.y * 0.5f);
        GenerateGrid();
        GeneratePath();
    }

    void GenerateGrid()
    {
        float xOffset = Mathf.Round(dimensions.x / 2);
        float yOffset = Mathf.Round(dimensions.y / 2);
        for( int x = 0; x < dimensions.x; x++)
        {
            for(int y = 0; y < dimensions.y; y++)
            {
                tiles.Add(Instantiate(tilePrefab, new Vector3(x - xOffset + 0.5f, 0f,  y - yOffset + 0.5f), Quaternion.identity, transform).GetComponent<GridTile>());
            }
        }

    }

    void GeneratePath()
    {
        StartCoroutine(GeneratePathAsync());
    }

    IEnumerator GeneratePathAsync()
    {
        WalkThePath(0, 1);
        yield return null;
    }

    bool WalkThePath(int currentTileIndex, int currentPathLength)
    {

        if (tiles[currentTileIndex].IsPath)
        {
            return false;
        }

        List<int> validTiles = GetAdjacentPaths(currentTileIndex);
        if(validTiles.Count < 2)
        {
            return false;
        }
        else if (validTiles.Count < 3 && currentTileIndex % dimensions.y != 0 && currentTileIndex % dimensions.y != tiles.Count - 1 && currentTileIndex > dimensions.y - 1 && currentTileIndex <tiles.Count - dimensions.y)
        {
            return false;
        }

        tiles[currentTileIndex].IsPath = true;

        if (currentPathLength == pathLength)
        {            
            return true;
        }

        

        while (validTiles.Count > 0)
        {
            int rand = Random.Range(0, validTiles.Count);

            if (WalkThePath(validTiles[rand], currentPathLength + 1))
            {
                return true;
            }
            else
            {
                validTiles.RemoveAt(rand);
            }
        }

        tiles[currentTileIndex].IsPath = false;

        return false;
    }

    List<int> GetAdjacentPaths(int currentTileIndex)
    {
        List<int> validTiles = new List<int>();

        if(currentTileIndex + (int)dimensions.y < tiles.Count && !tiles[currentTileIndex + (int)dimensions.y].IsPath)
        {
            validTiles.Add(currentTileIndex + (int)dimensions.y);
        }

        if(currentTileIndex - (int)dimensions.y >= 0 && !tiles[currentTileIndex - (int)dimensions.y].IsPath)
        {
            validTiles.Add(currentTileIndex - (int)dimensions.y);
        }

        if((currentTileIndex + 1) % (int)dimensions.y > 0 && currentTileIndex < tiles.Count - 1 && !tiles[currentTileIndex + 1].IsPath)
        {
            validTiles.Add(currentTileIndex + 1);
        }

        if((currentTileIndex - 1) % (int)dimensions.y < (int)dimensions.y - 1 && currentTileIndex > 0 && !tiles[currentTileIndex - 1].IsPath)
        {
            validTiles.Add(currentTileIndex - 1);
        }

        return validTiles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
