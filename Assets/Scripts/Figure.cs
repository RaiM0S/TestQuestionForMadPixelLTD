using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Figure : MonoBehaviour
{
    public int Tier { get; private set; }

    [SerializeField] private Animator animator;

    /// <summary>
    /// Задаю сначала 0 потом тир ап, что бы не дублировать свой же код
    /// </summary>
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
    /// <summary>
    /// Задает в аниматоре переменную для проигрывания анимации
    /// </summary>
    public void StartDragAnim()
    {
        animator.SetBool("Drag", true);
    }
    /// <summary>
    /// Задает в аниматоре переменную для остановки анимации
    /// </summary>
    public void StopDragAnim()
    {
        animator.SetBool("Drag", false);
    }
}
