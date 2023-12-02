using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.SceneManagement;
public class GameStarter : MonoBehaviour
{
    public Button startGame; 
    public Button instructions; 
    
    public void StartGame() {
        ScoreManager.levelNum = 1;
        SceneManager.LoadScene(1) ; 
    }

     public void ShowInstructions() {
        SceneManager.LoadScene(7) ; 
    }
}
