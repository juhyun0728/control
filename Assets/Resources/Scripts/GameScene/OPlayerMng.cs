using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OPlayerMng : MonoBehaviour, IDropHandler
{
    float fSpeed = 3;

    public List<Vector2> componentVectorList;
    public ODragScript d;
    float fJumpPower = 5f;
    bool bJumping;
    bool bDir = false;
    Animator anim;

    public bool bMoveState = false;
    public bool bJumpState = false;
    public bool bSlideState = false;
    public bool bDestroyState = false;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(gameObject.transform.GetChild(0).FindChild("Move"));
        componentVectorList.Add(new Vector2(0, 0));
        bJumping = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bMoveState)
        {
            moveObject();
        }

        if(bJumpState)
        {
            jumpObject();
        }

        if(bSlideState)
        {
            SlideObject();
        }

        if(bDestroyState)
        {
            DestroyObject();
        }
    }

    void moveObject()
    {
        float keyHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * fSpeed * Time.smoothDeltaTime * keyHorizontal, Space.World);

        if (gameObject.tag == "Player")
        {
            if (keyHorizontal != 0)
            {
                anim.SetBool("isMove", true);
                anim.SetFloat("Dir", keyHorizontal);

            }
            else
            {
                anim.SetBool("isMove", false);
            }
        }
    }

    void jumpObject()
    {
        float keyVertical = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.up * fSpeed * Time.smoothDeltaTime * keyVertical, Space.World);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!bJumping)
            {
                bJumping = true;
                this.GetComponent<Rigidbody2D>().AddForce(Vector3.up * fJumpPower, ForceMode2D.Impulse);
            }
            else
            {
                return;
            }
        }
    }

    void SlideObject()
    {
        

        if(bDir)
        {
            Debug.Log("QWEQWEQWE");
            transform.Translate(Vector3.right * fSpeed * Time.smoothDeltaTime, Space.World);
        }
        else
        {
            transform.Translate(Vector3.left * fSpeed * Time.smoothDeltaTime, Space.World);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            bDir = false;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("AA");
            bDir = true;
        }
    }

    void DestroyObject()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //점프가 가능한 상태로 만듦
            bJumping = false;
        }

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
