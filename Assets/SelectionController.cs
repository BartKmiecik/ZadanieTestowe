using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionController : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Text selectedAgentName;
    [SerializeField] private Transform selectedAgentHealthsHolder;
    private Camera cam;
    private SelectionIndicator selectionIndicator;

    private void Awake()
    {
        cam = Camera.main;
        selectionIndicator = GetComponent<SelectionIndicator>();
        canvas.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f, mask))
            {
                selectionIndicator.SelectAgent(hit.collider.gameObject);
                int agentHealth = hit.collider.GetComponent<Stats>().GetCurrentHealth();
                string agentName = hit.collider.name;
                canvas.SetActive(true);
                PopulateUI(agentHealth, agentName);
                return;
            }
            selectionIndicator.DeselectAgent();
            canvas.SetActive(false);
        }
    }

    private void PopulateUI(int health, string name)
    {
        selectedAgentName.text = name;
        for(int i = 0; i < selectedAgentHealthsHolder.childCount; i++)
        {
            if(i < health)
            {
                selectedAgentHealthsHolder.GetChild(i).gameObject.SetActive(true);
            } else
            {
                selectedAgentHealthsHolder.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
