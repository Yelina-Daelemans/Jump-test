using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    private Walking player;
    public TextMeshProUGUI ScoreText;
    public float Score;
    public TextMeshProUGUI HighScoreText;
    public float Highscore;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Walking>();
        if (PlayerPrefs.HasKey("Highscore"))
        {
            Highscore = PlayerPrefs.GetFloat("Highscore");
        }
        else
        {
            Highscore = 0;
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        HighScoreText.text = Highscore.ToString();
        ScoreText.text = Score.ToString();
        if(player == null)
        {
            SaveHighscore();
        }
    }
    public void SaveHighscore()
    {
        if(Score > PlayerPrefs.GetFloat("Highscore"))
        {
            PlayerPrefs.SetFloat("Highscore", Score);
        }
    }
}
