using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int highscore=0;
    public static bool win;
    public static bool gameover = false;
    private static GameManager instance;

    public static GameManager Get()
    {
        return instance;
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        highscore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public static void Gameover()
    {
        GameManager.gameover = true;
        if (Block.cantscore > highscore&&win)
        {
            PlayerPrefs.SetInt("HighScore", Block.cantscore);
            highscore = Block.cantscore;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
