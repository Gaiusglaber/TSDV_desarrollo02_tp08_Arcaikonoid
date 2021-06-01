using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public Ball ball;
    public bool start = false;
    public int lives = 4;
    private Vector3 initialpos = new Vector3(-16f, 3, 0);
    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxisRaw("Horizontal");
        Vector3 movementDirection = new Vector3(verticalInput, 0, 0);
        transform.Translate(movementDirection * -speed * Time.deltaTime, Space.World);
        if (ball.transform.position.y < 1)
        {
            lives--;
            start = false;
            ball.launched = true;
            transform.position = initialpos;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }
    }

    void OnCollisionExit(Collision colliderinfo)
    {
        Debug.Log("choque");
        GetComponent<Rigidbody>().velocity=Vector3.zero;
    }
}
