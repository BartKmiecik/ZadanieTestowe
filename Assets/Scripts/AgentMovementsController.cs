using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovementsController : MonoBehaviour
{
    private NavMeshAgent agent;
    private GetRandomSpotOnMap getRandomSpotOnMap;
    private float deeleyTesting = 1.5f;
    private Vector3 destination;
    private float stoppingDistance = 6f;

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
        StopAllCoroutines();
        if(getRandomSpotOnMap != null)
        {
            SetNewDestination();
        }
    }

    private void SetNewDestination()
    {
        if (agent.isActiveAndEnabled)
        {
            destination = getRandomSpotOnMap.GetRandomGameBoardLocation();
            agent.SetDestination(destination);
            StopAllCoroutines();
            StartCoroutine(CheckIfDestinationReached());
        }
    }

    IEnumerator CheckIfDestinationReached()
    {
        while (true)
        {
            yield return new WaitForSeconds(deeleyTesting);
            if(Vector3.Distance(destination, transform.position) <= stoppingDistance)
            {
                SetNewDestination();
            }
        }
    }

}
