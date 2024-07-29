using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnim : MonoBehaviour
{
    private MonsterAI monsterAI;
    [SerializeField] private Animator anim;

    private void Awake()
    {
        monsterAI = this.GetComponent<MonsterAI>();
        anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        MoveAnim();
    }

    private void MoveAnim()
    {
        if (monsterAI.IsMove())
            anim.SetBool("isMove", true);

    }
}
