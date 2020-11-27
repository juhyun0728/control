﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ODragTest : MonoBehaviour
{
    float distance = 10;

    bool bStay = false;
    public Vector2 defaultposition;

    public Vector2 ComponentRootPosition;
    public OPlayerMng currentPlayerMng;
    Transform componentRootTransform;
    public float componentStackValue = 0.86f;

    // Start is called before the first frame update
    void Start()
    {

        defaultposition = this.transform.position;
        //ComponentRootPosition = this.transform.GetChild(0).transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody != null)
                hit.rigidbody.gameObject.SendMessage("OnMouseDown");
            else
                hit.collider.SendMessage("OnMouseDown");

            Debug.Log("AASDASD");
        }
        //Debug.Log("F");
    }
    void OnMouseDrag()
    {
        //print("Drag!!");
        Debug.Log("AA");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    private void OnMouseDown()
    {
        Debug.Log("click");
    }

    void UnityApiMouseEvents()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit))
        {
            if (hit.rigidbody != null)
                hit.rigidbody.gameObject.SendMessage("OnMouseDown");
            else
                hit.collider.SendMessage("OnMouseDown");
        }

    }

    private void OnMouseUp()
    {
        if(bStay)
        {
            this.transform.position = ComponentRootPosition;
            currentPlayerMng.componentVectorList.Add(new Vector2(0, currentPlayerMng.componentVectorList[currentPlayerMng.componentVectorList.Count - 1].y + componentStackValue));
            //this.transform.SetParent(componentRootTransform);
        }
        else
        {
            this.transform.position = defaultposition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ComponentRootPosition = collision.transform.GetChild(0).transform.position;
        //ComponentRootPosition = new Vector2(collision.transform.position.x, collision.transform.position.y + 0.86f);
        currentPlayerMng = collision.GetComponent<OPlayerMng>();
        ComponentRootPosition = new Vector2(collision.transform.position.x, collision.transform.position.y + currentPlayerMng.componentVectorList[currentPlayerMng.componentVectorList.Count-1].y + 0.86f);
        
        //Debug.Log(collision.transform.GetChild(0).transform.name);
        //componentRootTransform = collision.transform.GetChild(0).transform;
        bStay = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bStay = false;
    }
}
