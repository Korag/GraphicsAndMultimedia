using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimplePlatformController : MonoBehaviour
{
    [HideInInspector] public bool facingRight = true;   // Infinite scroller we move in one direction
    [HideInInspector] public bool jump = false;         // Has our character jumped?
    [HideInInspector] public int score = 0;
    [HideInInspector] public float timer = 60f;

    public const int COIN1POINT = 1;
    public const int COIN4POINTS = 4;

    public float moveForce = 365f;                      // Movement force multiplier
    public float maxSpeed = 5f;                         // Maximum velocity  
    public float jumpForce = 1000f;                     // Velocity of jumping
    public Transform groundCheck;                       // Used to compute if our character is touching the ground
                                                       // Essentially casting a ray downwards onto the ground plane

    private bool grounded = false;                      // Are we on the ground or not?
    private Animator anim;                              // Store our animations for your character (already setup for us)
    private Rigidbody2D rb2d;                           // Instance of our RigidBody. Good practice to do this, as opposed
                                                        // to directly referencing our rigidbody object

    public Text timerText;
    public Text scoreText;
    public Text endGameText;

    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        timerText.text = "Timer: " + timer.ToString("f2") + "s";
        scoreText.text = "Score: " + score;
        endGameText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "Timer: " + timer.ToString("f2") + "s";

        if (timer <= 0.00)
        {
            timerText.text = "Timer: 0.00 s";
            endGameText.text = "The game has ended.";
            Time.timeScale = 0;
        }

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        // The user may jump if they are touching the ground
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }

    // Function for turning our player left or right
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1; //Trick to mirror character
        transform.localScale = tempScale;
    }

    // Called once per physics frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); // h is a value between 0 and 1
        anim.speed =  Mathf.Abs(h);  // Set our animation speed to a value of h

        // Accelerate our character if they are under our max speed
        if (h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * h * moveForce);
        }
        // If we're greater than our max speed, then keep moving us at max speed
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }

        // Turn our character to face the right direction
        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }
        // If we are jumping, change the animation, add a force
        if (jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin1point"))
        {
            score += COIN1POINT;
            scoreText.text = "Score: " + score;
        }
        else if (other.gameObject.CompareTag("Coin4points"))
        {
            score += COIN4POINTS;
            scoreText.text = "Score: " + score;
        }
    }
}
