using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawner : MonoBehaviour
{
    [SerializeField]
    private Light lightprefab;

    [SerializeField]
    private MutationStats mutationStats;

    [SerializeField]
    private int lightsToSpawn;

    private List<Light> activeLights, deadLights;

    
    private float lifeTime, counter;

    [SerializeField]
    private Goal goal;
    
    public Vector2 goalPosition;

    private Cloner cloner;

   
    private void Awake()
    {
        lifeTime = mutationStats.lifeTimeIncrease;
        counter = lifeTime;
        goalPosition = goal.transform.position;
        cloner = GetComponent<Cloner>();
    }

    private void Start()
    {
        CreateLights();
    }
    private void CreateLights()
    {
        activeLights = new List<Light>();
        deadLights = new List<Light>();
        for (int i = 0; i < lightsToSpawn; i++)
        {
            Light newLight = Instantiate (lightprefab, transform.position, Quaternion.identity);//This function makes a copy of an object in a similar way to the Duplicate command in the editor
            newLight.OnCreation(this, GetComponent<SpriteRenderer>().color);
            activeLights.Add(newLight);
            newLight.GetComponent<LightMovement>().StartMoving();
            newLight.gameObject.AddComponent<CircleCollider2D>();
            

        }

    }

    private void Respawn()
    {
        deadLights = cloner.NextGeneration(deadLights);

       
        foreach (var light in deadLights)
        {
            activeLights.Add(light);
            light.Respawn();
            light.gameObject.SetActive(true);
            

        }
        deadLights.Clear();

    }
    private void Update()
    {
        counter -= Time.deltaTime;
        if(counter<=0)
        {
            lifeTime += mutationStats.lifeTimeIncrease;
            counter = lifeTime;
            KillRemainingLights();
            Respawn();
        }
        
}
    private void KillRemainingLights()
    {
        List<Light> remainingLights = new List<Light>(activeLights);
        foreach (var light in remainingLights)
        {
            light.Die();
        }
    }
    public void LightDied(Light diedLight) 
    {
        activeLights.Remove(diedLight);
        deadLights.Add(diedLight);

    }





}
