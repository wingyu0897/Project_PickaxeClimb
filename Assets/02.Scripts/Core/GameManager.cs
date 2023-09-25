using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

	public ThrowController throwContoller;

	public UnityEvent OnClearGame;

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

	public void ClearGame()
	{
		print("ClearGame");
		OnClearGame?.Invoke();
	}
}
