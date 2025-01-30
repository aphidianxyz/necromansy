using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Currently this AI is only for a unit following it's enemy, we might want to modularize
// AI for different desired behaviors
public class UnitPathFinding : MonoBehaviour
{
    NavMeshAgent agent;
    List<GameObject> targets = new List<GameObject>();
    string targetTag; // TODO: refactor to allow functionality like a healer targetting an ally

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        targetTag = transform.tag == "Player" ? "Enemy" : "Player";
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(GetClosestTarget().transform.position);
    }

    private GameObject GetClosestTarget() 
    {
        GameObject closestTarget = null;
        // Get enemies TODO: inefficent looking for enemies with Find in the update loop
        GameObject.FindGameObjectsWithTag(targetTag, targets);

        if (targets.Capacity >= 1)
        {
            // start comparsions with the first target on the list
            closestTarget = targets[0];

            for (int i = 0; i < targets.Capacity; i++)
            {
                if (closestTarget != targets[i])
                {
                    Vector2 unitPos = transform.position;
                    float distFromCurrentClosest = Vector2.Distance(unitPos, closestTarget.transform.position);
                    float distFromNextTarget = Vector2.Distance(unitPos, targets[i].transform.position);
                    if (distFromCurrentClosest > distFromNextTarget)
                    {
                        closestTarget = targets[i];
                    }
                }
            }
        }
        
        // if there are no enemies on screen
        return closestTarget;
    }
}
