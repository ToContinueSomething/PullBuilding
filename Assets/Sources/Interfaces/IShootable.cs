using System;
using UnityEngine;

namespace Sources.Interfaces
{
    public interface IShootable
    {
        public event Action ShootStopped;

        void Shoot(Vector3 from);
    }
}
