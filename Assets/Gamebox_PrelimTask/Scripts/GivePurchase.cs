using UnityEngine;

public class GivePurchase : MonoBehaviour
{
    [SerializeField] private string _clientTag;

    private Transform orderPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_clientTag))
        {
            Debug.Log("Collided");
        }
    }

}
