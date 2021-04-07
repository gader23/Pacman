using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movimiento de Pacman
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        //Comprobacion del input
        if((Vector2)transform.position==dest)
        {
            if(Input.GetKey(KeyCode.UpArrow)&&destValid(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;
            }
            if (Input.GetKey(KeyCode.DownArrow) && destValid(-Vector2.up))
            {
                dest = (Vector2)transform.position - Vector2.up;
            }
            if (Input.GetKey(KeyCode.RightArrow) && destValid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && destValid(-Vector2.right))
            {
                dest = (Vector2)transform.position - Vector2.right;
            }
        }

        //Parametros de animacion
        Vector2 dir = dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    //Funcion para comprobar si pacman puede moverse al siguiente punto
    bool destValid(Vector2 dir)
    {
        
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos+dir,pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
}
