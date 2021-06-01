using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public Ball ball;
    public bool start = false;
    public int lives = 4;
    private Vector3 initialpos = new Vector3(-16f, 3, 0);
    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Horizontal");
        Vector3 movementDirection = new Vector3(verticalInput, 0, 0);
        if (canMove(transform.right) || verticalInput>0)
        {
            movementDirection.Normalize();
            transform.Translate(movementDirection * -speed * Time.deltaTime, Space.World);
        }else if (canMove(-transform.right) || verticalInput < 0)
        {
            movementDirection.Normalize();
            transform.Translate(movementDirection * -speed * Time.deltaTime, Space.World);
        }
        if (ball.transform.position.y < 1)
        {
            lives--;
            start = false;
            transform.position = initialpos;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }
    }

    bool canMove(Vector3 direction)
    {
        RaycastHit ray;
        Physics.Raycast(transform.position, direction, out ray, 6.0f);
        if (ray.transform != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
