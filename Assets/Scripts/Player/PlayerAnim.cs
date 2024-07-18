using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator anim;
    private PlayerCtrl playerCtrl;
    [SerializeField] private Transform characterBody;

    // Start is called before the first frame update
    void Start()
    {
        anim = characterBody.GetComponent<Animator>();
        playerCtrl = this.GetComponent<PlayerCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isMove", playerCtrl.IsMove());
    }
}
