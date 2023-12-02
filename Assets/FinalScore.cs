using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
   public TextMeshProUGUI finalScore;
   void Start() {
    finalScore.text = "with a score of : " + ScoreManager.Instance.GetScoreNum() ; 
   }
}
