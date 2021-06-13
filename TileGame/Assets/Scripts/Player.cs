using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    Animator myAnimator;

    bool isAlive = true;


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        FlipSprite();
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playervelocity = new Vector2(controlThrow * 5f, myRigidbody.velocity.y);
        myRigidbody.velocity = playervelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            //transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * Mathf.Sign(myRigidbody.velocity.x), transform.localScale.y);
        }
    }
}
