using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float nightTimer;
    public float threatLevel;
    public int sealsToAttune;
    public int sealsAttuned;

    public int minTimeForCatch = 5;
    public int maxTimeForCatch = 30;

    public bool isFishing;
    public bool GotBite;

    private bool isWaitingForBite = false;


    public GameObject WaterAnimation;
    public GameObject BiteAnimation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void StartFishing()
    {
        if (WaterAnimation != null) WaterAnimation.SetActive(true);
        if (!isWaitingForBite)
        {
            StartCoroutine("WaitingForFish");
        }
        
    }

    public void CancelFishing()
    {
        Debug.Log("Stoped Fishing");

        StopCoroutine("WaitingForFish");

        isWaitingForBite = false;
        if(WaterAnimation != null) WaterAnimation.SetActive(false);
        
    }

    IEnumerator WaitingForFish()
    {
        isWaitingForBite = true;

        if(WaterAnimation != null) WaterAnimation.SetActive(true);

        Debug.Log("counting for bite");


        int randomTime = Random.Range(minTimeForCatch, maxTimeForCatch);
        Debug.Log("Time started: " + randomTime);
        yield return new WaitForSeconds(randomTime);

        Debug.Log("GOT BITE");
        GotBite = true;
        isWaitingForBite = false;

    }

}
