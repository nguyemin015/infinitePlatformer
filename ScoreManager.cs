using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public float scoreCount;

    public float pointsPerSecond;

    public bool scoreIncrease;

    // Start is called before the first frame update
    void Start()
    {
        scoreIncrease = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreIncrease == true)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
            scoreText.text = "Score: " + Mathf.Round(scoreCount);
        }
    }

}
