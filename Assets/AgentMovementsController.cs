using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovementsController : MonoBehaviour
{
    private NavMeshAgent agent;
    private GetRandomSpotOnMap getRandomSpotOnMap;

    public void SetRandomMapController(GetRandomSpotOnMap obj)
    {
        this.getRandomSpotOnMap = obj;
        SetNewDestination();
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        if(getRandomSpotOnMap != null)
        {
            SetNewDestination();
        }
    }

    private void SetNewDestination()
    {
        Vector3 pos = getRandomSpotOnMap.GetRandomGameBoardLocation();
        agent.SetDestination(pos);
    }

}
