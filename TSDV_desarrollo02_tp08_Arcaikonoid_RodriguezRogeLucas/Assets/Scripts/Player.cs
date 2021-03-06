using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public TMPro.TMP_Text livesText;
    public Ball ball;
    public bool start = false;
    public int lives = 4;
    private Vector3 initialpos = new Vector3(-16f, 3, 0);
    // Update is called once per frame
    void Start()
    {
        livesText.text = lives.ToString();
    }
    void Update()
    {
        if (!GameManager.gameover)
        {
            float verticalInput = Input.GetAxisRaw("Horizontal");
            Vector3 movementDirection = new Vector3(verticalInput, 0, 0);
            transform.Translate(movementDirection * -speed * Time.deltaTime, Space.World);
            if (ball.transform.position.y < 1)
            {
                lives--;
                livesText.text = lives.ToString();
                if (lives <= 0)
                {
                    GameManager.win = false;
                    GameManager.Gameover();
                }
                start = false;
                ball.launched = true;
                transform.position = initialpos;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                start = true;
            }
        }
    }

    void OnCollisionExit(Collision colliderinfo)
    {
        GetComponent<Rigidbody>().velocity=Vector3.zero;
    }
}