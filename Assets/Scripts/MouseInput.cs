using UnityEngine;

public class MouseInput: MonoBehaviour
{
    // здесь можно бы вывести интерфейс и работать с ним для обьектов на которые будем наводиться в будущем, но пока для реализации задания не нужно
    private Slot onMouseObj = null;

    
    private void Update()
    {
        GetInputs();
    }
    /// <summary>
    /// Обработчик нажатий мыши
    /// </summary>
    private void GetInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out onMouseObj))
                {
                    onMouseObj.StartDrag();
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (onMouseObj != null)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    if (hit.collider.TryGetComponent(out Slot newSlot))
                    {
                        newSlot.TryMerge(onMouseObj);
                    }
                }
                onMouseObj.StopDrag();
                onMouseObj = null;
            }
        }
    }
}
