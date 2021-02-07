using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;
    public TextMeshProUGUI bananaText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI lettersText;

    int score;
    int lives;
    int letters;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int banana)
    {
        score += banana;
        bananaText.text = "x" + score.ToString();
    }

    public void ChangeLives(int balloon)
    {
        lives += balloon;
        livesText.text = "x" + lives.ToString();
    }

    public void ChangeLetters(int letters)
    {
        letters += letters;
        lettersText.text = "x" + letters.ToString();
    }
}
