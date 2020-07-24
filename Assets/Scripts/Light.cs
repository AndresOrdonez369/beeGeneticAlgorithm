using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    private LightSpawner mySpawner;
    public LightMovement movement;
    private SpriteRenderer spriteRenderer;
   
    private Mutator mutator;
    
    private float score;

    public float Score { get => score; private set => score = value; }

    private void Awake()
    {
        movement = GetComponent<LightMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        mutator = GetComponent<Mutator>();
    }
    public void OnCreation(LightSpawner spawnedFrom, Color color)
    {
        mySpawner = spawnedFrom;
        movement.startPosition = mySpawner.transform.position;
        spriteRenderer.color = color;    
    }

 
    internal void Respawn()
    {
        movement.StartMoving();
        mutator.MutatePath(movement.GetPath());
    }
    public void Die()
    {
        Score = Vector2.Distance(transform.position, mySpawner.goalPosition);
        mySpawner.LightDied(this);
        gameObject.SetActive(false);
    }


}
