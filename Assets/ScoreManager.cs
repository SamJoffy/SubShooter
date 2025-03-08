using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI; 

public class ScoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static ScoreManager instance; 


    //The actual version of score
    public TextMeshProUGUI ScoreText; 

    public TextMeshProUGUI highScoreText; 

    public TextMeshProUGUI Depth; 

    //The integer version of the score 
    int score = 0; 
    int highScore = 0;

    float depth = 0; 

    private void Awake()
    {
        instance = this; 
    } 
    void Start()
    {
        ScoreText.text = "Score: $" + score.ToString(); 

        highScoreText.text = "High Score: $" + highScore.ToString(); 

        Depth.text = "Depth: " + Mathf.RoundToInt(depth).ToString() + "m";
        
    }




    // Increases Score everytime a treasure token is collected
    public void AddPoint() {
        score += 1000; 
        ScoreText.text = "Score: $" + score.ToString();

        if (score > highScore) {
            highScore = score; 
            highScoreText.text = "High Score: $" + highScore.ToString(); 
        }

    }

    public void AddDepth() {
        depth += 1 *Time.deltaTime; 

        Depth.text = "Depth: " + Mathf.RoundToInt(depth).ToString() + "m";
    }

    
}
