using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float speed = 1f;
    public float lifeTime = 5f;

    internal Vector3 movedirection = Vector3.back;

    private Playercontroller player;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Environment>().player;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < lifeTime) timer += Time.deltaTime;
        else RegisterJumped();

        transform.position += movedirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillGate"))
        {
            RegisterJumped();
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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

    private void RegisterJumped()
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
