using UnityEngine;
using UnityEngine.Splines;

[ExecuteInEditMode]
public class SplinePointsDefiner : MonoBehaviour
{

    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _lastPoint;
    [SerializeField] private SplineContainer _splineContainer;
    
    private Vector3 _firstPointPosition;
    private Vector3 _lastPointPosition;
    private void Awake()
    {
        _splineContainer = GetComponent<SplineContainer>();
        _firstPointPosition = new(_firstPoint.position.x, transform.position.y, _firstPoint.position.z);
        _lastPointPosition = new(_lastPoint.position.x, transform.position.y, _lastPoint.position.z);

    }
    private void LateUpdate()
    {
        SetFirstRoutePoint(_splineContainer, _firstPointPosition);
        SetLastRoutePoint(_splineContainer, _lastPointPosition);
        
    }
    public void SetFirstRoutePoint(SplineContainer splineContainer, Vector3 pointPositon)
    {
        Spline spline = splineContainer.Spline;
        BezierKnot firstKnot = spline[0];
        firstKnot.Position = _splineContainer.transform.InverseTransformPoint(pointPositon);
        spline.SetKnot(0, firstKnot);
    }
    public void SetLastRoutePoint(SplineContainer splineContainer, Vector3 pointPositon)
    {
        Spline spline = splineContainer.Splines[0];
        int lastKnotIndex = spline.Count - 1;
        BezierKnot lastKnot = spline[lastKnotIndex];
        
        lastKnot.Position = _splineContainer.transform.InverseTransformPoint(pointPositon);
        spline.SetKnot(lastKnotIndex, lastKnot);
    }
}
