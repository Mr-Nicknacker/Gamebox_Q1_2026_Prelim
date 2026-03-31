using System;
using UnityEngine;

public class PickupZone : MonoBehaviour
{
    [SerializeField] private string _clientTag;
    public static Action onClientReadyToPickUp;

    private Transform orderPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_clientTag))
        {
            onClientReadyToPickUp?.Invoke();
        }
    }

}
