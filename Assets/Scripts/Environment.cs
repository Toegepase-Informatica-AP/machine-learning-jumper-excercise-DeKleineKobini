using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public Enemy enemyPrefab;

    private Playercontroller player;
    private GameObject enemies;
    private TextMeshPro scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.GetComponentInChildren<Playercontroller>();
        enemies = transform.Find("Enemies").gameObject;
        scoreBoard = transform.GetComponentInChildren<TextMeshPro>();
    }

    private void FixedUpdate()
    {
        Debug.Log(player.GetCumulativeReward().ToString("f2"));
        scoreBoard.text = player.GetCumulativeReward().ToString("f2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
