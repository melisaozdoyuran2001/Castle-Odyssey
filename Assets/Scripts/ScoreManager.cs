using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public static int scoreNum = 0;
    public  TextMeshProUGUI score;
    public static int levelNum = 1; 


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start() {
        if(levelNum == 1){
           scoreNum = 0; 
        }
        score.text = "Score: " + scoreNum.ToString() + " / 100";
         
    }

    public void IncreaseScore()
    {
        scoreNum+= 10;
        score.text = "Score: " + scoreNum.ToString() + " / 100";
    }
    public string GetScoreNum()
    {
        return scoreNum.ToString() ;
    }
}

    