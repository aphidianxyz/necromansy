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
	private List<GameObject> targets = new List<GameObject>{};
	private GameObject currentTarget = null;
	private bool hasTarget = false;




	private void Start()
	{
		if (gameObject.CompareTag("Enemy"))
		{

			opposingTag = "Player";
		}
	}

	private void Update()
	{
		if(!hasTarget && targets.Count > 0){
				currentTarget = targets[0];
				hasTarget = true;
			}
		else if (hasTarget)
		{
			attackTimer += Time.deltaTime;
			if (attackTimer >= unitStats.timeBetweenAttacks)
			{
				currentTarget.GetComponent<unitStats>().TakeDamage(unitStats.damage);
				attackTimer = 0f;
				Debug.Log(gameObject.name + " Attacks " + currentTarget.name);
			}
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (!collision.isTrigger && collision.CompareTag(opposingTag))
		{
			targets.Add(collision.gameObject);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject == currentTarget){
			currentTarget = null;
			hasTarget = false;
		}
		targets.Remove(other.gameObject);
	}


}
