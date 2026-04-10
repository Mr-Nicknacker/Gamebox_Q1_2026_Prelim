using DG.Tweening;
using UnityEngine;
public class FoodDelivery : MonoBehaviour
{
    [SerializeField] private Transform _pickupPoint;
    private Vector3 _initialPosition;
    private Vector3 _initialScale;
    [Header("Animation Parameters")]
    [SerializeField] private float _animationJumpPower;
    [SerializeField] private float _animationSpeed;
    [SerializeField] private int _animationJumpsNumber;
    private void Start()
    {
        _initialPosition = transform.position;
        _initialScale = transform.localScale;
    }
    private void GiveFood()
    {
        Sequence giveFoodAnimation = DOTween.Sequence();
        Vector3 targetPosition = _pickupPoint.position;

        targetPosition.y = transform.position.y;//можно убрать

        giveFoodAnimation.Append(transform.DOJump(targetPosition, _animationJumpPower, _animationJumpsNumber, _animationSpeed))
            .Append(transform.DOScale(0, 0.2f))
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
                transform.position = _initialPosition;
                transform.localScale = _initialScale;
                giveFoodAnimation.Kill();
            });
    }
    private void OnEnable()
    {
        CharacterPay.OnMoneyPaid += GiveFood;
    }
    private void OnDisable()
    {
        CharacterPay.OnMoneyPaid -= GiveFood;
    }
}
