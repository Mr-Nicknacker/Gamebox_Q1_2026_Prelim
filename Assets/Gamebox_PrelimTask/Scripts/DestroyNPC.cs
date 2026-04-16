using UnityEngine;

public class DestroyNPC : MonoBehaviour
{
    [SerializeField] private string _npcTag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_npcTag))
        {
            Destroy(other.gameObject);
        }
    }
}
