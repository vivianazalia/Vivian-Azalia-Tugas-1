using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Human : BaseCharacter, IRaycastable, IPointerClickHandler
{
    public override void Update()
    {
        base.Update();
        OnClickObject();
    }

    public override void Move()
    {
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        Destroy();
    }

    public override void Destroy()
    {
        if(transform.position.y <= -6.5f)
        {
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
                GameManager.instance.GameOver(true);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
