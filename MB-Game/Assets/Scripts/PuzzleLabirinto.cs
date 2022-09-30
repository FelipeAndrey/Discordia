using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLabirinto : MonoBehaviour
{
    public GameManager manager;
    public List<GameObject> wood;
    public BoxCollider invisibleWall;
    [HideInInspector] public int cont = 0;
}
