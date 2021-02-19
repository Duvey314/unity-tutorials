using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // create object for player
    public GameObject player;

    // create variable to store camera offest
    private Vector3 offset = new Vector3(0,6,-10);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //offset the camera behind the player
        transform.position = player.transform.position + offset;
    }
}
