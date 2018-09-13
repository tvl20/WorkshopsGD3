using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public string ResourceName;
    public int Amount;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
