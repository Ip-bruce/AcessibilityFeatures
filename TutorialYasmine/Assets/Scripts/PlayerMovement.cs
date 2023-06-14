using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public AudioClip jumpSound;
    public AudioClip LandingSound;
    public AudioSource Audio;
    float MovX;
    float MovY;
    public float Vel;
    public float JumpVel;
    Rigidbody2D rb;
    public static string triggerTag;

    AcessibilityTool ps;

    public GameObject bolaVerde;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovX = Input.GetAxis("Horizontal");
        //MovY = Input.GetAxis("Vertical");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * JumpVel);
            Debug.Log("Jump");
            Audio.PlayOneShot(jumpSound,1.0f);
        }
        transform.position += new Vector3(MovX * Vel * Time.deltaTime,0,0);
            
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("COLIDI!!!!!!!!!!!!!!!!!!");
        if(other.gameObject.CompareTag("Ball"))
        {
            Destroy(bolaVerde);
        }
        if(other.gameObject.CompareTag("Ground"))
        {
            Audio.PlayOneShot(LandingSound,1.0f);
        }
        if(other.gameObject.CompareTag("Win"))
        {
           StartCoroutine(Wait());
        }
        
       
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        
        if(other.gameObject.CompareTag("JumpSignal")||other.gameObject.CompareTag("LandingSignal")||other.gameObject.CompareTag("Wall")||other.gameObject.CompareTag("Win"))
        {
            triggerTag = other.tag;
            Debug.Log(triggerTag);
            //ps.PlaySignal();
        }    

    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("JumpSignal")||other.gameObject.CompareTag("LandingSignal")||other.gameObject.CompareTag("Wall")||other.gameObject.CompareTag("Win"))
        {
            triggerTag = "None";
            Debug.Log(triggerTag);
        }      
    }

     IEnumerator Wait()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        SceneManager.LoadScene("Win");
    }

}