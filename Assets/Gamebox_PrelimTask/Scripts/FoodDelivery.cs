using UnityEngine;
using DG.Tweening;
using System;
public class FoodDelivery : MonoBehaviour
{
    [SerializeField] private Transform _pickupPoint;
    private Transform _initialTransform;
    [Header("Animation Parameters")]
    [SerializeField] private float _animationJumpPower;
    [SerializeField] private float _animationSpeed;
    [SerializeField] private int _animationJumpsNumber;
    private Wallet _playerWallet;
    private void Start()
    {
        _initialTransform = transform;
        _playerWallet = new Wallet();
    }
    private void GiveFood()
    {
        Sequence giveFoodAnimation = DOTween.Sequence();
        Vector3 targetPosition = _pickupPoint.position;

        targetPosition.y = transform.position.y;

        giveFoodAnimation.Append(transform.DOJump(targetPosition, _animationJumpPower, _animationJumpsNumber, _animationSpeed))
            .Append(transform.DOScale(0,0.2f))
            .OnComplete(() => {
                gameObject.SetActive(false);
                transform.position = _initialTransform.position;
                transform.localScale = _initialTransform.localScale;
                _playerWallet.RemoveResource(20);
                giveFoodAnimation.Kill();
            });
    }
    private void OnEnable()
    {
        Payment.OnMoneyPaid += GiveFood;
    }
    private void OnDisable()
    {
        Payment.OnMoneyPaid -= GiveFood;
    }
}
