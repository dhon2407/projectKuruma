using System;
using UnityEngine;

namespace DMG.Stage
{
    public class StageSection : MonoBehaviour
    {
        public event EventHandler OnPassMidSection;

        [SerializeField]
        private Transform startPoint;
        [SerializeField]
        private Transform endPoint;
        [SerializeField]
        private AreaTrigger halfwaySection;

        public Vector3 Endpoint => endPoint.position;

        private void Awake()
        {
            halfwaySection.OnTriggerArea += OnPassedHalfway;
        }

        private void OnDestroy()
        {
            halfwaySection.OnTriggerArea -= OnPassedHalfway;
        }

        private void OnPassedHalfway(object sender, EventArgs e)
        {
            OnPassMidSection?.Invoke(this, EventArgs.Empty);
        }
    }
}
