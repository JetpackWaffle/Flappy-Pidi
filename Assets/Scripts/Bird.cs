using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    public float upForce = 200f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
    }


    void Update()
    {
        if (!isDead)
        {
            if (Input.GetMouseButtonDown (0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
        }
    }

    void OnCollisionEnter2D ()
    {
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(new Vector2(50, 0));
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }
}
