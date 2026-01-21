using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Figure : MonoBehaviour
{
    public int Tier { get; private set; }

    [SerializeField] private Animator animator;

    public void Spawn()
    {
        Tier = 0;
        TierUp();
    }

    public void TierUp()
    {
        Tier += 1;
        GetComponent<Image>().color = GameAssets.Instance.GetColorByTier(Tier);
    }

    public void StartDragAnim()
    {
        animator.SetBool("Drag", true);
    }
    public void StopDragAnim()
    {
        animator.SetBool("Drag", false);
    }
}
