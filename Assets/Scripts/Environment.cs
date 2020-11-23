using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public Enemy enemyPrefab;

    public Playercontroller player;
    private GameObject enemies;
    private GameObject enemies2;
    private TextMeshPro scoreBoard;
    public Transform spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.GetComponentInChildren<Playercontroller>();
        enemies = transform.Find("Enemies").gameObject;
        enemies2 = transform.Find("Enemies2").gameObject;
        scoreBoard = transform.GetComponentInChildren<TextMeshPro>();
    }

    private void FixedUpdate()
    {
        scoreBoard.text = player.GetCumulativeReward().ToString("f3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab.gameObject);
        enemy.transform.SetParent(enemies.transform);
        enemy.transform.localPosition = new Vector3(0,0,0);
        enemy.GetComponent<Enemy>().movedirection = Vector3.back;
        float randtime = Random.Range(4, 9);
        Invoke("spawnEnemy", randtime);
    }

    void spawnEnemyCrossroad()
    {
        GameObject enemy = Instantiate(enemyPrefab.gameObject);
        enemy.transform.SetParent(enemies2.transform);
        enemy.GetComponent<Enemy>().movedirection = Vector3.left;
        enemy.transform.localPosition = new Vector3(0, 0, 0);

        float randtime = Random.Range(4, 9);
        Invoke("spawnEnemyCrossroad", randtime);
    }

    public void ResetEnvironment()
    {
        CancelInvoke();
        foreach (Transform enemy in enemies.transform)
        {
            Destroy(enemy.gameObject);   
        }
        foreach (Transform enemy in enemies2.transform)
        {
            Destroy(enemy.gameObject);
        }
        Invoke("spawnEnemy", Random.Range(1, 3));
        Invoke("spawnEnemyCrossroad", Random.Range(1, 3));
    }
}
