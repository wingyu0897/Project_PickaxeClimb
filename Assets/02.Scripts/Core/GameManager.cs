using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

	public ThrowController throwContoller;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Debug.LogError("GameManager Singletone Creation Error");
			Destroy(gameObject);
		}
	}

	public void StartGame()
	{
		throwContoller.EnableControl(true);
	}
}
