using UnityEngine;

public class Slot : MonoBehaviour
{
    private Figure _currentFigure = null;

    public bool CanSpawn { get { return _currentFigure == null; } }

    public void Spawn(GameObject figure)
    {
        GameObject newFigure = Instantiate(figure);
        newFigure.transform.SetParent(transform, false);
        _currentFigure = newFigure.GetComponent<Figure>();
    }
}
