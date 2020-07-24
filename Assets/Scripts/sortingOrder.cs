using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortingOrder : MonoBehaviour
{
    public int sortingOrd = 0;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (sprite)
            sprite.sortingOrder = sortingOrd;
    }
}
