using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private GameObject canvas;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
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
                canvas.SetActive(true);
                return;
            }

            canvas.SetActive(false);
        }
    }
}
