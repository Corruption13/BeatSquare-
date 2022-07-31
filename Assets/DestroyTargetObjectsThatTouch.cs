using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTargetObjectsThatTouch : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask targetObjectsLayers;
    public GameStateManager gameStateManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetObjectsLayers == (targetObjectsLayers | (1 << collision.gameObject.layer)))
        {
            UpdateScore(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

    void UpdateScore(GameObject g)
    {
        int enemyPoints = g.GetComponent<EnemyWorth>().enemyDestroyedPoints;
        gameStateManager.ConfirmEnemyDestroyed(enemyPoints);
    }


}
