using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentSpawner : MonoBehaviour
{
    [SerializeField] private AgentsPool agentsPool;
    private GetRandomSpotOnMap getRandomSpotOnMap;
    [Header("Spawning Time Range")]
    [HideInInspector]
    public float timeRangeMin = 2;
    [HideInInspector]
    public float timeRangeMax = 10;

    private Vector3 heightOffset = new Vector3(0, 1, 0);

    private void Awake()
    {
        getRandomSpotOnMap = GetComponent<GetRandomSpotOnMap>();
    }

    void Start()
    {
        StartCoroutine(SpawnAgents());
    }

    IEnumerator SpawnAgents()
    {
        while (true)
        {
            float randomTime = Random.Range(timeRangeMin, timeRangeMax);
            Debug.Log(randomTime);
            yield return new WaitForSeconds(randomTime);
            SpawnAgent();
        }
    }

    private void SpawnAgent()
    {
        Vector3 randomBoardLocation = GetRandomLocationOnMap();
        SpawnPersonAtLocation(randomBoardLocation);
    }
    private void SpawnPersonAtLocation(Vector3 spawnPosition)
    {
        GameObject agent = agentsPool.GetAgent();
        if(agent != null)
        {
            agent.SetActive(true);
            agent.transform.position = spawnPosition + heightOffset;
        }
    }

    private Vector3 GetRandomLocationOnMap()
    {
        return getRandomSpotOnMap.GetRandomGameBoardLocation();
    }
}
