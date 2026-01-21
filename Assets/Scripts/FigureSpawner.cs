using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс для спавна фигур в слотах
/// </summary>
public class FigureSpawner : MonoBehaviour
{
    [SerializeField] private List<Slot> _slots;
    [SerializeField] private GameObject _figurePrefab;

    /// <remarks>
    /// тут можно спавнить в случайной а можно и нет. Случайная требует чуть больше строк кода, да и так немного но интереснее чем в первой свободной
    /// </remarks>
    public void Spawn()
    {
        List<Slot> freeSlots = new List<Slot>();
        for (int i = 0; i< _slots.Count; i++)
        {
            if( _slots[i].IsEmpty)
            {
                freeSlots.Add(_slots[i]);
            }
        }
        if (freeSlots.Count > 0) 
        {
            freeSlots[Random.Range(0,freeSlots.Count-1)].Spawn(_figurePrefab);
        }
    }
}
