using UnityEngine;

public class ReelMechanic : MonoBehaviour
{

    public Transform handTransform;
    public Transform handleTransform;
    public Transform reelHandleTransform;
 
    public Vector3 handleOffset;

    public Camera mainCamera;


    public float maxReelProgress = 100;
    public float progressPerRotation = 10f;
    public float grabRadius = 50f;

    public float reelProgress = 0f;

    private bool isHoldingHandle = false;
    private float lastMouseAngle = 0f;
    private float totalAngleRotated = 0f;

    public GameObject runeFragmentsPrefab;

    private MiddleHandManager handManager;
    public GameManager gameManager;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(handTransform != null)
        {
            handManager = handTransform.GetComponent<MiddleHandManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 handleScreenPos = mainCamera.WorldToScreenPoint(reelHandleTransform.position);
            float distanceToHandle = Vector2.Distance(Input.mousePosition, handleScreenPos);


            if (gameManager.isFishing)
            {
                Debug.Log("WorksFromREEELMECHANICfishing");
                gameManager.StartFishing();
            }
            else
            {
                Debug.Log("WorksFromREEELMECHANICnotfishing");
                gameManager.CancelFishing();
            }

            Debug.Log(distanceToHandle);
            if (distanceToHandle <= grabRadius)
            {
                isHoldingHandle = true;

                handManager.HandClosed();

                if (handManager != null) handManager.enabled = false;

                Vector2 direction = (Vector2)Input.mousePosition - handleScreenPos;
                lastMouseAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                totalAngleRotated = 0f;

            }

            

        }

        if (Input.GetMouseButtonUp(0))
        {

            isHoldingHandle = false;
            handManager.HandOpen();
            if (handManager != null) handManager.enabled = true;

            

        }

        if (isHoldingHandle)
        {

            handTransform.position = handleTransform.position - handleOffset; 


            Vector2 handleScreenPos = mainCamera.WorldToScreenPoint(reelHandleTransform.position);
            Vector2 direction = (Vector2)Input.mousePosition - handleScreenPos;
            float currentAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            float deltaAngle = Mathf.DeltaAngle(lastMouseAngle, currentAngle);


            reelHandleTransform.Rotate(-(Vector3.forward), -deltaAngle);
            

            float progressThisFrame = (deltaAngle / 360f) * progressPerRotation;

            reelProgress += progressThisFrame;

            reelProgress = Mathf.Clamp(reelProgress, 0f, maxReelProgress);

            lastMouseAngle = currentAngle;




        }


        if (reelProgress <= 1f)
        {
            Debug.Log("Fishing");
            gameManager.isFishing = true;
        }
        else
        {
            Debug.Log("NOTFishing");
            gameManager.isFishing = false;
        }

        if (reelProgress >= 99f)
        {
            Debug.Log("Reeled in");
            
        }




    }

    public void CastLine()
    {

    }

}
