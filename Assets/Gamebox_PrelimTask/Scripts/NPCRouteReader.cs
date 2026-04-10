using System.Collections;
using UnityEngine;

public class NPCRouteReader : MonoBehaviour
{
    [SerializeField] private Transform[] _routePointsArr;
    [SerializeField] private const float _targetPositionOffset = 0.2f;
    private int _routePointIndex = 0;

    //characterPosition - position of a character
    //position - where the character needs to be
    //positionOffset - how close the character needs to be to count as being in position
    public bool IsCharacterInPosition()
    {
        Vector2 characterPosition = new Vector2(transform.position.x, transform.position.z);
        Vector2 targetPosition = new Vector2(_routePointsArr[_routePointIndex].position.x, _routePointsArr[_routePointIndex].position.z);
        float distance = Vector2.Distance(characterPosition, targetPosition);

        return distance <= _targetPositionOffset;
    }
    public void GetNextIndex()
    {
        if (IsNextIndexExists())
        {
            _routePointIndex++;
        }
        else _routePointIndex = -1;
    }
    public bool IsNextIndexExists()
    {
        return _routePointIndex < _routePointsArr.Length;
    } 
}
