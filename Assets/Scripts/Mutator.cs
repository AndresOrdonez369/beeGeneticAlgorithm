using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutator : MonoBehaviour
{

    [SerializeField]
    private MutationStats mutationStats;

    public void MutatePath(List<Vector2> path)
    {
        float changeRange = mutationStats.mutationRange;

        for (int i = 0; i < path.Count; i++)
        {
            path[i] = Random.insideUnitCircle * changeRange + path[i];
        }
    }
}
