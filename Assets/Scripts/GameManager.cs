using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] private int totalObjectPerWave;
    private int objectCount;

    public int Wave { get; set; }
    private float timeWave;
    public float currentTimeWave { get; private set; }
    public bool IsDelayWave { get; set; }

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        SpawnObject();

        if (IsGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            } 
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
                RestartGame();
            }
        }
        
        if(Life <= 0)
        {
            IsGameOver = true;
        }
    }

    private void Initialize()
    {
        Life = 3;
        Score = 0;
        currentDelayZombie = delayZombie;
        currentDelayHuman = delayHuman;
        Wave = 1;
        timeWave = 3;
        currentTimeWave = timeWave;
        IsGameOver = false;
        IsDelayWave = false;
    }

    public void GameOver(bool isOver)
    {
        IsGameOver = isOver;
    }

    private void SpawnObject()
    {
        if (!IsGameOver)
        {
            if (currentDelayZombie <= 0 && !IsDelayWave)
            {
                GameObject obj = ObjectPool.Instance.GetObject(1);
                obj.SetActive(true);
                currentDelayZombie = delayZombie;

                objectCount++;
                if (objectCount > totalObjectPerWave)
                {
                    IsDelayWave = true;
                    Wave++;
                    IncreaseSpeedFallObject();
                }
            }

            currentDelayZombie -= Time.deltaTime;

            if (currentDelayHuman <= 0 && !IsDelayWave)
            {
                GameObject obj = ObjectPool.Instance.GetObject(0);
                obj.SetActive(true);
                currentDelayHuman = delayHuman;
            }

            currentDelayHuman -= Time.deltaTime;

            DelayWave();
        }
    }

    private void IncreaseSpeedFallObject()
    {
        foreach(GameObject obj in ObjectPool.Instance.zombies)
        {
            obj.GetComponent<FallObject>().IncreaseSpeed();
        }

        foreach (GameObject obj in ObjectPool.Instance.humans)
        {
            obj.GetComponent<FallObject>().IncreaseSpeed();
        }
    }

    private void DelayWave()
    {
        if (IsDelayWave)
        {
            ObjectPool.Instance.AddAllObjectToPool();
            if (currentTimeWave <= 0)
            {
                currentTimeWave = timeWave;
                objectCount = 0;
                IsDelayWave = false;
            }

            currentTimeWave -= Time.deltaTime;
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
