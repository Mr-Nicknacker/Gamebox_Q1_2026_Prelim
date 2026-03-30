using DG.Tweening;
using UnityEngine;

public class GivePurchase : MonoBehaviour
{
    [SerializeField]private string _clientTag;
    //[SerializeField] private Transform _orderSpawnTransform;
    [SerializeField] private GameObject _foodObj;
    [SerializeField] private float _animationSpeed=2f;
    [SerializeField] private float _animationJumpPower=1.5f;
    [SerializeField] private int _animationJumpsNumber=1;
    private Transform orderPosition;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.CompareTag(_clientTag));
        if (other.CompareTag(_clientTag))
        {
            Debug.Log("client detected");
            if (other.attachedRigidbody.linearVelocity == Vector3.zero)
            {
                GiveFood(other.transform);
            }
            
        }
    }
    private void GiveFood(Transform target)
    {
        var targetPosition = transform.position;
        targetPosition.y = _foodObj.transform.position.y;
        //_foodObj.transform.DOMove(transform.position, _animationSpeed).SetEase(Ease.Linear);
        _foodObj.transform.DOJump(transform.position, _animationJumpPower, _animationJumpsNumber, _animationSpeed);
    }
}
