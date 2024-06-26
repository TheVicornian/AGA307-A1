using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum  TargetSize
{
    Small,
    Medium,
    Large,
}

public class TargetManager : MonoBehaviour
{
    public Transform[] targetSpawnpoints = new Transform[7];
    public GameObject[] targetTypes = new GameObject[2];

    public List<GameObject> targets = new List<GameObject>();
    int numIterations = 100;

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        // SpawnTarget();

        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnTarget();
        }
       // FindClosestTargetToPlayer();
    }
    
    void SpawnTarget()
    {
        int targetNum = UnityEngine.Random.Range(0, targetTypes.Length);
        int spawnNum = UnityEngine.Random.Range(0, targetSpawnpoints.Length);
        GameObject target = Instantiate(targetTypes[targetNum], targetSpawnpoints[spawnNum].position, targetSpawnpoints[spawnNum].rotation);
        //adds the newly created target to target list
        targets.Add(target);   

        /*
        //Loop from 0 until the length of our spawnPoints array
        for (int i = 0; i < targetspawnPoints.Length; i++)
        {
            int rNum = UnityEngine.Random.Range(0, targetTypes.Length);
            GameObject target = Instantiate(targetTypes[rNum], targetspawnPoints[rNum].position, targetspawnPoints[i].rotation);
            //adds the newly created target to target list
            targets.Add(target);
        }
        */

        //print total number of Targets spawned
        print("Target Count: " + targets.Count);
    }
    
    GameObject FindClosestTargetToPlayer()
    {
        GameObject closestTarget = null;
        float bestDistance = float.MaxValue;

        for (int i = 0; i < targets.Count; i++)
        {
            float distance = Vector3.Distance(player.transform.position, targets[i].transform.position);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                closestTarget = targets[i];
            }
        }
        return closestTarget;
    }
}

  

