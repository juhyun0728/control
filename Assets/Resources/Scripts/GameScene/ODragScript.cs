using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ODragScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler,IPointerDownHandler, IPointerUpHandler
{
    public static Vector2 defaultposition;

    private RectTransform rectTrans;
    private RectTransform parentRectTrans;
    private Canvas rootCanvas;
    private Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        rectTrans = this.GetComponent<RectTransform>();
        parentRectTrans = this.rectTrans.parent as RectTransform;
        this.rootCanvas = this.GetComponentInParent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        //this.transform.SetAsLastSibling();
        this.transform.SetParent(rootCanvas.transform);

        //eventData.position 포인터 스크린 포지션
        //다운위치 Offset 을 기억하자
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                this.parentRectTrans,
                eventData.position,
                (this.rootCanvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : this.rootCanvas.worldCamera,
                out offset))
        {
            //현재 클한지점의 로컬 위치에서 나의 현제 로컬위치까지의 차이량을 기억한다.
            this.offset.x = this.offset.x - this.transform.localPosition.x;
            this.offset.y = this.offset.y - this.transform.localPosition.y;

        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        //this.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)//드래그시작할 때
    {
        defaultposition = this.transform.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)//드래그중일 때 
    {
        //Vector2 currentPos = Input.mousePosition; 
        //this.transform.position = currentPos; 

        //this.GetComponent<CanvasGroup>().blocksRaycasts = false;


        //결과값 ( this.parentRectTransform 의 로컬로 나온다 )
        Vector2 outLocalPos = Vector2.zero;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
              this.parentRectTrans,
              eventData.position,
              (this.rootCanvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : this.rootCanvas.worldCamera,
              out outLocalPos))
        {
            this.transform.localPosition = outLocalPos - offset;
        }
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

    
    public void test()
    {
        Debug.Log("AAA");
    }

}