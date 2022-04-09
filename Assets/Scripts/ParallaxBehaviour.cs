using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class ParallaxBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Transform followingTarget;
        [SerializeField]
        private bool xParallax;
        [SerializeField]
        private bool yParallax;
        [SerializeField, Range(-1f, 1f)]
        private float parallaxStrength;
        private Vector3 targetPreviousPosition;

        void Start()
        {
            if (!followingTarget)
            {
                followingTarget = Camera.main.transform;
            }
        }

        void Update()
        {
            var delta = followingTarget.position - targetPreviousPosition;

            if (!xParallax)
            {
                delta.x = 0;
            }

            if (!yParallax)
            {
                delta.y = 0;
            }

            targetPreviousPosition = followingTarget.position;
            transform.position += delta * parallaxStrength;
        }
    }
}
