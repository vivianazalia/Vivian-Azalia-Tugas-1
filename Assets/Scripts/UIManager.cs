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
    [SerializeField] private TMP_Text delayText;
    [SerializeField] private TMP_Text waveText;
    [SerializeField] private GameObject enterToStartText;
    [SerializeField] private GameObject tutorial;

    private void Start()
    {
        enterToStartText.SetActive(true);
        StartCoroutine(SpawnTutorial());
    }

    private void Update()
    {
        lifeText.text = "Life : " + GameManager.instance.Life.ToString();
        scoreText.text = "Score : " + GameManager.instance.Score.ToString();
        waveText.text = "Wave " + GameManager.instance.Wave.ToString();

        if (GameManager.instance.IsGameOver)
        {
            enterToStartText.SetActive(true);
        }
        else
        {
            enterToStartText.SetActive(false);
        }

        if (GameManager.instance.IsDelayWave)
        {
            delayText.gameObject.SetActive(true);
            delayText.text = Mathf.CeilToInt(GameManager.instance.currentTimeWave).ToString();
        }
        else
        {
            delayText.gameObject.SetActive(false);
        }
    }

    private IEnumerator SpawnTutorial()
    {
        yield return new WaitForSeconds(2f);
        tutorial.SetActive(false);
    }
}
