using UnityEngine;

public class MouseInput: MonoBehaviour
{
    private IDragable dragObj = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                if(hit.collider.TryGetComponent(out dragObj))
                {
                    dragObj.StartDrag();
                }
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            if(dragObj != null)
            {
                dragObj.StopDrag();
                dragObj = null;
            }
        }
    }
}
