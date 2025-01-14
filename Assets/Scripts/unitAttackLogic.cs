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
	private List<GameObject> targets = new List<GameObject> { };
	private GameObject currentTarget = null;
	private bool hasTarget = false;

	public GameObject projectile = null;




	private void Start()
	{
		if (gameObject.CompareTag("Enemy"))
		{

			opposingTag = "Player";
		}

		if (unitStats.isRanged){
			projectile = unitStats.projectile;
		}
	}

	private void Update()
	{	
		//Aquire target if none and targets in list
		if (!hasTarget && targets.Count > 0)
		{
			currentTarget = targets[0];
			hasTarget = true;
		}
		//If there is a target start atacking
		else if (hasTarget)
		{
			attackTimer += Time.deltaTime;
			if (attackTimer >= unitStats.timeBetweenAttacks)
			{
				if (!unitStats.isRanged)
				{
					currentTarget.GetComponent<unitStats>().TakeDamage(unitStats.damage);
					Debug.Log(gameObject.name + " Attacks " + currentTarget.name);
				}
				else
				{
					GameObject projectileSpawned = Instantiate(projectile, transform.position,transform.rotation);
					projectileSpawned.GetComponent<GenProjectile>().SetTarget(currentTarget.transform);
				}

				attackTimer = 0f;

			}
		}
	}
	//Gathers targets that enter attack range
	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (!collision.isTrigger && collision.CompareTag(opposingTag))
		{
			targets.Add(collision.gameObject);
		}
	}

	//If target leaves radius remove it from list and get another target if it was
	//current target
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == currentTarget)
		{
			currentTarget = null;
			hasTarget = false;
		}
		targets.Remove(other.gameObject);
	}


}
