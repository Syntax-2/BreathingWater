using UnityEngine;
using UnityEngine.InputSystem;

public class MiddleHandManager : MonoBehaviour
{
    private Vector3 mousePos;
    public Camera ActiveCamera;
    public float moveSpeed;
    public float zOffset;
    public float yOffset;
    public float xOffset;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.z = zOffset;
        mousePos.y = mousePos.y - yOffset;
        mousePos.x = mousePos.x - xOffset;

        Vector3 targetPos = ActiveCamera.ScreenToWorldPoint(mousePos);

        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed);
    }
}

