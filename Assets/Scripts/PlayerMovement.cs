using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FirstPersonMovement used to test player movement in first person
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        transform.Translate(move * speed * Time.deltaTime);
    }
}
