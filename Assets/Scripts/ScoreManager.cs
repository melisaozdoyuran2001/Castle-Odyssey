using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public static int scoreNum = 0;
    public  TextMeshProUGUI score;


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

    