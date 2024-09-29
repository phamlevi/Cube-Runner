using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class PlayerCollision : MonoBehaviour

{
    public PlayerMovement movement;
    public AudioSource playerCollisionS;
   

    private void OnCollisionEnter(Collision Col)
    {

        //end game if collide w obstacle
        if (Col.collider.tag == "Obstacle") {
            
            movement.enabled = false;
            playerCollisionS.Play();

            FindAnyObjectByType<GameManager>().EndGame();
        }
    }

    
}
