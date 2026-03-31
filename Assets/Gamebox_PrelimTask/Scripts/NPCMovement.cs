using System;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private float _charSpeed;
    [SerializeField] private Transform _endPoint;
    private Vector3 _targetPos;
    private const float _targetPositionOffset = 0.2f;

    private void Start()
    {
        _targetPos = _endPoint.position;
        _targetPos.y = transform.position.y;
    }
    void Update()
    {
        float distance = Vector3.Distance(_targetPos, transform.position);
        if (distance > _targetPositionOffset)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, _charSpeed * Time.deltaTime);
        }
    }
}
