using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    public Transform[] waypoints;
    int cur = 0;

    public float speed = 0.3f;
    void Update()
    {
        if (transform.position != waypoints[cur].position)
        {
            Vector2 p =Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
              
          else cur = (cur + 1) % waypoints.Length;

        
        //Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name=="pacman")
        {
            Destroy(collision.gameObject);
        }
    }
}
