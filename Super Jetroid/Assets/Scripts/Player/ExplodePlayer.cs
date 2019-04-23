using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodePlayer : MonoBehaviour
{
    public BodyPart bodyPart;
    public int totalParts = 5;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Deadly") { OnExplode(); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Deadly") { OnExplode(); }
    }

    public void OnExplode()
    {
        Destroy(this.gameObject);
        //Ref to the current transform
        var t = transform;

        for (int i = 0; i < totalParts; i++)
        {
            BodyPart clone = Instantiate(bodyPart, t.position, Quaternion.identity) as BodyPart;
            clone.GetComponent<Rigidbody2D>().AddForce(Vector3.right * (Random.Range(-50, 50)));
            clone.GetComponent<Rigidbody2D>().AddForce(Vector3.up * Random.Range(100, 400));
        }
    }
}
