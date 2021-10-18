using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentSpawner : MonoBehaviour
{
    [SerializeField] private AgentsPool agentsPool;
    [Header("Spawning Time Range")]
    [HideInInspector]
    public float timeRangeMin = 2;
    [HideInInspector]
    public float timeRangeMax = 10;

    private Vector3 heightOffset = new Vector3(0, 1, 0);

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
        Vector3 randomBoardLocation = GetRandomGameBoardLocation();
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

    private Vector3 GetRandomGameBoardLocation()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        int maxIndices = navMeshData.indices.Length - 3;

        // pick the first indice of a random triangle in the nav mesh
        int firstVertexSelected = UnityEngine.Random.Range(0, maxIndices);
        int secondVertexSelected = UnityEngine.Random.Range(0, maxIndices);

        // spawn on verticies
        Vector3 point = navMeshData.vertices[navMeshData.indices[firstVertexSelected]];

        Vector3 firstVertexPosition = navMeshData.vertices[navMeshData.indices[firstVertexSelected]];
        Vector3 secondVertexPosition = navMeshData.vertices[navMeshData.indices[secondVertexSelected]];

        // eliminate points that share a similar X or Z position to stop spawining in square grid line formations
        if ((int)firstVertexPosition.x == (int)secondVertexPosition.x || (int)firstVertexPosition.z == (int)secondVertexPosition.z)
        {
            point = GetRandomGameBoardLocation(); // re-roll a position - I'm not happy with this recursion it could be better
        }
        else
        {
            // select a random point on it
            point = Vector3.Lerp(firstVertexPosition, secondVertexPosition, UnityEngine.Random.Range(0.05f, 0.95f));
        }

        return point;
    }
}
