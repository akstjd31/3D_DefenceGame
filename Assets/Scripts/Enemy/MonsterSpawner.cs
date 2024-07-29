using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public Transform monsterPrefab;
    public Transform goal;
    private int spawnCount = 0;
    public const float SPAWN_INVERVAL = 2.0f;
    [SerializeField] private float spawnTime = SPAWN_INVERVAL;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (0 < gameManager.monsterCount)
        {
            if (spawnTime <= 0.0f)
            {
                SpawnMonster();
                spawnTime = SPAWN_INVERVAL;
                gameManager.monsterCount--;
            }
            else
            {
                spawnTime -= Time.deltaTime;
            }
        }
    }

    private void SpawnMonster()
    {
        GameObject monster = Instantiate(monsterPrefab.gameObject, new Vector3(
            this.transform.position.x + Random.Range(0f, 1f),
            this.transform.position.y,
            this.transform.position.z + Random.Range(0.0f, 1.0f)
        ), Quaternion.identity);

        monster.transform.GetChild(0).GetComponent<MonsterAI>().SetGoal(goal);
    }
}
