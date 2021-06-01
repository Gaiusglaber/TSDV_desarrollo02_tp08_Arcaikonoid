using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float speed = 100f;
    public Player player;
    private float ballgap = 1.5f;
    public bool launched = false;
    private Rigidbody rb;
    private Vector3 lastVelocity;
    // Update is called once per frame

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void LateUpdate()
    {
        lastVelocity = rb.velocity;
        if (!player.start)
        {
            Vector3 vec3 = player.transform.position;
            vec3.y += ballgap;
            transform.position = vec3;
        }
        else
        {
            if (!launched)
            {
                RandomLauncher();
                launched = true;
            }
        }
    }
    void RandomLauncher()
    {
        float[] directions= new float[2]{100f,-100f};
        rb.AddForce(new Vector3(directions[Random.Range(0, 1)], speed,0));
    }
    void OnCollisionEnter(Collision collisioninfo)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collisioninfo.contacts[0].normal);
        rb.velocity = direction * speed;
        if (collisioninfo.gameObject.tag != "Player"&& collisioninfo.gameObject.tag != "Wall")
        {
            Destroy(collisioninfo.gameObject);
        }
    }
}
