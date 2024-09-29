using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
 
    public TextMeshProUGUI textScore;
    
    float score = 0;

    private void Awake()
    {
        instance = this;
    }

    public void AddPoints(int pointValue)
    {

        score += pointValue;
        textScore.text = score.ToString();
    }

    
}

 
