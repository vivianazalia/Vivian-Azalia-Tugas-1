using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{
    [SerializeField] protected float speed;
    public abstract void Move();
    public abstract void Destroy();

    public virtual void Update()
    {
        if (!GameManager.instance.IsGameOver)
        {
           Move();
        }
    }
 
    //public void IncreaseSpeed()
    //{
    //    speed += 0.5f;
    //}
}
