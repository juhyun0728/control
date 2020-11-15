﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ODragScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 defaultposition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)//드래그시작할 때
    {
        defaultposition = this.transform.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)//드래그중일 때 
    { 
        Vector2 currentPos = Input.mousePosition; 
        this.transform.position = currentPos; 
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)//드래그 끝났을 때 
    { 
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        this.transform.position = defaultposition;
        

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}