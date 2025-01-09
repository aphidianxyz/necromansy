using UnityEngine;

public class unitStats : MonoBehaviour 
{
    public float health = 30f;
    public float damage = 5f;
    public float attackRange = 4f;
    public float moveSpeed = 2f;
    bool isRanged = false;
    public float cost = 2f;
    public float bloodLevel = 0f;

    void Start()
    {
				GameObject rangeIndicator = GameObject.Find("AttackRange");
        SphereCollider rangeCollider = rangeIndicator.GetComponent<SphereCollider>();
        rangeCollider.radius = attackRange;
    }
}
