using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cloner : MonoBehaviour
{
    
    [SerializeField]
    private MutationStats mutationStat;
    
    private List<Light> newGeneration;
    public List<Light> NextGeneration(List<Light> oldGeneration)
    {   
       newGeneration = oldGeneration.OrderBy(light => light.Score).ToList();
       CloneLights();  
       return newGeneration;

    }

    private void CloneLights()
    {
        List<Light> clonedLights = new List<Light>();
        int lightsToClone = Mathf.RoundToInt((mutationStat.mutationRangeInPercent/100.0f)*newGeneration.Count);
        for (int i = 0; i < lightsToClone; i++)
        {
            if (newGeneration.Count == 0)
                break;

            Light original = newGeneration[0]; //first item of our list
            newGeneration.Remove(original);
            clonedLights.Add(original);
            CloneLight(original);
        }
        
        void CloneLight(Light originalLight)
        {
            int clonesLeft = mutationStat.mutationMulti;
            while(clonesLeft > 0 && newGeneration.Count  > 0)
            {
                Light clone = newGeneration[newGeneration.Count - 1];
                newGeneration.Remove(clone);
                clonedLights.Add(clone);
                clone.movement.OverridePath(originalLight.movement.GetPath());
                clonesLeft -- ;
            }
        }
        clonedLights.AddRange(newGeneration);
        newGeneration = clonedLights;
    }
   
}
