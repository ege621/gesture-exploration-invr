using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureAnimManager : MonoBehaviour
{
    public Transform playerTransform;
    public List<GestureAnimPlayer> gestureAnimPlayers;

    private void Awake()
    {
        gestureAnimPlayers = new List<GestureAnimPlayer>();
        foreach(GestureAnimPlayer gestureAnimPlayer in FindObjectsOfType<GestureAnimPlayer>())
        {
            gestureAnimPlayers.Add(gestureAnimPlayer);
        }
    }

    private void Update()
    {
        bool tapped1 = Input.GetKeyDown(KeyCode.Alpha1);
        bool tapped2 = Input.GetKeyDown(KeyCode.Alpha2);

        if (tapped1 || tapped2)
        {
            GestureAnimPlayer closestPlayer = gestureAnimPlayers[0];
            float minDistance = float.MaxValue;

            foreach (GestureAnimPlayer gesturePLayer in gestureAnimPlayers)
            {
                float distanceToPlayer = (playerTransform.position - gesturePLayer.transform.position).sqrMagnitude;
                if(distanceToPlayer < minDistance)
                {
                    minDistance = distanceToPlayer;
                    closestPlayer = gesturePLayer;
                    Debug.Log("Found closer player: " + closestPlayer.name);
                }
            }

            if (tapped1)
            {
                closestPlayer.PlayOpenClip();
            }
            else if (tapped2)
            {
                closestPlayer.PlayCloseClip();
            }
        }
    }
}
