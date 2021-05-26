using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_injured : MonoBehaviour
{
	private AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			audioSource.Play();    // 按下Q键播放玩家攻击音效
		}

		}
}