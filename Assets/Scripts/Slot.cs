using System.Collections;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Figure _currentFigure = null;
    private bool _dragging = false;
    private Vector3 _startPosition;
    public Figure Figure { get { return _currentFigure; }}
    public bool IsEmpty { get { return _currentFigure == null; } }


    /// <summary>
    /// Спавнит фигуры внутри слота
    /// </summary>
    /// <param name="figure">Префаб для фигуры</param>
    public void Spawn(GameObject figure)
    {
        GameObject newFigure = Instantiate(figure);
        newFigure.transform.SetParent(transform, false);
        _currentFigure = newFigure.GetComponent<Figure>();
        _currentFigure.Spawn();
    }
    /// <summary>
    /// Пытается замерджить фигуры в двух слотах
    /// </summary>
    /// <param name="slot">Слот из которого мерджим</param>
    public void TryMerge(Slot slot)
    {
        if (this == slot)
        {
            return;
        }
        if(IsEmpty)
        {
            _currentFigure = slot.Figure;
            slot.DeleteFigure(false);
            _currentFigure.transform.SetParent(transform, false);
            _currentFigure.transform.localPosition = Vector3.zero;
        }
        else if(slot.Figure.Tier == _currentFigure.Tier)
        {
            _currentFigure.TierUp();
            slot.DeleteFigure(true);
        }
    }
    /// <summary>
    /// Удаляет фигуру из слота
    /// </summary>
    /// <param name="deleteObj">Удалять ли сам обьект фигуры со сцены</param>
    public void DeleteFigure(bool deleteObj)
    {
        if(deleteObj)
        {
            Destroy(_currentFigure.gameObject);
        }
        StopDrag();
        _currentFigure = null;
    }

    /// <summary>
    /// Начало перетаскивания
    /// </summary>
    public void StartDrag()
    {
        _dragging = true;
        _startPosition = _currentFigure.transform.position;
        _currentFigure.transform.SetParent(transform.parent);
        _currentFigure.transform.SetAsLastSibling();
        _currentFigure.StartDragAnim();
    }
    /// <summary>
    /// Конец перетаскивания
    /// </summary>
    public void StopDrag()
    {
        _dragging = false;
        if(_currentFigure != null)
        {
           _currentFigure.transform.position = _startPosition;
           _currentFigure.transform.SetParent(transform);
           _currentFigure.StopDragAnim();
        }
    }
    private void Update()
    {
        Drag();
    }
    /// <summary>
    /// Тащит обьект за курсором
    /// </summary>
    private void Drag()
    {
        if (_dragging)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPos.z = _startPosition.z;
            if (_currentFigure != null)
            {
                _currentFigure.transform.position = newPos;
            }
        }
    }
}
