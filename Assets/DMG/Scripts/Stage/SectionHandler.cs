using System;
using Unity.Mathematics;
using UnityEngine;

namespace DMG.Stage
{
    public class SectionHandler : MonoBehaviour
    {
        [SerializeField]
        private StageSection currentSection;

        [SerializeField]
        private StageSection nextSection;

        private StageSection _lastSection;

        private void Start()
        {
            currentSection.OnPassMidSection += OnMidSectionPass;
        }

        private void OnMidSectionPass(object sender, EventArgs e)
        {
            currentSection.OnPassMidSection -= OnMidSectionPass;
            
            if (!(sender is StageSection section))
                return;
            
            var newSection = Instantiate(nextSection, section.Endpoint, quaternion.identity);
            if (_lastSection)
                Destroy(_lastSection.gameObject);

            
            _lastSection = currentSection;
            currentSection = newSection;
            currentSection.OnPassMidSection += OnMidSectionPass;
        }
    }
}
