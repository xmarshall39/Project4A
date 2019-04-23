using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool ignorePlayer;
    public Door door;
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(ignorePlayer) { return; }
        if (collision.gameObject.tag == "Player")
            door.Open();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ignorePlayer) { return; }
        if (collision.gameObject.tag == "Player")
            door.Close();
    }

    public void Toggle(bool val)
    {
        if (val) { door.Open(); }
        else { door.Close(); }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = ignorePlayer ? Color.gray : Color.green;

        BoxCollider2D bc2d = GetComponent<BoxCollider2D>();
        Vector3 bc2dPos = bc2d.transform.position;
        Vector2 newPos = new Vector2(bc2dPos.x + bc2d.offset.x, bc2dPos.y + bc2d.offset.y);
        Gizmos.DrawWireCube(newPos, new Vector2(bc2d.size.x, bc2d.size.y));
    }
}
