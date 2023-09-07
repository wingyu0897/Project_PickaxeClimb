using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;

	private void LateUpdate()
	{
		transform.position = new Vector3(transform.position.x, target.position.y, -10);
	}
}
