using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class Playercontroller : Agent
{
    public float jumpHeight = 5;
    private Rigidbody body;
    bool isGrounded = false;
    internal int lifes = 5;
    public int defaultLives = 5;
    internal int blocksJumpedOver = 0;

    public override void Initialize()
    {
        base.Initialize();
        body = GetComponent<Rigidbody>();
        body.freezeRotation = true;
    }
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(0, 0.6f, -4.6f);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        body.angularVelocity = Vector3.zero;
        body.velocity = Vector3.zero;
        Enemy.speed = Random.Range(3f, 5f);
        GetComponentInParent<Environment>().ResetEnvironment();
        lifes = defaultLives;
        blocksJumpedOver = 0;
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
        if (vectorAction[0] != 0 && isGrounded)
        {
            isGrounded = false;
            AddReward(-0.1f);
            body.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
        }
    }
}
