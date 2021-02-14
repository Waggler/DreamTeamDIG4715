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
    public GameObject DK;

    public int score;
    public int lives;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "x" + lives.ToString();
        bananaText.text = "x" + score.ToString();
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
    public void DecreaseLives(int hitByEnemy)
    {
        lives -= hitByEnemy;
        livesText.text = "x" + lives.ToString();
        if (lives < 1)
        {
            DK.gameObject.SetActive(false);
        }
    }
}
