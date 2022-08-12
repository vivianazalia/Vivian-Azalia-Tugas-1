using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : BaseCharacter, IRaycastable
{
    public override void Update()
    {
        base.Update();
        OnClickObject();
    }

    public override void Move()
    {
        if (movementVariation == VariationType.vertical)
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
        
        Destroy();
    }

    public override void Destroy()
    {
        if (transform.position.y <= -6.5f)
        {
            GameManager.instance.Life--;
            GetComponentInParent<ObjectPool>().AddToPool(this.gameObject);
        }
    }

    public void OnClickObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (ray.collider != null)
            {
                GetComponentInParent<ObjectPool>().AddToPool(ray.collider.gameObject);
                GameManager.instance.Score++;
            }
        }
    }
}
