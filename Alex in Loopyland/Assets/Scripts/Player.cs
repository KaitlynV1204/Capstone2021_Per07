using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/*Code for Player: Movement, collision*/

//Video to watch while i'm supposed to be doing work
//https://youtu.be/7u-39guEQbE?t=533

// 2D Shooting in Unity (use for code to detect damage from the queen, changing animation)
//https://www.youtube.com/watch?v=wkKsl1Mfp5M

public class Player : MonoBehaviour
{
    private Player_Animation playerAnimScr;

    private float speed = 9f;
    private float jumpVelocity = 8f;

    [SerializeField]
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool canJump;

    public int health = 100;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        canJump = false;
    }
    
    void Update()
    {
        #region Movement Input
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        #endregion

        if (isGrounded)
        {
            Jump();
        } 

        #region Flip Sprite in Update
        Vector3 characterScale = transform.localScale;
        if(Input.GetAxis("Horizontal") < 0) 
        {
            characterScale.x = -1;
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
        #endregion

    }

    #region Jump Method using Rb.Velocity
    void Jump()
    {
        //use velocity
        if (Input.GetKeyDown(KeyCode.W) && canJump == true)
        {
            canJump = false;
            rb.velocity = new Vector3(0 * Input.GetAxis("Horizontal"), 10, 0);
        }

    }
    #endregion

    //NOTE: w/ collision, make sure both object are on same z value, player rb is simulated, no triggers
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Foreground" || /*temp*/ collision.gameObject.tag == "ToTestKnockback")
        {
            isGrounded = true;
            canJump = true;
        } //Enter tag for the colliding tiles


        #region Dangerous Stuff
        if (collision.gameObject.tag == /*"[REAL TAG NAME HERE]"*/ "ToTestKnockback")
        {
            // TEMPORARY - PLACE INTO TRIGGER OR ANOTHER SCRIPT FOR ANIMS ONCE HAVE THE CODE FOR THE QUEEN TO REFERENCE (KNOCKBACK)
            StartCoroutine(Knockback(0.02f, 350, transform.position));
            TakeDamage();

            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }  //Enter Tag for the dangerous colliding tiles
        
        // let Arath know about the tag
        //if(collision.gameObject.tag == "Queen's Bullet")
        //{
        //    TakeDamage();
        //}
        #endregion
    }

    void OnTriggerEnter2D(Collider2D signs)
    {

    } // Currently empty - contents are temporary

    void OnTriggerExit2D(Collider2D noSigns)
    {
        
    } //Currently empty


    // Duration = time knockback force lasts; Power = Power of knockback; Direction = Direction of knockback
    public IEnumerator Knockback(float knockDuration, float knockPower, Vector3 knockDirection)
    {
        float timer = 0;
        while(knockDuration > timer)
        {
            timer += Time.deltaTime;
            rb.AddForce(new Vector3(knockDirection.x * -200, knockDirection.y * knockPower, transform.position.z));
            // (Backwards by 100 units, upwards force determined by knockPower, no change in z)
        }

        yield return 0; // once knockDuration = 0, IEnumerator stops
    }

    void TakeDamage()
    {
        health -= 20;
        Animator _playerAnim = playerAnimScr.playerAnimator;
        _playerAnim.SetBool("hitByQueen", true);

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            health = 100;
        }
    }
}
