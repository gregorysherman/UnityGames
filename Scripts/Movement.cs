using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rocketRigidbody;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rocketRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            rocketRigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rocketRigidbody.freezeRotation = true; //freezing rotation to manually rotate rocket
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rocketRigidbody.freezeRotation = false; //unfreezing rotation so the physics system can take over
    }
}
