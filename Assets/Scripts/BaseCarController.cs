using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCarController : MonoBehaviour
{

    //Ruedas delanteras
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;

    //ruedas traseras
    public WheelCollider backLeftWheel;
    public WheelCollider backRightWheel;

    //Transforms de las ruedas
    public Transform frontLeftWheelT;
    public Transform frontRightWheelT;
    public Transform backLeftWheelT;
    public Transform backRightWheelT;

    //Variables para el control
    public float motorForce = 1500f;
    public float brakeForce = 3000f;
    public float maxSteerAngle = 30f;

    private float currentBrakeForce = 0f;
    private float currentSteerAngle = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Recoger entrada del usuario
        float moveInput = Input.GetAxis("Vertical"); //Acelerar/frenar (W/S o flechas)
        float steerInput = Input.GetAxis("Horizontal"); //Girar (A/D o flechas)
        bool isBraking = Input.GetKey(KeyCode.Space); //Frenar (espacio)

        //Control del vehiculo
        HandleMotor(moveInput, isBraking);
        HandleSteering(steerInput);
        UpdateWheels();
    }

    void HandleMotor(float moveInput, bool isBraking)
    {
        backLeftWheel.motorTorque = (moveInput * -1) * motorForce;
        backRightWheel.motorTorque = (moveInput * -1) * motorForce;

        currentBrakeForce = isBraking ? brakeForce : 0f;
        ApplyBrake();
    }

    void ApplyBrake()
    {
        //Freanar todas las ruedas
        frontLeftWheel.brakeTorque = currentBrakeForce;
        frontRightWheel.brakeTorque = currentBrakeForce;
        backLeftWheel.brakeTorque = currentBrakeForce;
        backRightWheel.brakeTorque = currentBrakeForce;
    }

    void HandleSteering(float steerInput)
    {
        //Calcular angulo de giro
        currentSteerAngle = steerInput * maxSteerAngle;
        frontLeftWheel.steerAngle = currentSteerAngle;
        frontRightWheel.steerAngle= currentSteerAngle;
    }

    void UpdateWheels()
    {
        //Actualizar posición y rotación de las ruedas
        UpdateWheelPose(frontLeftWheel, frontLeftWheelT);
        UpdateWheelPose(frontRightWheel, frontRightWheelT);
        UpdateWheelPose(backLeftWheel, backLeftWheelT);
        UpdateWheelPose(backRightWheel, backRightWheelT);
    }

    void UpdateWheelPose(WheelCollider collider, Transform transform)
    {
        Vector3 pos;
        Quaternion rot;
        collider.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.rotation = rot;   
    }


}
