using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject ControlsHolder;
    public GameObject StoryHolder;
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnToStart()
    {
        SceneManager.LoadScene(0);
    }

    public void initialStart()
    {
        StoryHolder.SetActive(true);
    }

    public void ControlsButton()
    {
        ControlsHolder.SetActive(true);
    }

    public void CloseControlsButton()
    {
        ControlsHolder.SetActive(false);
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
