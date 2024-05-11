using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
	private Vector3 randomPos;

	private GameObject target;

	private NavMeshAgent agent;

	public AudioSource groanSFX;

	static public Animator anim;

	private bool isWalking;
	private bool isRunning;
	private void Start()
	{
		randomPos = transform.position;
		target = GameObject.FindGameObjectWithTag("Player");
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		WalkToRandomSpot();
	}

	private void Update()
	{
		if (MapBulder.instance.zombiesCanMove)
		{
			if (Vector3.Distance(transform.position, target.transform.position) <= 5)
			{
				ChasePlayer();
			}
			else if (isRunning)
			{
				WalkToRandomSpot();
			}

			if (isWalking)
			{
				if (Vector3.Distance(transform.position, randomPos) <= 1)
				{
					WalkToRandomSpot();
				}
			}

			if (Vector3.Distance(transform.position, target.transform.position) <= 1)
			{
				anim.SetTrigger("attack");
			}
		}
	}

	private void ChasePlayer()
	{
		agent.SetDestination(target.transform.position);

		if (!isRunning) 
		{
			groanSFX.Play();
			isRunning = true;
			isWalking = false;
			agent.speed = 2;
			anim.SetBool("isRunning", isRunning);
			anim.SetBool("isWalking", isWalking);
		}
	}

	private void WalkToRandomSpot()
	{
		agent.speed = 0.75f;
		randomPos = MapBulder.instance.GetRandomPos();

		agent.SetDestination(randomPos);

		isRunning = false;
		isWalking = true;
		anim.SetBool("isRunning", isRunning);
		anim.SetBool("isWalking", isWalking);
	}
}
