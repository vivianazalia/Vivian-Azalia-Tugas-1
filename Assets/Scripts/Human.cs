using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : BaseCharacter
{
    //void Update()
    //{
    //    if (!GameManager.instance.IsGameOver)
    //    {
    //        Move();
    //    }
    //}

    public override void Move()
    {
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
    }
}
