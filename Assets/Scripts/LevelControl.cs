using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour
{
    [SerializeField] Text _levelText;
    [SerializeField] Text _bestScore;

    void Start()
    {
        _levelText.text = "1";
        _bestScore.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    private void Update()
    {
        if (int.Parse(_levelText.text) > int.Parse( _bestScore.text))
        {
            PlayerPrefs.SetInt("HighScore", int.Parse(_levelText.text));
            _bestScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }
}
