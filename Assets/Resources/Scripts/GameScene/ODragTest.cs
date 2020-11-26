using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ODragTest : MonoBehaviour
{
    float distance = 10;

    bool bStay = false;
    public Vector2 defaultposition;

    public Vector2 ComponentRootPosition;

    // Start is called before the first frame update
    void Start()
    {
        defaultposition = this.transform.position;
        ComponentRootPosition = this.transform.GetChild(0).transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDrag()
    {
        //print("Drag!!");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }

    private void OnMouseUp()
    {
        if(bStay)
        {
            this.transform.position = ComponentRootPosition;
        }
        else
        {
            this.transform.position = defaultposition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bStay = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bStay = false;
    }
}
