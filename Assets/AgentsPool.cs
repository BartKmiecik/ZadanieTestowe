using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentsPool : MonoBehaviour
{
    [SerializeField] private int maxNumberOfAgents;
    [SerializeField] private GameObject agentPrefab;
    private List<GameObject> agentsList = new List<GameObject>();
    private int startingPoolCount = 5;

    private void Start()
    {
        for(int i = 0; i < startingPoolCount; i++)
        {
            CreateAndAddNewAgent();
        }
    }

    public GameObject GetAgent()
    {
        //Return inactive agent from pool
        for(int i = 0; i < agentsList.Count; i++)
        {
            if (!agentsList[i].activeInHierarchy)
            {
                return agentsList[i];
            }
        }

        //Create and return new agent
        if(agentsList.Count < maxNumberOfAgents)
        {
            return CreateAndAddNewAgent();
        }

        //Max numbers of agents
        return null;
    }

    private GameObject CreateAndAddNewAgent()
    {
        GameObject temp = Instantiate(agentPrefab, transform);
        temp.SetActive(false);
        agentsList.Add(temp);
        return temp;
    }
}
