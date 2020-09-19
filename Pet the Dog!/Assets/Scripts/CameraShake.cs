using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform camTransform;
    private float shakeDuration;
    private float shakeMagnitude = 1.0f;
    private float dampingSpeed = 1.0f; // How quickly the shake should evaporate
    Vector3 initialPosition;

    void Awake()
    {
        if (transform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform; // Connect the camera's location (Transform)
        }
    }

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude; //SHAKE IT BABY

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }

        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void TriggerShake() //Trigger this from Hazard.cs to activate the shaking
    {
        shakeDuration = 0.1f;
    }
}