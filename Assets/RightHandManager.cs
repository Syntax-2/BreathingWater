using System.Collections;
using UnityEngine;

public class RightHandManager : MonoBehaviour
{
    public bool canOpenBook;

    public Transform startingPosition;
    public Transform finalPosition;
    public float maxDistance = 10;
    public float speed;

    private Coroutine _moveCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (canOpenBook)
        {
            if(_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
            }

            _moveCoroutine = StartCoroutine(MoveObject(finalPosition));
            
        }
    }


    private void OnMouseExit()
    {
        if (canOpenBook)
        {
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
            }

            _moveCoroutine = StartCoroutine(MoveObject(startingPosition));

        }
    }



    private IEnumerator MoveObject(Transform target)
    {
        while(Vector3.Distance(transform.position, target.position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, speed * 3f * Time.deltaTime);

            yield return null;
        }

        transform.position = target.position;
        transform.rotation = target.rotation;

    }


}
