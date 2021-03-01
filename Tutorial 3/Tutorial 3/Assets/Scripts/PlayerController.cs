using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 10f;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;

    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    private AudioSource playerAudio;
    //called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        dirtParticle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && isOnGround && !gameOver){
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound);
        }
            
    }

    private void OnCollisionEnter(Collision collision) {
        
        if(collision.gameObject.CompareTag("Ground")){
           isOnGround = true;
           dirtParticle.Play(); 
        } else if(collision.gameObject.CompareTag("Obstacle")){
            Debug.Log("Game Over Bitch!");
            explosionParticle.Play();
            playerAnim.SetInteger("DeathType_int",1);
            playerAnim.SetTrigger("Death_b");
            gameOver = true;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound);
        }
    }
}

