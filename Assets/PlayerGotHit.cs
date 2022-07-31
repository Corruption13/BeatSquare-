using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGotHit : MonoBehaviour
{
    public LayerMask enemyLayer;
    public LayerMask friendlyLayer; 
    public GameStateManager gameStateManager;
    //public GameController gameController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemyLayer == (enemyLayer | (1 << collision.gameObject.layer)))
        {
            gameStateManager.PlayerGotHit();
        }
        else if (friendlyLayer == (friendlyLayer | (1 << collision.gameObject.layer)))
        {
            gameStateManager.AddLife();
        }
        Destroy(collision.gameObject);
    }

}
