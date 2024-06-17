using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] spawnPoints = new Transform[8];
    public GameObject[] enemyTypes = new GameObject[8];

    public List<GameObject> enemies = new List<GameObject>();

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = -0; i < 101; i++)
        {
            print(i);
        }
        SpawnEnemy();

        PrintNums();

        SumFirst10NaturalNumbers();

        SumNaturalNumbers(10);

        FindClosestEnemyPlayerToPlayer();
        
    }

    void SumFirst10NaturalNumbers()
    {
        int sum = 0;
        for (int i = 1; i < 11; i++)
            sum += i;
        Debug.Log(sum);
    }

    void SumNaturalNumbers(int targetNums)
    {
        int sum = 0;       
        for (int i = 1; i < targetNums + 1; i++)
            sum += i;

    }

    void PrintNums()
    {
        for (int i = 1; i < 101; i++)
            Debug.Log(i);
    }

    void SpawnEnemy()
   {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int rNum = Random.Range(0, enemyTypes.Length);
                
            GameObject enemy = Instantiate(enemyTypes[rNum], spawnPoints[i].position, spawnPoints[i].rotation);
            enemies.Add(enemy);
        }

        print("Enemy Count:" + enemies.Count);
    }

    GameObject FindClosestEnemyPlayerToPlayer()
    {
        GameObject closestEnemy = null;
        float bestDistance = float.MaxValue;

        for (int i = 0; i < enemies.Count; i++)
        {
            float distance = Vector3.Distance(player.transform.position, enemies[i].transform.position);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                closestEnemy = enemies[i];
            }
        }

        return closestEnemy;
    }
}
