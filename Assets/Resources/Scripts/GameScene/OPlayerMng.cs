using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OPlayerMng : MonoBehaviour, IDropHandler
{
    float fSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(true)
        {
            moveObject();
        }

        if(true)
        {

        }
    }

    void moveObject()
    {
        float keyHorizontal = Input.GetAxis("Horizontal");

        //float keyVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * fSpeed * Time.smoothDeltaTime * keyHorizontal, Space.World);

        //transform.Translate(Vector3.up * fSpeed * Time.smoothDeltaTime * keyVertical, Space.World);
    }

    void jumpObject()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("FF");
        }
        Debug.Log("FASDASD");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("FF");
    }
    
}
