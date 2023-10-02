using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public int scoreValue = 0;
    private TextMeshProUGUI scoreCounterText;
    private void Awake()
    {
        Walking.PointsPickedUp += RunCo;
        scoreCounterText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        scoreValue = 0;
    }

    void Update()
    {
            scoreCounterText.text = scoreValue.ToString();
    }
    private IEnumerator Pulse()
    {
        for(float i = 1f; i<=1.2f; i += 0.5f)
        {
            scoreCounterText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        scoreCounterText.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        scoreValue += 10;
        for (float i = 1.2f; i >= 1f; i -= 0.5f)
        {
            scoreCounterText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        scoreCounterText.rectTransform.localScale = new Vector3(1f, 1f, 1f);
    }
    public void RunCo()
    {
        StartCoroutine(Pulse());
    }
    private void OnDestroy()
    {
        Walking.PointsPickedUp -= RunCo;
    }
}
// code bestanden + bestand met link naar githhub directory