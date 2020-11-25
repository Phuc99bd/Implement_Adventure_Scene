using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 60f, maxspeed = 5, jumpPow = 20;
    public bool grounded = true, faceRight = true;
    // Start is called before the first frame update
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public int ourHealth = 5;
    public int maxHealth = 5;
    public bool isKnock = false;
    public int hightScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        rigidbody2D.AddForce(Vector2.right * speed * h);
        animator.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Grounded", grounded);
            if (grounded)
            {
                grounded = false;
                rigidbody2D.AddForce(Vector2.up * jumpPow);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Grounded", grounded);
            if (grounded)
            {
                rigidbody2D.AddForce(Vector2.down * jumpPow);
              
            }
        }

        // lọt hố chết
        if (rigidbody2D.position.y <= -4)
        {
            Death();
        }

        if (rigidbody2D.velocity.x > maxspeed)
        {
            rigidbody2D.velocity = new Vector2(maxspeed, rigidbody2D.velocity.y);
        }
        if (rigidbody2D.velocity.x < -maxspeed)
        {
            rigidbody2D.velocity = new Vector2(-maxspeed, rigidbody2D.velocity.y);
        }

        if (h > 0 && !faceRight)
        {
            Flip();
        }
        if (h < 0 && faceRight)
        {
            Flip();
        }

        if (grounded)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x * 0.7f, rigidbody2D.velocity.y);
        }

    }
    public void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale;
        scale = transform.localScale;
        scale.x *= -1;
        this.transform.localScale = scale;
    }

    public void knock(float knockPow, Vector2 knockPos, int dame)
    {
        isKnock = true;
        rigidbody2D.velocity = new Vector2(0, 0);
        rigidbody2D.AddForce(new Vector2(knockPos.x * (faceRight && Input.GetAxis("Horizontal") > 0 ? -knockPow : knockPow), knockPow / 2 + knockPos.y));
        ourHealth -= dame;
        isKnock = false;
    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void increaseScore( int score)
    {
        hightScore += score;
    }
}
