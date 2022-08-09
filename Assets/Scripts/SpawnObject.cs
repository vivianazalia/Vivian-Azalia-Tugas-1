using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    private Vector2 pos;

    public Vector2 SpawnPos()
    {
        pos = new Vector2((Random.Range(minX, maxX)), (Random.Range(minY, maxY)));
        return pos;
    }
}
