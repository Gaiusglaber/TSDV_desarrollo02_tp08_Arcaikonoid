using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    private const float blockz = 0;
    private const float heightgap = 0.5f;
    private const float widthgap = 0.5f;
    private const float heightmax = 13;
    private const float scaleheight = 1;
    private const float scalewidth = 3;
    private const float widthmax = -30;
    public Material[] materials;
    public GameObject block;
    void Start()
    {
        for (float height = 18; height > heightmax; height-=(scaleheight+heightgap))
        {
            for (float width = -3; width > widthmax; width -= (scalewidth+widthgap))
            {
                GameObject instanceblock = Instantiate(block, new Vector3((float)width, (float)height, blockz), Quaternion.identity);
                instanceblock.GetComponent<MeshRenderer>().material = materials[Random.Range(0, 4)];
            }
        }
    }
}
