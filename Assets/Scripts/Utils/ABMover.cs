using DG.Tweening;
using UnityEngine;

namespace Utils
{
    public class ABMover : MonoBehaviour
    {
        [SerializeField] protected Vector3 _posA;
        [SerializeField] protected Vector3 _posB;
        [SerializeField] protected float _duration = 0.2f;

        public void MoveToB()
        {
            transform.DOMove(_posB, _duration);
        }

        public void MoveToA()
        {
            transform.DOMove(_posA, _duration);
        }
    }
}