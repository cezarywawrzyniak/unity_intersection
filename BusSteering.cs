using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusSteering : MonoBehaviour
{
    private List<Transform> nodes;

    public int currentNode = 0;

    public float maxSteerAngle = 45f;
    public float maxMotorTorque = 500f;
    public float maxBrakeTorque = 1000f;
    public float currentSpeed;
    public float maxSpeed = 25f;
    public float turnSpeed = 8f;

    public bool isBraking = false;
    public bool brakedOnce;

    public Vector3 centerOfMass;

    public Transform path;

    [Header("Wheels")]
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;

    [Header("Sensor")]
    public float sensorLength = 8f;

    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;

        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    void FixedUpdate()
    {
        ApplySteer();
        Drive();
        CheckWaypointDistance();
        Braking();
        Sensors();
        if (brakedOnce)
        {
            sensorLength = 10f;
        }
    }

    private void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;

        wheelFL.steerAngle = Mathf.Lerp(wheelFL.steerAngle, newSteer, Time.deltaTime * turnSpeed);
        wheelFR.steerAngle = Mathf.Lerp(wheelFR.steerAngle, newSteer, Time.deltaTime * turnSpeed);
    }

    private void Drive()
    {
        currentSpeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 1000;

        if (currentSpeed < maxSpeed && !isBraking)
        {
            wheelFL.motorTorque = maxMotorTorque;
            wheelFR.motorTorque = maxMotorTorque;
            wheelRL.motorTorque = maxMotorTorque;
            wheelRR.motorTorque = maxMotorTorque;
        }
        else
        {
            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
            wheelRL.motorTorque = 0;
            wheelRR.motorTorque = 0;
        }
    }

    private void CheckWaypointDistance()
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 2.5f)
        {
            if (currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }
            else
            {
                currentNode++;
            }
        }
    }

    private void Braking()
    {

        if (isBraking)
        { 
            wheelFL.brakeTorque = maxBrakeTorque;
            wheelFR.brakeTorque = maxBrakeTorque;
            wheelRL.brakeTorque = maxBrakeTorque;
            wheelRR.brakeTorque = maxBrakeTorque;
        }
        else
        {
            wheelFL.brakeTorque = 0;
            wheelFR.brakeTorque = 0;
            wheelRL.brakeTorque = 0;
            wheelRR.brakeTorque = 0;
        }
    }

    private void Sensors()
    {
        RaycastHit hit;
        Vector3 sensorStartPos = transform.position;
        sensorStartPos.y += 1f;
       

        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength) && hit.transform.tag != "destroyers" && hit.transform.tag != "counters")
        {
            Debug.DrawLine(sensorStartPos, hit.point);
            //print(Vector3.Distance(transform.position, hit.point));
            maxBrakeTorque = 11000 / Vector3.Distance(transform.position, hit.point);
            //print(maxBrakeTorque);
            isBraking = true;
            if (currentSpeed == 0)
            {
                brakedOnce = true;
            }
        }
        else
        {
            isBraking = false;
        }
    }
}
