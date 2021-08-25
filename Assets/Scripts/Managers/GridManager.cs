using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Dimensions gridDimensions;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public struct Dimensions
{
    [SerializeField][Range(20f, 100f)]
    int HorizantalTiles;
    [SerializeField][Range(50f, 250f)]
    int VerticalTiles;
}
