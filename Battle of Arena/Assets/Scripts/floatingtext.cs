using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class floatingtext : MonoBehaviour {
    public  Animator animator;
    private Text damagetext;
    private void Onenable()
    {
        
    }
    private void OnEnable()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
        damagetext = animator.GetComponent<Text>();

    }

    public void SetText(string text)
    {
       damagetext.text = text;
    }
}
