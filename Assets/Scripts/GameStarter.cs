using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;
using UnityEngine.SceneManagement;
public class GameStarter : MonoBehaviour
{
    public Button startGame; 
    
    public void StartGame() {
        SceneManager.LoadScene(1) ; 
    }
}
