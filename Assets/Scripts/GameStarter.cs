using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.SceneManagement;
public class GameStarter : MonoBehaviour
{
    public Button startGame; 
    
    public void StartGame() {
        ScoreManager.levelNum = 1;
        SceneManager.LoadScene(1) ; 
    }
}
