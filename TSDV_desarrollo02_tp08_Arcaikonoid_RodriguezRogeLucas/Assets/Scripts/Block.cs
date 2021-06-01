using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public static int cantscore = 0;
    void OnDestroy()
    {
        if (!GameManager.gameover)
        {
            cantscore += 50;
            if (!GameObject.Find("Cube(Clone)"))
            {
                GameManager.win = true;
                GameManager.Gameover();
            }
        }
    }
}
