using Unity.Cinemachine;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private float _charSpeed;
    [SerializeField] private Transform _endPoint;
    private Vector3 targetPos;

    private void Start()
    {
        targetPos = _endPoint.position;
        targetPos.y = transform.position.y;
    }
    void Update()
    {
        Debug.Log(targetPos);
        float distance = Vector3.Distance(_endPoint.position, transform.position);
        if (distance > 0.2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, _charSpeed * Time.deltaTime);
        }   
    }
}
