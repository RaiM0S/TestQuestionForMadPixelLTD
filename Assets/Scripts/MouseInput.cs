using UnityEngine;

public class MouseInput: MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            Debug.Log(hit.collider.gameObject);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed");
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Debug.Log("Unpressed");
        }
    }
}
