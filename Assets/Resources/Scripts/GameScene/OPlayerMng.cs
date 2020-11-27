using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OPlayerMng : MonoBehaviour, IDropHandler
{
    float fSpeed = 5;

    public List<Vector2> componentVectorList;
    public ODragScript d;

    // Start is called before the first frame update
    void Start()
    {
        componentVectorList.Add(new Vector2(0, 0));
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

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("FF");
        

        if (this.transform.childCount == 0)
        {
            eventData.pointerDrag.transform.SetParent(this.transform);
        }
        else
        {
            d = eventData.pointerDrag.gameObject.GetComponent<ODragScript>();
            d.returnToParent();
        }

        Debug.Log("OnDrop on player");
    }
    
}
