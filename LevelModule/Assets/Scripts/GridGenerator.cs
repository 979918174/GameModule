using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    int width = 5;
    int height = 5;

    public gridElement gridElement;
    public gridElement[] gridElements;
    // Start is called before the first frame update
    void Start()
    {
        gridElements = new gridElement[width * height];
        for (int y = 0; y < width; y++)
        {
            for (int x = 0; x < height; x++)
            {
                gridElement gridElementInstance = Instantiate(gridElement, new Vector3(x, y, 0), Quaternion.identity,this.transform);
                gridElementInstance.name = "GridElement_" + x + "_" + y;
                gridElements[x + width * y] = gridElementInstance;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
