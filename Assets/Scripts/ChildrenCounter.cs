using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChildrenCounter : MonoBehaviour
{

    private Text childrenTextCounter;
    public Text winLoseText;
    private int childsLeft;
    public int numberOfChilds;
    bool win;

    private void Awake()
    {
        childrenTextCounter = gameObject.GetComponent<Text>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        childsLeft = numberOfChilds;
        childrenTextCounter.text = childsLeft + " left";
        //Suscribirse al evento
        //FindObjectOfType<DisembarkChildren>().NombreFuncionDesembarque += OnDisembark;
    }

    private void Update()
    {
        if (win == true && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnDisembark ()
    {
        childsLeft--;
        childrenTextCounter.text = childsLeft + " left";
    
        if (childsLeft == 0)
        {
            WinScreen();
        }
    }

    private void WinScreen ()
    {
        winLoseText.text = "Thank you for rescuing all the children Press R to play again";
        winLoseText.color = new Color(255, 255, 255, 255);
        win = true;
    }
}
