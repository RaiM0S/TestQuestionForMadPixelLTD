using UnityEngine;

public class Slot : MonoBehaviour, IDragable
{
    private Figure _currentFigure = null;
    private bool _dragging = false;
    private Vector3 _startPosition;
    public Figure Figure { get { return _currentFigure; } private set { } }
    public bool IsEmpty { get { return _currentFigure == null; } }
    
    public void Spawn(GameObject figure)
    {
        GameObject newFigure = Instantiate(figure);
        newFigure.transform.SetParent(transform, false);
        _currentFigure = newFigure.GetComponent<Figure>();
    }

    public void TryMerge(Slot slot)
    {
        if(IsEmpty)
        {
            _currentFigure = slot.Figure;
            slot.DeleteFigure();
            _currentFigure.transform.SetParent(transform, false);
            _currentFigure.transform.localPosition = Vector3.zero;
        }
    }
    public void DeleteFigure()
    {
        _currentFigure = null;
    }
    public void StartDrag()
    {
        _dragging = true;
        _startPosition = _currentFigure.transform.position;
    }

    public void StopDrag()
    {
        _dragging = false;
        if(_currentFigure != null)
        {
           _currentFigure.transform.position = _startPosition;
        }
    }

    private void Update()
    {
        if (_dragging)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = _startPosition.z;
            _currentFigure.transform.position = newPos;
        }
    }
}
