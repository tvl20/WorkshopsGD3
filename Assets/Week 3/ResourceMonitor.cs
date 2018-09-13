using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Resource))]
public class ResourceMonitor : MonoBehaviour
{
	public Text Value;
	public Text Label;

	private Resource resource;

	private Coroutine valueTicker;
	private int cachedValue;


	private void Awake()
	{
		resource = GetComponent<Resource>();
		Label.text = resource.Name;

		resource.OnValueChanged.AddListener(UpdateUI);
	}

	private void Start()
	{
		UpdateUI();
	}

	public void UpdateUI()
	{
		if (valueTicker != null)
		{
			StopCoroutine(valueTicker);
		}

		valueTicker = StartCoroutine(TickVisualValue(resource.GetQuantity()));
	}

	private void OnDisable()
	{
		cachedValue = resource.GetQuantity();
		Value.text = cachedValue.ToString();
	}

	IEnumerator TickVisualValue(int target)
	{
		while (cachedValue != target)
		{
			if (cachedValue < target)
			{
				cachedValue++;
			}
			else
			{
				cachedValue--;
			}
			Value.text = cachedValue.ToString();
			yield return null;
		}
	}
}
