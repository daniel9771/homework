using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoardManager : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject tilePrefab;
    BackgroundTile[,] Tiles;
    

    // Start is called before the first frame update
    void Start()
    {
        Tiles = new BackgroundTile[width, height];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetBoard()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {

            }
        }
    }
}
