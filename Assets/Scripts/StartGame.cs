using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] Text _startText;
    [SerializeField] Button _startButton;

    private void Start()
    {
        Time.timeScale = 0;
    }


    public void StartOnclick()
    {
        Time.timeScale = 1;
        Debug.Log("Button Basildi");
        _startText.enabled = false;
        StartCoroutine(ButtonFalse());
        //_startButton.interactable = false;
    }

    public IEnumerator ButtonFalse()
    {
        yield return new WaitForSeconds(0.2f);
        _startButton.enabled = false;
        _startButton.image.enabled = false;
        _startButton.interactable = false;
    }
}
