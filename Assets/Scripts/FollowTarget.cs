using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform objectToFollow;
    public bool hasCollided = false;
    public Vector3 offset = new Vector3(0, 15f, -25f);
    public bool followFromStart = false;

    private void Start()
    {
        if (followFromStart)
        {
            hasCollided = true;
            StartCoroutine(FollowPlayer());
        }
    }

    public void ChangeTargerts(Transform transform)
    {
        objectToFollow = transform;
        hasCollided = false;
        StopAllCoroutines();
    }

    public void MoveAndDisable()
    {
        transform.position = objectToFollow.position;
        GameController.instance.removeChildren(this);
        enabled = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            hasCollided = true;

            offset.z *= GameController.instance.children.Count + 1;
            GameController.instance.addChildren(this);

            StartCoroutine(FollowPlayer());
        }
    }

    IEnumerator FollowPlayer()
    {
        while(hasCollided)
        {
            transform.position = objectToFollow.position + offset;
            if (!followFromStart) transform.rotation = new Quaternion(objectToFollow.localRotation.x / 2, objectToFollow.localRotation.y / 2, objectToFollow.localRotation.z / 2, 1);
            yield return null;
        }
    }
}
