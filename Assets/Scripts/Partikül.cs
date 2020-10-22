using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partikül : MonoBehaviour
{
    public static Partikül instance;

    public List<PartikülProfil> partiküls;
   

    private void Awake()
    {
        instance = this;
    }

    public void ShowPartikül(string ID,Vector2 konum)
    {
     PartikülProfil createdparticül= partiküls.Find(x => x.partikülID == ID);
      GameObject olusanpartikül = Instantiate(createdparticül.partikülobject, konum, Quaternion.identity);
        Destroy(olusanpartikül.gameObject, 1f);

    }



    [System.Serializable]
    public class PartikülProfil
    {
        public string partikülID;
        public GameObject partikülobject;
    }

     public void GameOver()
    {
        HareketEdecekToplar.HareketEdecekToplars.ForEach(x => { x.IsMoving = false; Destroy(x.gameObject);ShowPartikül("bitiş",x.transform.position); }) ;
       
        Zuma.instance.IsFinished = true;
    }
}
