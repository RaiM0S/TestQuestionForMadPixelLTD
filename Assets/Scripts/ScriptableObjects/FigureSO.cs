using UnityEngine;

[CreateAssetMenu(fileName = "FigureSO", menuName = "Scriptable Objects/FigureSO")]

//Тир можно не задавать, и брать цвет по индексу в листе
public class FigureSO : ScriptableObject
{
    public int Tier;
    public Color Color;
}
