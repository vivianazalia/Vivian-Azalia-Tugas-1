using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickObject : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!GameManager.instance.IsGameOver)
        {
            if (gameObject.CompareTag("Player"))
            {
                GameManager.instance.GameOver(true);
            }

            if (gameObject.CompareTag("Enemy"))
            {
                GameManager.instance.Score++;
            }

            ObjectPool.Instance.AddToPool(gameObject);
        }
    }
}
