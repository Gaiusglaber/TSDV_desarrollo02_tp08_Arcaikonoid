using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5;
    public Player player;
    private float ballgap = 2;
    private bool launched = false;
    private Vector3 vec3;
    // Update is called once per frame
    void Start()
    {
        vec3 = transform.up;
    }
    void LateUpdate()
    {
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
            }
            transform.Translate(vec3 * speed * Time.deltaTime, Space.World);
        }

    }
    void RandomLauncher()
    {
        float[] directions= new float[2]{0.5f,-0.5f};
        vec3.x = directions[Random.Range(0, 1)];
        vec3.Normalize();
    }
    void OnTriggerEnter(Collider collisioninfo)
    {
        Debug.Log("labolachoco");
        transform.forward = Vector3.Reflect(transform.forward, collisioninfo.gameObject.transform.forward);
    }
}
