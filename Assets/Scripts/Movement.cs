using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rigid;
    //public float horizontal;
    //public float vertical;
    //public float rate = 100f;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    //void Update()
    //{
    //    horizontal = Input.GetAxis("Horizontal");
    //    vertical = Input.GetAxis("Vertical");
    //    Vector3 direction = new Vector3(horizontal, 0.0f, vertical);
    //    rigid.AddForce(direction * rate);
    //}

    public float speed;
    public float rotationAnglePerSecond;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        movementDirection.Normalize();
        //movementDirection.Normalize();

        rigid.AddForce(movementDirection * speed);
        //transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationAnglePerSecond * Time.deltaTime);
        }
    }
}
