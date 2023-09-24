using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rigid;
    [HideInInspector] public Vector3 pos => transform.position;

	[SerializeField] private float stopVelocity = 0.01f;
	[SerializeField] private float coolTime = 0.5f;
	private float stopTime = 0;

	public bool canMove = false;

	private void Awake()
	{
		rigid = GetComponent<Rigidbody2D>();
		DesactiveRigidbody();
	}

	private void Update()
	{
		if (!canMove)
			CheckCanMove();
	}

	private void CheckCanMove()
	{
		if (rigid.velocity.sqrMagnitude <= stopVelocity)
		{
			stopTime += Time.deltaTime;
		}

		if (stopTime >= coolTime)
		{
			DesactiveRigidbody();
			canMove = true;
		}
	}

	public void Push(Vector2 force)
	{
		rigid.AddForce(force, ForceMode2D.Impulse);
		canMove = false;
		stopTime = 0;
	}

	public void ActiveRigidbody()
	{
		rigid.isKinematic = false;
		canMove = false;
		stopTime = 0;
	}

	public void DesactiveRigidbody()
	{
		rigid.velocity = Vector3.zero;
		rigid.angularVelocity = 0;
		rigid.isKinematic = true;
	}
}
