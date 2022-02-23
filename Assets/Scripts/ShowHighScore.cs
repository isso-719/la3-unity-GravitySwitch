using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour
{
    Text text;
    int highScore;

    public ScoreController scoreController;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        highScore = scoreController.GetHighScore();
        text.text = "HighScore : " + highScore.ToString("000");
    }
}
