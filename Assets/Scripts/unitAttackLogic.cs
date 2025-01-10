using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class unitAttackLogic : MonoBehaviour
{
    public CircleCollider2D attackRangeCircle;
	
	public unitStats unitStats;
	private float attackTimer = 0f;

	private string opposingTag = "Enemy";
	private GameObject target;

	private List<Collider2D> colisions = new List<Collider2D>{};
	private void Start()
	{
		if (gameObject.CompareTag("Enemy")) {

			opposingTag = "Player";
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
		if (!collision.isTrigger && collision.CompareTag(opposingTag))
		{
			target = collision.gameObject;
			Debug.Log(target);
		}
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		
		if (collision.gameObject == target)
		{
			attackTimer += Time.deltaTime;
			if (attackTimer >= unitStats.timeBetweenAttacks)
			{
				target.GetComponent<unitStats>().TakeDamage(unitStats.damage);
				attackTimer = 0f;
				Debug.Log("Attack");
			}
		}
	}

}
