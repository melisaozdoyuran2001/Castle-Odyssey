using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class Player : MonoBehaviour {

    [SerializeField] float      m_speed = 4.0f;
    [SerializeField] float      m_jumpForce = 7.5f;
    [SerializeField] private AudioSource attackSoundEffect;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource gameOverSoundEffect;
    [SerializeField] private AudioSource runSoundEffect;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_Bandit       m_groundSensor;
    private bool                m_grounded = false;
    private bool                m_combatIdle = false;
    public GameObject           orbPrefab; 
    public float                bombVelocity = 2f; 

    public TextMeshProUGUI gameOverTmp;
    public Button playAgain; 
    public BackgroundMusicController backgroundMusicController;

    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
        Transform canvasTransform = GameObject.Find("Game Over Message").transform;
        gameOverTmp = canvasTransform.Find("Text").GetComponent<TextMeshProUGUI>();
    }
	
	// Update is called once per frame
	void Update () {
        //Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State()) {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

      

        //Check if character just started falling
        if(m_grounded && !m_groundSensor.State()) {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0 ) {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
            if(!m_grounded){
                runSoundEffect.Stop();
            }
            else {
                 if (!runSoundEffect.isPlaying) {
                runSoundEffect.Play();
            }
            }
        } 
        else if (inputX < 0) {
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
           if(!m_grounded){
                runSoundEffect.Stop();
            }
            else {
                 if (!runSoundEffect.isPlaying) {
                runSoundEffect.Play();
            }
            }
        } 
        else {
            if (runSoundEffect.isPlaying) {
                runSoundEffect.Stop();
            }
        }


        // Move
        m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

        //Set AirSpeed in animator
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

        // -- Handle Animations --
        //Attack
        if(Input.GetMouseButtonDown(0)) {
            attackSoundEffect.Play();
            m_animator.SetTrigger("Attack");
            FireToEnemy();
        }

        //Jump
        else if (Input.GetKeyDown("space") && m_grounded) {
            jumpSoundEffect.Play();
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
        }



        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon){
            m_animator.SetInteger("AnimState", 2);
           
        }

        //Combat Idle
        else if (m_combatIdle)
            m_animator.SetInteger("AnimState", 1);

        //Idle
        else
            m_animator.SetInteger("AnimState", 0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Dead Zone" || other.gameObject.tag == "enemy") {
            backgroundMusicController.StopBackgroundMusic();
            gameOverSoundEffect.Play();
            gameOverTmp.text = "Game Over";
            //Destroy(runSoundEffect);
            runSoundEffect.Stop();
            playAgain.gameObject.SetActive(true); 
            Time.timeScale = 0f; 
             GameObject objectToDestroy = GameObject.FindWithTag("orb"); 
         if (objectToDestroy != null)
            {
                Destroy(objectToDestroy);
                Debug.Log("Destroyed");
            }
           
           
        }
        else if( other.gameObject.tag == "lvl1"){
            SceneManager.LoadScene(2);
            ScoreManager.levelNum = 2; 
        }
        else if( other.gameObject.tag == "lvl2"){
            SceneManager.LoadScene(3);
            ScoreManager.levelNum = 3; 
        }
        else if( other.gameObject.tag == "lvl3"){
            SceneManager.LoadScene(4);
            ScoreManager.levelNum = 4; 
        }
         else if( other.gameObject.tag == "lvl4"){
            SceneManager.LoadScene(5);
            ScoreManager.levelNum = 5; 
        }
        else if( other.gameObject.tag == "lvl5"){
           SceneManager.LoadScene(6);
        }
    }

    void FireToEnemy() {

        Vector3 direction = transform.localScale.x > 0 ? -transform.right : transform.right;
        Vector3 spawnPosition = transform.position + direction;
        GameObject bomb = Instantiate(orbPrefab, spawnPosition, Quaternion.identity);

        bomb.transform.localPosition += new Vector3(0, 0.7f, 0);
        Rigidbody2D bombRB = bomb.GetComponent<Rigidbody2D>();
        bombRB.velocity = bombVelocity * direction;

    }

   public void RestartGame() {
    Time.timeScale = 1f; 
    // GameObject objectToDestroy = GameObject.FindWithTag("orb"); 
    // if (objectToDestroy != null)
    // {
    //     AudioSource audioSource = objectToDestroy.GetComponent<AudioSource>();
    //     if (audioSource != null) {
    //         audioSource.Stop(); // Stop the audio
    //     }
    //     Destroy(objectToDestroy);
    //     Debug.Log("Orb Destroyed");
    // }
    ScoreManager.levelNum = 1; 
    SceneManager.LoadScene(1);
   }
}

