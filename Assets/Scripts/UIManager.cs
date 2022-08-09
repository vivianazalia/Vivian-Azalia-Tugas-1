using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this; 
        }
    }

    [SerializeField] private TMP_Text lifeText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameoverText;

    private void Update()
    {
        lifeText.text = "Life : " + GameManager.instance.Life.ToString();
        scoreText.text = "Score : " + GameManager.instance.Score.ToString();

        if (GameManager.instance.IsGameOver)
        {
            gameoverText.SetActive(true);
        }
    }
}
