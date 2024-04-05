using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayMove : MonoBehaviour
{
    Vector3 p1;
    public Vector3 modif;
    Vector3 p2;
    public bool slidIn = true;

    bool inMotion;
    bool prevState;

    // Start is called before the first frame update
    void Start()
    {
        p1 = this.transform.position;
        p2 = p1 + modif;
        prevState = slidIn;
    }

    // Update is called once per frame
    void Update()
    {
        if(slidIn != prevState) {
            ChangeState();
            inMotion = true;
        }

        if(inMotion)
        {
            transform.position = Vector3.MoveTowards(transform.position, slidIn ? p2 : p1, Time.deltaTime * .5f);

            if(transform.position == (slidIn? p2 : p1))
            {
                inMotion = false;
                prevState = !prevState;
                slidIn = !slidIn;
            }
        }
    }

    public void ChangeState()
    {
        slidIn = !slidIn;
    }
}
