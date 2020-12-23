using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePassCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstacle") && !GameManager.instance.dead)
        {
            ObstacleManager.instance.obstaclePassed++;
            UIManager.instance.levelProgBar.fillAmount = (float)ObstacleManager.instance.obstaclePassed / (float)ObstacleManager.instance.obstacleMaxInLevel;
            //Destroy(other.gameObject.transform.parent.gameObject);
            if(ObstacleManager.instance.obstaclePassed >= ObstacleManager.instance.obstacleMaxInLevel)
            {
                GameObject obs = Instantiate(GameManager.instance.escapeRocket, ObstacleManager.instance.spawnPoint.position, ObstacleManager.instance.spawnPoint.rotation);
            }
        }
    }
}
