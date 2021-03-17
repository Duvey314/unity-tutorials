using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    public List<GameObject> targets;
    
    // Create text variables
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI difficultyText;

    // Create buttons
    public Button resetButton;
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;


    // Initialize variables
    private int score = 0;
    private float spawnRate = 1.0f;
    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
        easyButton.gameObject.SetActive(true);
        mediumButton.gameObject.SetActive(true);
        hardButton.gameObject.SetActive(true);
        difficultyText.gameObject.SetActive(true);
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget(){
        while (isGameActive){
           yield return new WaitForSeconds(spawnRate);
           int index = Random.Range(0, targets.Count); 
           Instantiate(targets[index]);
        }
        
    }

    public void UpdateScore(int scoreToAdd){
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver(bool yes){
        gameOverText.gameObject.SetActive(yes);
        isGameActive = false;
        resetButton.gameObject.SetActive(true);
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SelectDifficulty(Button button){
        if(button.name == "Easy Button"){
            spawnRate = 1.0f;
        }
        else if(button.name == "Medium Button"){
            spawnRate = 0.75f;
        }
        else{
            spawnRate = 0.5f;
        }
        easyButton.gameObject.SetActive(false);
        mediumButton.gameObject.SetActive(false);
        hardButton.gameObject.SetActive(false);
        difficultyText.gameObject.SetActive(false);
        isGameActive = true;
        StartCoroutine(SpawnTarget());
    }
}
