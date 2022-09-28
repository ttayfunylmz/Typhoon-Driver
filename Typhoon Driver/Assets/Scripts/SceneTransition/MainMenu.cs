using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadSkinSelectionScene()
    {
        SceneManager.LoadScene("SkinSelection");
    }

    public void LoadAboutScene()
    {
        SceneManager.LoadScene("About");
    }

    public void QuitApplication()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
