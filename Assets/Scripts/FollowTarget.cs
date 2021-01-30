using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform objectToFollow;
    public bool hasCollided = false;
    private Vector3 offset = new Vector3(0, 0, -15f);

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            hasCollided = true;

            offset.z *= GameController.instance.children.Count + 1;
            GameController.instance.addChildren(gameObject);

            StartCoroutine(FollowPlayer());
        }
    }

    IEnumerator FollowPlayer()
    {
        while(hasCollided)
        {
            transform.position = objectToFollow.position + offset;
            transform.rotation = new Quaternion(objectToFollow.localRotation.x / 2, objectToFollow.localRotation.y / 2, objectToFollow.localRotation.z / 2, 1);
            yield return null;
        }
    }
}
