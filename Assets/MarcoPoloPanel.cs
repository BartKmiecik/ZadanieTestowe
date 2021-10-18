using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarcoPoloPanel : MonoBehaviour
{
    [SerializeField] private GameObject textPrefab;
    [SerializeField] private GameObject marcoPoloScrollView;
    private int min = 1;
    private int max = 100;
    private bool isActive = false;

    private void Start()
    {
        marcoPoloScrollView.SetActive(false);
    }


    public void ShowMarcoPolo()
    {
        isActive = !isActive;
        if (isActive)
        {
            marcoPoloScrollView.SetActive(true);
            if (marcoPoloScrollView.transform.childCount < 1)
            {
                PopulateMarcoPoloScrollView();
            }
        }
        else
            marcoPoloScrollView.SetActive(false);
    }

    private void PopulateMarcoPoloScrollView()
    {
        for(int i = min; i <= max; i++)
        {
            GameObject temp = Instantiate(textPrefab, marcoPoloScrollView.transform);
            string marcoText = "";
            marcoText += i % 3 == 0 ? "Marko" : "";
            marcoText += i % 5 == 0 ? "Polo" : "";
            marcoText = marcoText.Length > 0 ? marcoText : i.ToString();
            temp.GetComponent<Text>().text = marcoText;
        }
    }

}
