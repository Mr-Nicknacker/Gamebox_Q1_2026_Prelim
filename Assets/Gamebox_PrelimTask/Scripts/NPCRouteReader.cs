using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Splines;

public class NPCRouteReader : MonoBehaviour
{
    [Tooltip("Array of points in which the NPC stops")]
    [SerializeField] private Transform[] _pausePointsArray;
    [Tooltip("How close the NPC needs to be to stop at a pause point")]
    [SerializeField] private const float _targetPositionOffset = 0.1f;

    private Vector3 _pausePointPosition;
    private SplineAnimate animate;
    private Spline _currentRoute;
    private int _pausePointIndex = 0;
    private float distanceBetweenPoints;
    private bool _hasPaused = false;
    private bool _hasPausePoints;
    private IReadOnlyList<Spline> _allRoutes;

    private void Awake()
    {
        InitializeRouteAnimator();
    }
    private void Start()
    {
        animate.Container.Spline = _currentRoute;
        if (_hasPausePoints) SetPausePointPosition(_pausePointIndex);
    }
    private void Update()
    {
        if (_hasPausePoints)
        {
            CheckNPCInPausePoint();
        }
        Debug.Log("Distance from Cashier to NPC: "+Vector3.Angle(transform.forward, _pausePointPosition-transform.position));
        // if passed the cashier point
        //if (Random.value < 0.5f)
        //{
        //    _currentRoute = _allRoutes[2];
        //}
    }
    public void InitializeRouteAnimator()
    {
        animate = GetComponent<SplineAnimate>();
        _allRoutes = animate.Container.Splines;
        _currentRoute = _allRoutes[0];
        _hasPausePoints = _pausePointsArray.Length > 0;
    }
    private void CheckNPCInPausePoint()
    {
        distanceBetweenPoints = Vector3.Distance(_pausePointPosition, transform.position);
        if (!_hasPaused && distanceBetweenPoints <= _targetPositionOffset)
        {
            StartCoroutine(PauseAnimation());
        }
    }
    private IEnumerator PauseAnimation()
    {
        animate.Pause();
        _hasPaused = true;
        ChangePausePointIndex();
        yield return new WaitForSeconds(3f);
        //animate.Container.Spline = animate.Container.Splines[1];
        animate.Play();
    }
    private bool HasPassedPausePoint()
    {
        // when passed a certain pause point, flip the flag to true
        var position = _currentRoute.EvaluatePosition(5f);
        return true;
    }
    private void ChangePausePointIndex()
    {
        float numberOfPausesLeft = _pausePointsArray.Length - (_pausePointIndex + 1);
        if (numberOfPausesLeft > 0 && HasPassedPausePoint())
        {
            _pausePointIndex++;
            SetPausePointPosition(_pausePointIndex);
        }
    }
    private void SetPausePointPosition(int pointIndex)
    {
        _pausePointPosition = _pausePointsArray[pointIndex].position;
        _pausePointPosition.y = transform.position.y;
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
