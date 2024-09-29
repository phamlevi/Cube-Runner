using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    
    public PlayerMovement movement;

    public AudioSource coinCollectS;
    
    public int coinsPtValue = 10;
    public int JumpPPtValue = 50;
    
    
    //coins - collect, score and delete
    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Coins") //coins
        {
            Debug.Log("Collected a coin.");
            coinCollectS.Play();
            ScoreManager.instance.AddPoints(coinsPtValue);
            Destroy(Col.gameObject);
        }
        if (Col.gameObject.tag == "JumpPad") { //jump pads
            movement.superJpRemain++;
            coinCollectS.Play();
            ScoreManager.instance.AddPoints(JumpPPtValue);
            Destroy(Col.gameObject);
        }
    }
}
