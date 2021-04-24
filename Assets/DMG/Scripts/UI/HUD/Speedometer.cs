using TMPro;
using UnityEngine;

namespace DMG.UI.HUD
{
    public class Speedometer : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI display;

        public int CurrentSpeed => _currentSpeed;
        private int _currentSpeed;

        public void SetSpeed(int value)
        {
            _currentSpeed = value;
            display.text = value.ToString("0");
        }
        
    }
}
