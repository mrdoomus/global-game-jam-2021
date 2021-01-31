using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rigid;
    public Animator anim;
    public AudioClip swim;
    private AudioSource audioSource;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public float speed;
    public float rotationAnglePerSecond;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        if(horizontalInput != 0 || verticalInput != 0)
        {
            anim.SetFloat("swim", 1);
           
            //Debug.Log(verticalInput);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(swim);
            }
        }
        else
        {
            anim.SetFloat("swim", 0);
            audioSource.Stop();
        }
        Vector3 movementDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        rigid.AddForce(movementDirection * speed);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationAnglePerSecond * Time.deltaTime);
        }
    }
}
