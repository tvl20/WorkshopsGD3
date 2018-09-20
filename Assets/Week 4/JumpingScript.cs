using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingScript : MonoBehaviour
{
	public Animator cubeAnimator;
	public string parameterName;


	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			cubeAnimator.SetBool(parameterName, true);
		}
		else if (Input.GetKeyUp(KeyCode.Space))
		{
			cubeAnimator.SetBool(parameterName, false);
		}
	}
}
