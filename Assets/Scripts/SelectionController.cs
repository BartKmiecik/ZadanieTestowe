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
    private GameObject selectedAgent;
    private Camera cam;
    private SelectionIndicator selectionIndicator;
    private Delegator delegator;

    private void Awake()
    {
        delegator = FindObjectOfType<Delegator>();
        cam = Camera.main;
        selectionIndicator = GetComponent<SelectionIndicator>();
        canvas.SetActive(false);
        delegator.updateUI += UpdateUI;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f, mask))
            {
                selectedAgent = hit.collider.gameObject;
                selectionIndicator.SelectAgent(selectedAgent);
                canvas.SetActive(true);
                UpdateUI();
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

    public void UpdateUI()
    {
        int agentHealth = selectedAgent.GetComponent<Stats>().GetCurrentHealth();
        if(agentHealth > 0)
        {
            string agentName = selectedAgent.name;
            PopulateUI(agentHealth, agentName);
        } else
        {
            selectionIndicator.DeselectAgent();
            canvas.SetActive(false);
        }
    }

}
