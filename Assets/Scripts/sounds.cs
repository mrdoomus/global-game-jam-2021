using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
    public AudioClip collectedBoy;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Children")
        {
            Debug.Log("collected");
            audioSource.clip = collectedBoy;
            audioSource.PlayOneShot(collectedBoy, 1F);
            collider.GetComponent<AudioSource>().Stop();
        }
    }
}
