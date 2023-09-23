using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowControler : MonoBehaviour
{
	public static ThrowControler Instance;

	private Camera cam;

	[SerializeField] Throw _throw;
	[SerializeField] Trajectory trajectory;
	[SerializeField] private float pushForce = 4f;
	[SerializeField] private float maxDistance = 2f;

	private bool isDragging = false;

	private Vector2 startPoint;
	private Vector2	endPoint;
	private Vector2	direction;
	private Vector2	force;
	private float distance;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		cam = Camera.main;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			isDragging = true;
			OnDragStart();
		}
		if (Input.GetMouseButtonUp(0))
		{
			if (isDragging == false) return;

			isDragging = false;
			OnDragEnd();
		}
		if (isDragging)
		{
			OnDrag();
		}
	}

	private void OnDragStart()
	{
		if (!_throw.canMove)
		{
			isDragging = false;
			return;
		}

		startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

		trajectory.Show();
	}

	private void OnDrag()
	{
		endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
		distance = Vector2.Distance(startPoint, endPoint);
		distance = Mathf.Clamp(distance, 0, maxDistance);
		direction = (startPoint - endPoint).normalized;
		force = direction * distance * pushForce;

		Debug.DrawLine(startPoint, endPoint);

		trajectory.UpdateDots(_throw.pos, force);
	}

	private void OnDragEnd()
	{
		_throw.ActiveRigidbody();
		_throw.Push(force);

		trajectory.Hide();
	}
}
