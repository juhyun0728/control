using System.Collections;
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
    }

    void OnMouseDrag()
    {
        //print("Drag!!");
        //Debug.Log("AA");
        //this.GetComponent<BoxCollider2D>().enabled = false;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    private void OnMouseDown()
    {
        //Debug.Log("click");
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
        this.GetComponent<BoxCollider2D>().enabled = true;
        if(bStay)
        {
            
            AttachComponent();
        }
        else
        {
            this.transform.position = defaultposition;
        }
    }

    void AttachComponent()
    {
        this.transform.position = ComponentRootPosition;
        currentPlayerMng.componentVectorList.Add(new Vector2(0, currentPlayerMng.componentVectorList[currentPlayerMng.componentVectorList.Count - 1].y + componentStackValue));
        this.transform.SetParent(componentRootTransform);
        this.enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;

        currentPlayerMng.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        currentPlayerMng.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        switch (this.name)
        {
            case "Move(Clone)":
                currentPlayerMng.bMoveState = true;
                break;
            case "Jump(Clone)":
                currentPlayerMng.bJumpState = true;
                break;
            case "Slide(Clone)":
                currentPlayerMng.bSlideState = true;
                break;
            case "Destroy(Clone)":
                currentPlayerMng.bDestroyState = true;
                break;
        }
        SoundManager.instance.play_stick();
    }
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ComponentRootPosition = collision.transform.GetChild(0).transform.position;
        //ComponentRootPosition = new Vector2(collision.transform.position.x, collision.transform.position.y + 0.86f);
        if(collision.tag != "Finish")
        {
            currentPlayerMng = collision.GetComponent<OPlayerMng>();
            Debug.Log(currentPlayerMng.componentVectorList.Count);
            if (currentPlayerMng.componentVectorList != null)
            {
                ComponentRootPosition = new Vector2(collision.transform.position.x, collision.transform.position.y + currentPlayerMng.componentVectorList[currentPlayerMng.componentVectorList.Count - 1].y + 0.86f);
            }
            componentRootTransform = collision.transform.GetChild(0).transform;
            bStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bStay = false;
    }
}