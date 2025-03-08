using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI; 

public class ScoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    //The actual version of score
    public TextMeshProUGUI ScoreText; 

    public TextMeshProUGUI highScoreText; 

    //The integer version of the score 
    int score = 0; 
    int highScore = 0; 
    void Start()
    {
        ScoreText.text = "Score: $" + score.ToString(); 

        highScoreText.text = "High Score: $" + highScore.ToString(); 
        
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

    
}
