using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 6, -10);
    
    void LateUpdate() // late update kullanarak daha smoot geçi?ler sa?lan?yor ondan dolay? kamerada bunu kullan?yoruz 
    {
        // offset the camera behind the player by adding to the player's position 
        transform.position = player.transform.position + offset;
    }
}
