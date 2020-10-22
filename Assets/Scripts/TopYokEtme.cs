using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TopYokEtme : MonoBehaviour
{
    public string colorID;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="ball")
        {
            if (other.GetComponent<HareketEdecekToplar>().colorID == colorID)
            {
                int findedindex = HareketEdecekToplar.HareketEdecekToplars.FindIndex(x => x.gameObject == other.gameObject);

          

              

                for (int i = findedindex - 1; i >= 0; i--)
                {
                    HareketEdecekToplar.HareketEdecekToplars[i].IsMoving = false;
                }
              
                Partikül.instance.ShowPartikül("çarpma", other.transform.position);
                Destroy(other.gameObject);
                Debug.Log("Vurdum");
                  

                for (int i = findedindex+1; i <=HareketEdecekToplar.HareketEdecekToplars.Count-1; i++)
                {
                    if(HareketEdecekToplar.HareketEdecekToplars[i].colorID==colorID)
                    {
                        Partikül.instance.ShowPartikül("parlama", HareketEdecekToplar.HareketEdecekToplars[i].transform.position);

                        Destroy(HareketEdecekToplar.HareketEdecekToplars[i].gameObject);
                    }
                    else
                    {
                        break;
                    }

                }
                for (int i = findedindex-1; i >=0; i--)
                {
                    if (HareketEdecekToplar.HareketEdecekToplars[i].colorID == colorID)
                    {
                        Partikül.instance.ShowPartikül("parlama", HareketEdecekToplar.HareketEdecekToplars[i].transform.position);

                        Destroy(HareketEdecekToplar.HareketEdecekToplars[i].gameObject);
                    }
                    else
                    {
                        break;
                    }

                }


            }


        }

        Destroy(gameObject);
    }
} 
