using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private bool collisionflag = false;

    //spesific function that unity created for collisions
    void OnCollisionEnter(Collision collisionInfo) //information about collision
    {
        //Debug.Log(collisionInfo.collider.name); // to display what we hit. This clould be buggy so we use "tags"
        if (collisionInfo.collider.tag == "Enemy")
        {
            collisionflag = true;
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public bool getCollisionFlag()
    {
        return this.collisionflag;
    }

}
