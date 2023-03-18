using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BirdPath : MonoBehaviour
{
    [SerializeField, Range(0.05f, 1f)] private float _pause;
    [SerializeField, Range(0.05f, 1f)] private float _lifeTime;
    private LineRenderer _path;
    private bool _isDrawing;
    private List<Vector3> _positions; 

    IEnumerator Start()
    {
        WaitForSeconds wait = new WaitForSeconds(_pause);
        _path = GetComponent<LineRenderer>();
        _isDrawing = true;
        _positions = new List<Vector3>();

        while (_isDrawing)
        {
            _positions.Add(transform.position);
            _path.positionCount = _positions.Count;
            _path.SetPositions(_positions.ToArray());
            yield return wait;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Catapult _))
            return;
        _isDrawing = false;
        Destroy(this, _lifeTime);
        Destroy(_path, _lifeTime);
    }
}
