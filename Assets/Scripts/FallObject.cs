using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObject : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        if (!GameManager.instance.IsGameOver)
        {
            Fall();
        }
    }

    private void Fall()
    {
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
    }

    public void IncrementSpeed()
    {
        speed++;
    }
}
