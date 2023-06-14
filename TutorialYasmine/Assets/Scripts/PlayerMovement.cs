using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
       
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        
        if(other.gameObject.CompareTag("JumpSignal")||other.gameObject.CompareTag("LandingSignal"))
        {
            triggerTag = other.tag;
            Debug.Log(triggerTag);
            //ps.PlaySignal();
        }    

    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("JumpSignal")||other.gameObject.CompareTag("LandingSignal"))
        {
            triggerTag = "None";
            Debug.Log(triggerTag);
        }      
    }

}