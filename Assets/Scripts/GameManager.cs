using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    public int Life { get; set; }
    public int Score { get; set; }
    public bool IsGameOver { get; private set; }

    [SerializeField] private float delayZombie;
    private float currentDelayZombie;

    [SerializeField] private float delayHuman;
    private float currentDelayHuman;

    private void Start()
    {
        Life = 3;
        Score = 0;
        currentDelayZombie = delayZombie;
        IsGameOver = false;
    }

    private void Update()
    {
        if (!IsGameOver)
        {
            if (currentDelayZombie <= 0)
            {
                //spawn object
                GameObject obj = ObjectPool.Instance.GetObject(1);
                obj.SetActive(true);
                currentDelayZombie = delayZombie;
            }

            currentDelayZombie -= Time.deltaTime;

            if (currentDelayHuman <= 0)
            {
                //spawn object
                GameObject obj = ObjectPool.Instance.GetObject(0);
                obj.SetActive(true);
                currentDelayHuman = delayHuman;
            }

            currentDelayHuman -= Time.deltaTime;
        }
        

        if(Life <= 0)
        {
            IsGameOver = true;
        }
    }

    public void GameOver(bool isOver)
    {
        IsGameOver = isOver;
    }
}
