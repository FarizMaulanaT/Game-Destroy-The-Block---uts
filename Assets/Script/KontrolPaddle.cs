using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolPaddle : MonoBehaviour
{
    public float speed;
    public float pembatasKiri;
    public float pembatasKanan;
    
  
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        float nextPos = transform.position.x + horizontal;

        if (nextPos < pembatasKiri)
        {
            horizontal = 0;
        }
        if (nextPos > pembatasKanan)
        {
            horizontal = 0;
        }
        transform.Translate(horizontal, 0, 0);

    }
}
