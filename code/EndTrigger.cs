using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndTrigger : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.name == "Player" ) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        }
           
       
        
    }
}
