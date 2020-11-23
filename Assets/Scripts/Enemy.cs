using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float speed = 1f;
    private Playercontroller player;
    public Vector3 movedirection = Vector3.back;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Environment>().player;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movedirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "KillGate")
        {
            Destroy(this.gameObject);

            player.AddReward(0.5f);
            player.blocksJumpedOver++;
            if (player.blocksJumpedOver >= 100)
            {
                player.EndEpisode();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            player.AddReward(-1);
            player.lifes--;
            if (player.lifes <= 0)
            {
                player.EndEpisode();
            }
        }
    }
}
