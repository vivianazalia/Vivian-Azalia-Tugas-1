using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieZigZag : BaseCharacter, IRaycastable
{
    private float amplitudo;
    [SerializeField] private float frequency;

    public override void Destroy()
    {
        if (transform.position.y <= -6.5f)
        {
            GameManager.instance.Life--;
            GetComponentInParent<ObjectPool>().AddToPool(this.gameObject);
        }
    }

    public override void Move()
    {
        if(movementVariation == VariationType.zigzag)
        {
            amplitudo = Random.Range(3, 10);
            transform.position += Vector3.down * Time.deltaTime * speed;
            transform.position += transform.right * Mathf.Sin(Time.time * frequency) * amplitudo * Time.deltaTime;
        }
        
        Destroy();
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
