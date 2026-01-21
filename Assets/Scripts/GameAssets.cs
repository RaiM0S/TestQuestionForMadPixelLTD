using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    [SerializeField] private List<FigureSO> _figures;

    public static GameAssets Instance;

    private void Awake()
    {
        Instance = this;
    }
    public Color GetColorByTier(int Tier)
    {
        FigureSO figureSO = _figures.FirstOrDefault(f => f.Tier == Tier);
        if (figureSO != null)
        {
            return figureSO.Color;
        }
        Debug.LogError("Такого тира нет");
        return Color.blue;
    }
}
