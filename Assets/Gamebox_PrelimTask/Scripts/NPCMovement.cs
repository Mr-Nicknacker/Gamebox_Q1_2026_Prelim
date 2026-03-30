using System;
using Unity.Cinemachine;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private float _charSpeed;
    [SerializeField] private Transform _endPoint;
    private Vector3 targetPos;
    public static Action onPickUp;

    private void Start()
    {
        targetPos = _endPoint.position;
        targetPos.y = transform.position.y;
    }
    void Update()
    {
        float distance = Vector3.Distance(targetPos, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, _charSpeed * Time.deltaTime);
        //Debug.Log(distance);
        if (distance <= 0.2f)
        {
            Debug.Log("arrived");
            onPickUp?.Invoke();
            _charSpeed = 0f;
        }   
    }
}
