using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Characterw: MonoBehaviour
{
    public float movementSpeed;
    Rigidbody rb;
    Animator anim;
    CapsuleCollider col_size;
    public float rotspeed;
    public float speed;
    public GameObject tomatoe;
    public GameObject Onion;
    //variables de destruccion 
    private bool cutT = false;
    private bool cutO = false;
    //timing
    //public Image health;
    private float timeLeft = 4.5f;
    //
    private bool contactT = false;
    private bool contactO = false;
    private bool TomatoG = false;
    private bool OnionG = false;
    //GAMEOBJECTS**************************************
    public GameObject Tomat;
    public GameObject Oni;

    public GameObject TomC;
    public GameObject OnC;

    public GameObject CookedT;
    public GameObject CookedO;

    public GameObject readyT;
    public GameObject readyO;
    //color changing
    private UnityEngine.Color color;
    // Start is called before the first frame update

    //Colision caja de tomates
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("TomatoBox"))
        {
            contactT = true;
        }
        if (col.gameObject.CompareTag("OnionBox"))
        {
            contactO = true;
        }
        //--------------
        if (col.gameObject.CompareTag("tomato"))
        {
            Tomat.transform.SetParent(transform);
        }

        /*if (col.gameObject.CompareTag("onion"))
        {
            Tomat.transform.SetParent(transform);
        }*/
        //-------------
        //-------------
        if (col.gameObject.CompareTag("Tabla"))
        {
            print("estoy tocando la tabla");
            if (TomatoG == true)
            {
                cutT = true;
                print("cutT true");
            }

            print("estoy tocando la tabla");

            if (OnionG == true)
            {
                cutO = true;
                print("cutO true");
            }

        }
    }
    //separacion caja de tomates
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("TomatoBox"))
        {
            contactT = false;
        }

        if (col.gameObject.CompareTag("OnionBox"))
        {
            contactO = false;
        }

        //salida tabla  
        if (col.gameObject.CompareTag("Tabla"))
        {
            print("FUERA TABLA T");
            if (TomatoG == false)
            {
                cutT = false;
                print("cutT true");
            }

            print("FUERA TABLA O");

            if (OnionG == false)
            {
                cutO = false;
                print("cutO true");
            }

        }
    }
    //prueba seguimiento
   
    //-------START
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        col_size = GetComponent<CapsuleCollider>();
        //health.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
         var z = Input.GetAxis("Vertical") * movementSpeed;
         var y = Input.GetAxis("Horizontal") * rotspeed;
         
        
        transform.Translate(0, 0, z);
        transform.Rotate(0, y, 0);
        //extraer tomates
        if (contactT == true)
        {
            if (Input.GetKeyDown("q"))
            {
                //Instantiate(tomatoe, transform.position + (transform.forward * 2) + (transform.up * 6), transform.rotation);
                Tomat = Instantiate(tomatoe, transform.position + (transform.forward * 2) + (transform.up * 6), transform.rotation);
                Tomat.transform.parent = transform;
                TomatoG = true;
                
            }
        }
        //extraer cebollas
        if (contactO == true)
        {
            if (Input.GetKeyDown("q"))
            { 
                //Instantiate(Onion, transform.position + (transform.forward * 2) + (transform.up * 6), transform.rotation);
                Oni = Instantiate(Onion, transform.position + (transform.forward * 2) + (transform.up * 6), transform.rotation);
                Oni.transform.parent = transform;
                Oni.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                OnionG = true;
                print("cree una cebolla");
            }
        }
        //cortar tomates 
        //print(cutT);
        if (Input.GetKeyDown("q") && cutT == true)
         {
             foreach (Transform child in transform)
             {
                 Destroy(Tomat);
                TomatoG = false;
            }
             //TomC = Instantiate(Onion, transform.position + (transform.forward * 2) + (transform.up * 6), transform.rotation);
        }

        if (Input.GetKeyDown("q") && cutO == true)
        {
            /*health.enabled = true;
            timeLeft -= Time.deltaTime;
            health.fillAmount = timeLeft;
            if (timeLeft <= 0)
            {
                health.enabled = false;

            }*/
            Destroy(Oni);
            foreach (Transform child in transform)
            {
                
                Destroy(Oni);
                OnionG = false;
            }
        }

    }
}
