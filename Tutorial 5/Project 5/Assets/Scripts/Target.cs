using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRB;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float torqueRange = 10;
    private float xStartRange = 4;
    private float yStart = 2;

    public int pointValue;

    public ParticleSystem explosionParticle;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        // Get the rigid body component
        targetRB = GetComponent<Rigidbody>();

        // Set random values for the force and torque
        targetRB.AddForce(Vector3.up * Random.Range(minSpeed,maxSpeed), ForceMode.Impulse);
        targetRB.AddTorque(Random.Range(-torqueRange,torqueRange),Random.Range(-torqueRange,torqueRange),Random.Range(-torqueRange,torqueRange), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-xStartRange,xStartRange), -yStart);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown(){
        if(gameManager.isGameActive){
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue); 
        } 
    }

    private void OnTriggerEnter(Collider other){
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad")){
          gameManager.GameOver(true); 
        }
        
    }
}
