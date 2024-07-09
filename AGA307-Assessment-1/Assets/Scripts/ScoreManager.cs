using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //static public int score = 100;
    static public int timeRemaining = 180;
    public GameObject scoreText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.GetComponent<Text>().text = "Score:" + score.ToString();

        scoreText.GetComponent<Text>().text = "time:" + timeRemaining.ToString();
    }


    public IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1);
        timeRemaining--;
        StartCoroutine(CountDown());
    }
}
