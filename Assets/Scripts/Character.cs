using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private bool grounded;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Death death;
    [SerializeField]
    public GameObject Spawn;
    public GameObject player;
    public Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        // rb = Rigidbody 2D
        rb = GetComponent<Rigidbody2D>();
        anim.SetBool("land", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // The x axis changes when you hit left or right arrow/ a & d respectively
        movement.x = Input.GetAxisRaw("Horizontal");
        // Rigidbodies velocity is the same as the x axis times the movespeed time the y axis
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }

}
