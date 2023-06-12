using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	int timer = 0;
    public Text UITimer;
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		timer += (int)Time.deltaTime;
		int seconds = timer % 60;
        UITimer.text = seconds.ToString();
	}
}
