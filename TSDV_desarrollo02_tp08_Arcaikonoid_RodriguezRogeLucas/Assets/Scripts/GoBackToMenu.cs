using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void gobacktomenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2);
        GameManager.gameover = false;
        GameManager.win = false;
        Block.cantscore = 0;
    }
}
