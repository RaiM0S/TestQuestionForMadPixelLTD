using UnityEngine;

public class FigureController : MonoBehaviour, IDragable
{
    private bool _dragging = false;
    private Vector3 _startPosition;
    public void StartDrag()
    {
        _dragging = true;
        _startPosition = transform.position;
    }

    public void StopDrag()
    {
        _dragging = false;
        transform.position = _startPosition;
    }

    void Update()
    {
        if(_dragging)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = _startPosition.z;
            transform.position = newPos;
        }
    }
}
