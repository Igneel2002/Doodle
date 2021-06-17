using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    public Character play;


    // Start is called before the first frame update
    void Start()
    {
        
        play.anim.GetComponent<Animator>();
        play.anim.SetBool("land", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                play.anim.SetBool("land", true);
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        play.anim.SetBool("land", false);
    }
}
