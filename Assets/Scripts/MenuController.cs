using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject _menuPanel;


    public void MenuOpenOnClick()
    {
        Time.timeScale = 0;
        _menuPanel.SetActive(true);
    }

    public void RestartOnClick()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitOnClick()
    {
        Application.Quit();
    }

    public void MenuCloseOnClick()
    {
        Time.timeScale = 1;
        _menuPanel.SetActive(false);
    }
}
