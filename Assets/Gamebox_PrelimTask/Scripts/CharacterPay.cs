using DG.Tweening;
using System;
using UnityEngine;

public class CharacterPay : MonoBehaviour
{
    [SerializeField] private Transform _cashRegisterPoint;
    [SerializeField] private float _animationJumpPower;
    [SerializeField] private float _animationSpeed;
    [SerializeField] private int _animationJumpsNumber;
    [SerializeField] private float _coinRotationSpeed;

    // добавить скриптбл обжект со списком еды в кафе: просто список цен, без разных объектов

    private PlayerWallet _playerWallet;
    private Vector3 _initialScale;    
    public static Action OnMoneyPaid;

    private void Start()
    {
        _initialScale = transform.localScale;
        transform.localScale = Vector3.zero;
        _playerWallet = new PlayerWallet();
    }
    private void OnEnable()
    {
        PickupZone.onClientReadyToPickUp += GiveMoney;
    }
    private void OnDisable()
    {
        PickupZone.onClientReadyToPickUp -= GiveMoney;
    }
    private void GiveMoney()
    {

        Sequence giveMoneyAnimation = DOTween.Sequence();
        Vector3 targetPosition = _cashRegisterPoint.position;

        gameObject.SetActive(true);
        giveMoneyAnimation.Append(transform.DOScale(_initialScale, 0.1f))
            .Append(transform.DOJump(targetPosition, _animationJumpPower, _animationJumpsNumber, _animationSpeed))
            .Join(transform.DORotate(Vector3.up * 720f, _coinRotationSpeed, RotateMode.FastBeyond360))
                .Append(transform.DOScale(0, 0.1f))
                .OnComplete(() =>
                {
                    gameObject.SetActive(false);
                    OnMoneyPaid?.Invoke();
                    PayForFood(10);
                    giveMoneyAnimation.Kill();
                });
    }
    private void PayForFood(int foodPrice)
    {
        _playerWallet.AddResource(foodPrice);
    }

}
