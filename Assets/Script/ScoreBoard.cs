using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    Text scoreText;

    private void Start()
    {
        scoreText = gameObject.GetComponent<Text>();
        scoreText.text = "Score : " + score.ToString();
    }

    public void ScoreTextInc(int scoreInc)
    {
        score += scoreInc;
        scoreText.text = "Score : " + score.ToString();
    }
}
