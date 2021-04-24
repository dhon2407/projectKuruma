using UnityEngine;
using UnityEngine.UI;

namespace DMG.UI.HUD
{
    public class PowerIndicator : MonoBehaviour
    {
        [SerializeField]
        private Image fill;

        public void SetPowerRate(float rate)
        {
            fill.fillAmount = Mathf.Clamp01(rate);
        }
    }
}