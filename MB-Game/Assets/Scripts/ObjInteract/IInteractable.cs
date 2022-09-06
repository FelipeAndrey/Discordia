using UnityEngine;
public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private InputLanternMode inputLanternMode;

    public InputLanternMode InputLanternMode { get => inputLanternMode; set => inputLanternMode = value; }

    public abstract void Interact();
}
