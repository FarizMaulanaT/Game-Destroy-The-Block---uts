using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class KontrolBola : MonoBehaviour
{
    public int force;
    public Text countText;
    public Text nyawaText;
    private int count;
    private int nyawa;
    AudioSource audio;
    public AudioClip bounceSound;
    GameObject panelMenang;
    GameObject panelKalah;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(0, -1).normalized;
        rb.AddForce(arah * force);
        count = 0;
        nyawa = 3;
        SetNyawaText();
        SetCountText();
        panelMenang = GameObject.Find("panelMenang");
        panelMenang.SetActive(false);
        panelKalah = GameObject.Find("panelKalah");
        panelKalah.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        audio.PlayOneShot(bounceSound);
        if (coll.gameObject.name == "Padle")
        {
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rb.velocity.x, sudut).normalized;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(arah * force * 2);

        }
        if (coll.transform.CompareTag("balok"))
        {
            Destroy(coll.gameObject);
            count = count + 1;
            SetCountText();
        }
        if (count == 15)
        {
            Destroy(gameObject);
            panelMenang.SetActive(true);
        }
        if (coll.transform.CompareTag("pembatasbawah"))
        {
            ResetBall();

            nyawa = nyawa - 1;
            SetNyawaText();
            if(nyawa == 0)
            {
                Destroy(gameObject);
                panelKalah.SetActive(true);
            }
        }

        

    }
    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        

    }
    void SetNyawaText()
    {
        nyawaText.text = "Lives: " + nyawa.ToString();
    }
    void ResetBall()
    {
        transform.localPosition = new Vector2(-0.06f, -2.86f);
        rb.velocity = new Vector2(0, -1);
        
    }
}
