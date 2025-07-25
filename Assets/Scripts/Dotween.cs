using DG.Tweening;
using UnityEngine;

public class Dotween : MonoBehaviour
{
    [SerializeField] private Transform block;
    [SerializeField] float duration;
    public void bounce()
    {
        block.DOMove(new Vector3(0, block.transform.position.y + 5, 0), duration);
    }
}
