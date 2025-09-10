using UnityEngine;

public class ReelMechanic : MonoBehaviour
{

    public Transform reelHandleTransform;
    public Camera mainCamera;

    public float progressPerRotation = 10f;
    public float grabRadius = 50f;

    public float reelProgress = 0f;

    private bool isHoldingHandle = false;
    private float lastMouseAngle = 0f;
    private float totalAngleRotated = 0f;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 handleScreenPos = mainCamera.WorldToScreenPoint(reelHandleTransform.position);
            float distanceToHandle = Vector2.Distance(Input.mousePosition, handleScreenPos);


            Debug.Log(distanceToHandle);
            if (distanceToHandle <= grabRadius)
            {
                isHoldingHandle = true;

                Vector2 direction = (Vector2)Input.mousePosition - handleScreenPos;

                lastMouseAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                totalAngleRotated = 0f;

            }
        }

        if (Input.GetMouseButtonUp(0))
        {

            isHoldingHandle = false;

        }

        if (isHoldingHandle)
        {
            Vector2 handleScreenPos = mainCamera.WorldToScreenPoint(reelHandleTransform.position);
            Vector2 direction = (Vector2)Input.mousePosition - handleScreenPos;

            float currentAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            float deltaAngle = Mathf.DeltaAngle(lastMouseAngle, currentAngle);

            reelHandleTransform.Rotate(Vector3.forward, -deltaAngle);

            totalAngleRotated += deltaAngle;

            if(Mathf.Abs(totalAngleRotated) >= 360f)
            {
                reelProgress += progressPerRotation;
                Debug.Log("Full Rotation Completed!!!  " + reelProgress);

                totalAngleRotated -= 360f * Mathf.Sign(totalAngleRotated);
            }

            lastMouseAngle = currentAngle;

        }



    }
}
