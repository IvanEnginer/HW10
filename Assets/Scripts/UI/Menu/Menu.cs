using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject ButtonMenu;
    public GameObject MenuWindow;

    public MonoBehaviour[] CompanetsToDisabel; 

    public void OpenMenuWindow() 
    { 
        ButtonMenu.SetActive(false);
        MenuWindow.SetActive(true);

        for(int i = 0; i < CompanetsToDisabel.Length; i++ )
        {
            CompanetsToDisabel[i].enabled= false;
        }

        Time.timeScale = 0.01f;
    }

    public void CloseMenuWindow()
    {
        ButtonMenu.SetActive(true);
        MenuWindow.SetActive(false);

        for (int i = 0; i < CompanetsToDisabel.Length; i++)
        {
            CompanetsToDisabel[i].enabled = true;
        }

        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
