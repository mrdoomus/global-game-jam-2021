using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;
    public bool hasCollided = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") hasCollided = true;
    }

    void Update()
    {
        if(hasCollided) transform.position = objectToFollow.position + offset;
    }
}
