using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
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

    public bool didCatch;

    private bool isWaitingForBite = false;


    public GameObject WaterAnimation;
    public GameObject BiteAnimation;

    public List<GameObject> fishedItems;
    public Transform spawnPoint;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFishing = true;
        GotBite = false;
        didCatch = false;
        StartFishing();
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void StartFishing()
    {
        if (WaterAnimation != null) WaterAnimation.SetActive(true);
        if (!isWaitingForBite && !GotBite)
        {
            StartCoroutine("WaitingForFish");
        }

        if (GotBite)
        {
            didCatch = true;
            if (BiteAnimation != null) BiteAnimation.SetActive(false);
            if (WaterAnimation != null) WaterAnimation.SetActive(false);
            SpawnFishedOutItem();
        }


    }

    public void CancelFishing()
    {
        Debug.Log("Stoped Fishing");

        StopCoroutine("WaitingForFish");
        StopCoroutine("BiteSystem");

        if (GotBite)
        {
            didCatch = true;
            if (BiteAnimation != null) BiteAnimation.SetActive(false);
            if (WaterAnimation != null) WaterAnimation.SetActive(false);
            SpawnFishedOutItem();
        }


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
        StartCoroutine("BiteSystem");

    }

    IEnumerator BiteSystem()
    {

        int randomTimeForReelOut = Random.Range(minTimeForCatch, maxTimeForCatch);
        if(BiteAnimation != null) BiteAnimation.SetActive(true);



        yield return new WaitForSeconds(randomTimeForReelOut);
        if (BiteAnimation != null) BiteAnimation.SetActive(false);
        Debug.Log("Fish escaped");
        GotBite = false;
        StartCoroutine("WaitingForFish");

    }


    public void SpawnFishedOutItem()
    {

        if(fishedItems == null || fishedItems.Count == 0)
        {
            Debug.Log("the fishing item list is empty");
            return;
        }

        if(spawnPoint == null)
        {
            Debug.Log("Spawn point is empty");
            return;  
        }

        int randomItemToSpawn = Random.Range(0, fishedItems.Count);

        GameObject itemToSpawn = fishedItems[randomItemToSpawn];

        GameObject SpawnedObject = Instantiate(itemToSpawn, spawnPoint.position, spawnPoint.rotation);

        SpawnedObject.transform.SetParent(spawnPoint.transform);

        GotBite = false;

    }


}
