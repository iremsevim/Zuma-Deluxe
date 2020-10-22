using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareketEdecekToplar : MonoBehaviour
{
    public static List<HareketEdecekToplar> HareketEdecekToplars = new List<HareketEdecekToplar>();

    public Transform target;
    public bool IsMoving = false;
    public float speed = 0.5f;
    public string colorID;



    private void Awake()
    {
        target = Path.instance.pathes[0].pointobject;
        IsMoving = true;
    }
    private void Start()
    {
        HareketEdecekToplars.Add(this);
    }
    private void OnDestroy()
    {
        HareketEdecekToplars.Remove(this);
    }
    private void Update()
    {
        Hareket();
    }

    public void Hareket()
    {
        if (IsMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, target.transform.position) < 0.1f)
            {
                Transform sonraki = Path.instance.FindNextPoint(target);
                if (sonraki == null)
                {
                    IsMoving = false;
                    Destroy(gameObject);
                    Debug.Log("Hareket Tamamlandı");
                    Partikül.instance.GameOver();
                    return;
                }
                target = sonraki;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<HareketEdecekToplar>())
        {
            other.GetComponent<HareketEdecekToplar>().IsMoving = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!IsMoving) return;
        
        if (other.GetComponent<HareketEdecekToplar>())
        {
            other.GetComponent<HareketEdecekToplar>().IsMoving = true;
        }
    }
    
}


