using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighUI : MonoBehaviour {
    Text text;
    void Awake()
    {
        // Set up the reference.
        text = GetComponent<Text>();
    }


    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = "HighScore: " + PlayerPrefs.GetInt("highscore");
    }
}
