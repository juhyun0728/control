using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentMng : MonoBehaviour
{
    public GameObject[] temp;
    public Transform[] ComponentRoot;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i] != null)
                Instantiate(temp[i], ComponentRoot[i].localPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}