using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zuma : MonoBehaviour
{
    public static Zuma instance;
    
    public GameObject fırlatılacak;
    public Transform fırlatılacakpoint;
    public Transform sonrakitoppoint;
    public GameObject sonrakitop;
    public Transform spawnpoint;
    public float timer;
    public float rate;
    public bool IsFinished = false;
   
    
    

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (IsFinished) return;
        timer -= Time.deltaTime;
        if(timer<=0)
        {
          

            StartCoroutine(HareketEdenTopÜretimi());
            timer = rate;
        }
      
        MouseTakip();
        if (Input.GetMouseButtonDown(0))
        {
            ThrowColorfullBall();
        }
    }
    public void MouseTakip()
    {
        Vector3 fark =Camera.main.ScreenToWorldPoint(Input.mousePosition)- transform.position;
        float acıhesap = Mathf.Atan2(fark.y, fark.x) * Mathf.Rad2Deg;
        transform.localEulerAngles = new Vector3(0, 0, acıhesap);
    }

    public void ThrowColorfullBall()
    {
        if (fırlatılacak == null) return;

        fırlatılacak.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
        StartCoroutine(TopÜretimi());fırlatılacak.GetComponent<Rigidbody2D>().AddForce(transform.right * 400);
        fırlatılacak.transform.SetParent(null);
        Destroy(fırlatılacak.gameObject, 2f);
        fırlatılacak = null;


        
    }
   
    public IEnumerator TopÜretimi()
    {
        
        yield return new WaitForSeconds(0.2f);
        fırlatılacak = sonrakitop;
        fırlatılacak.transform.position = fırlatılacakpoint.position;

        sonrakitop = Instantiate(Balls.instance.SonrakiTpSeci().ballprefab, sonrakitoppoint.position, Quaternion.identity);
       
        sonrakitop.transform.SetParent(transform);
        
    }
    public IEnumerator HareketEdenTopÜretimi()
    {
       
        yield return new WaitForSeconds(0.2f);
        Partikül.instance.ShowPartikül("ışık", spawnpoint.position);
        GameObject olusantop = Instantiate(Balls.instance.SonrakiTpSeci().hareketedenprefab, spawnpoint.position, Quaternion.identity);
        

    }
  
}

