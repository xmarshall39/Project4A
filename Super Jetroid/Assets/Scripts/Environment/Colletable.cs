using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colletable : MonoBehaviour
{

    public delegate void CrystalCollect();
    public static event CrystalCollect OnCrystalCollect;



    private void OnTriggerEnter2D(Collider2D target)
    {

        if (target.gameObject.tag == "Player") {
            
            Destroy(this.gameObject);
            OnCrystalCollect?.Invoke();
            
        }
            
    }
}
