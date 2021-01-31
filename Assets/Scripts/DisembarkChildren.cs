using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisembarkChildren : MonoBehaviour
{
    public Transform[] childPositions;
    private int arrayPosition;

    private void Start()
    {
        arrayPosition = 0;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < GameController.instance.children.Count; i++)
            {
                GameController.instance.children[i].ChangeTargerts(childPositions[arrayPosition]);
                GameController.instance.children[i].MoveAndDisable();
                arrayPosition++;
            }
        }
    }

}
