using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerItemPickup : MonoBehaviour
{
	public List<Resource> Resources = new List<Resource>();

	private void OnTriggerEnter(Collider other)
	{
		Pickup pickup = other.gameObject.GetComponent<Pickup>();
		if (pickup != null)
		{
			foreach (Resource resource in Resources)
			{
				if (resource.Name == pickup.ResourceName)
				{
					resource.AddAmount(pickup.Amount);
				}
			}
		}
	}
}
