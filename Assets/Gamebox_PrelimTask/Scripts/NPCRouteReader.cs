using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class NPCRouteReader : MonoBehaviour
{
    [SerializeField] private Transform[] _routePointsArr;
    [SerializeField] private Transform[] _pausePointsArray;

    [SerializeField] private const float _targetPositionOffset = 0.2f;
    [SerializeField] private Vector3 _targetPos;
    SplineAnimate animate;
    private int _pausePointIndex = 0;
    private bool _hasPaused=false;

    private void Awake()
    {
        animate = GetComponent<SplineAnimate>();
        Debug.Log(animate.Container.Splines.Count);
        var spline = animate.Container.Splines[1];
        var slice = new SplineSlice<Spline>();
        
    }
    private void Start()
    {
        _targetPos = _pausePointsArray[_pausePointIndex].position;
        _targetPos.y = transform.position.y;
        foreach (var knot in animate.Container.Splines[1].Knots)
        {
            Debug.Log($"{knot} is {knot.Position}");
        }
    }
    private void Update()
    {
        float distance = Vector3.Distance(_targetPos, transform.position);
        if (!_hasPaused&&distance <= 0.1f)
        {
            StartCoroutine(PauseAnimation());
        }        
    }
    private void DestroyObject()
    {
        if (!animate.IsPlaying)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator PauseAnimation()
    {
        animate.Pause();
        _hasPaused = true;
        yield return new WaitForSeconds(3f);
        animate.Container.Spline = animate.Container.Splines[1];
        animate.Play();
    }
}
