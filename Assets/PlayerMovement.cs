using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 5;

	private PlayerInput gestureInput;
	private Vector3 targetPosition;

	private void Start ()
	{
		gestureInput = GetComponent<PlayerInput>();
		targetPosition = this.transform.position;
	}
	
	private void Update ()
	{
		Tap input = gestureInput.GetInput();

		if (input != null)
		switch (input.Gesture)
		{
				case TapInputGesture.Tap:
					Debug.Log("Input: Tap");

					RaycastHit hit;
					Ray ray = Camera.main.ScreenPointToRay(input.originPosition);

					if (Physics.Raycast(ray, out hit))
					{
						targetPosition = hit.point;
					}

					break;
		}

		if (Vector3.Distance(this.transform.position, targetPosition) > 0.05f)
		{
			this.transform.Translate((targetPosition - this.transform.position).normalized * speed * Time.deltaTime);
		}
	}
}
