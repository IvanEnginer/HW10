using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public GameObject HealthIconPrefab;
    public List<GameObject> HealthIcons = new List<GameObject>();

    public void Setup(int maxHealth)
    {
        for(int i = 0; i < maxHealth; i++)
        {
            GameObject newIcon = Instantiate(HealthIconPrefab, transform);
            HealthIcons.Add(newIcon);
        }
    }

    public void DisplayHelth(int helth)
    {
        for(int i = 0; i < HealthIcons.Count; i++)
        {
            if(i <helth)
            {
                HealthIcons[i].SetActive(true);
            }
            else 
            { 
                HealthIcons[i].SetActive(false);
            }
        }
    }
}
