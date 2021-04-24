using System;
using UnityEngine;

namespace DMG.Stage
{
    public class AreaTrigger : MonoBehaviour
    {
        public event EventHandler OnTriggerArea;

        private void OnTriggerEnter(Collider other)
        {
            OnTriggerArea?.Invoke(this, EventArgs.Empty);
        }
    }
}