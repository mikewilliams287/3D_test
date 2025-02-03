using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        //Find the player by tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object not found, ensure it has a Player tag");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            // rotate only around y-axis to face player
            Vector3 directionToFace = playerTransform.position - transform.position;
            directionToFace.y = 0; // Lock the y-axis rotation
            transform.rotation = Quaternion.LookRotation(-directionToFace); // Ensure text is not flipped


        }





    }
}
