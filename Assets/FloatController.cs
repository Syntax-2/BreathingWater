using UnityEngine;

public class FloatController : MonoBehaviour
{

    public ReelMechanic reelMechanic;

    public Transform castPosition;

    public Transform reeledInPosition;

    public float maxReelProgress = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float currentProgress = reelMechanic.reelProgress;

        float normalizedProgress = currentProgress / maxReelProgress;

        normalizedProgress = Mathf.Clamp01(normalizedProgress);

        transform.position = Vector3.Lerp(castPosition.position, reeledInPosition.position, normalizedProgress);




    }
}
