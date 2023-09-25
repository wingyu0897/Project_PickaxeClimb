using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.attachedRigidbody.gameObject.CompareTag("Player"))
		{
			GameManager.Instance?.ClearGame();
		}
	}
}
