using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Balls : MonoBehaviour
{
    public static Balls instance;
    
    public List<Ballprofil> balls;


    public MesafeKontrolData mesafeKontrolData;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        TopMesafeKontrolSistemi();
    }

    public Ballprofil SonrakiTpSeci()
    {
        Ballprofil sonrakitop = balls[Random.Range(0, balls.Count)];
        return sonrakitop;

    }

    [System.Serializable]
    public class Ballprofil
    {
        public string colorID;
        public GameObject ballprefab;
        public GameObject hareketedenprefab;
    }

    public void TopMesafeKontrolSistemi()
    {
        /*
        if (mesafeKontrolData.hareketetmeyenler.Count == 0) return;

        if(Vector2.Distance(mesafeKontrolData.hareketetmeyenler[mesafeKontrolData.hareketetmeyenler.Count-1].position,mesafeKontrolData.hareketedenler[0].position)<=0.2f)
        {
            mesafeKontrolData.hareketetmeyenler.ForEach(x => x.GetComponent<HareketEdecekToplar>().IsMoving = true);
            mesafeKontrolData.hareketetmeyenler.Clear();
            mesafeKontrolData.hareketedenler.Clear();
        }
        */

        if (mesafeKontrolData.kontrol_1 == null) return;
        
        if (Vector2.Distance(mesafeKontrolData.kontrol_1.position,mesafeKontrolData.kontrol_2.position)<=1f)
        {
            mesafeKontrolData.OnTrigger?.Invoke();
            mesafeKontrolData.kontrol_1 = null;
            mesafeKontrolData.kontrol_2 = null;
        }
      
        
    }

    [System.Serializable]
    public  class MesafeKontrolData
    {
        /*
        public List<Transform> hareketedenler;
        public List<Transform> hareketetmeyenler;
        */

        public Transform kontrol_1;
        public Transform kontrol_2;
        public System.Action OnTrigger;
    }
}
