using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class Playercontroller : Agent
{
    public float jumpHeight = 5;
    private Rigidbody body;


    public override void Initialize()
    {
        base.Initialize();
        body = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(0, 0.6f, -4.6f);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        body.angularVelocity = Vector3.zero;
        body.velocity = Vector3.zero;
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0f;

        if (Input.GetKey(KeyCode.Space))
        {
            actionsOut[0] = 1f;
        }
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        if (vectorAction[0] != 0)
        {
            Vector3 translation = transform.up * jumpHeight * Time.deltaTime;
            transform.Translate(translation, Space.World);
        }
    }
}
