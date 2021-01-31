using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public List<FollowTarget> children = new List<FollowTarget>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("GameController instance already exists");
            Destroy(this);
        }
    }

    public void addChildren(FollowTarget gameObject) { children.Add(gameObject); }
    public void removeChildren(FollowTarget gameObject) { children.Remove(gameObject); }
}
