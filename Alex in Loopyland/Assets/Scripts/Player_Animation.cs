using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    public Animator playerAnimator;

    [SerializeField]
    private Player mainPlayerScr;
    [SerializeField]
    private GameObject playerGO;
    private Rigidbody2D playerGORB;

    void Start()
    {
        playerGO = this.gameObject;
        playerGORB = playerGO.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        #region Equipt Sword + Change Sprite
        if (Input.GetKeyUp(KeyCode.E))
            playerAnimator.SetBool("hasSword", true);
        #endregion

        // Ref main player script to detect damage/collision w/ raycast bullets from the queen 
        #region Damage = Fallback

        #endregion
    }
}
