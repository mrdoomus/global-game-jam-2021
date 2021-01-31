using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    public GameObject textDisplay;
    public Text winLoseText;
    public Movement playerMovement;
    public int secondsLeft = 30;
    public bool takingAway = false;
    private bool lose;

    void Start ()
    {
        textDisplay.GetComponent<Text>().text = secondsLeft + " s";
        takingAway = true;
    }

    void Update ()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
        else if (secondsLeft <= 0)
        {
            lose = true;
            playerMovement.speed = 0;
            winLoseText.text = "You weren't fast enough, Press R to play again";
            winLoseText.color = new Color(255, 255, 255, 255);

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator TimerTake ()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft <10)
        {
            textDisplay.GetComponent<Text>().text = secondsLeft + " s";
        }
        else
        {
            textDisplay.GetComponent<Text>().text = secondsLeft + " s";
        }
        
        takingAway = false;
    }



}
