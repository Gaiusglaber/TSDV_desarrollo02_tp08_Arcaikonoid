using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    private const float initheight = 18;
    private const float initwidth = -2;

    private const float blockz = 0;
    
    private const float heightgap = 0.3f;
    private const float widthgap = 0.3f;

    private const float scaleheight = 1;
    private const float scalewidth = 3;

    private const float widthmax = -29;
    private const float heightmax = 13;
    public Material[] materials;
    public GameObject block;
    void Start()
    {
        for (float height = initheight; height > heightmax; height-=(scaleheight+heightgap))
        {
            for (float width = initwidth; width > widthmax; width -= (scalewidth+widthgap))
            {
                GameObject instanceblock = Instantiate(block, new Vector3(width, height, blockz), Quaternion.identity);
                instanceblock.GetComponent<MeshRenderer>().material = materials[Random.Range(0, 4)];
            }
        }
    }
}
