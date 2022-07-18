using UnityEngine;
using TMPro;

public class SpeedMeter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _speedometerText;
    [SerializeField] private TextMeshProUGUI _RPMmeterText;

    [SerializeField] private float _speed;
    [SerializeField] private float _RPM;

    [SerializeField] private GameObject _playerGO;

    private Rigidbody _playerRB;
    
    void Start()
    {
        _playerRB = _playerGO.GetComponent<Rigidbody>();
    }
   
    void Update()
    {
        _speed = Mathf.Round(_playerRB.velocity.magnitude * 3.6f);
        _speedometerText.SetText("Speed: " + _speed + " kph");

        _RPM = Mathf.Round((_speed % 80) / 4);
        _RPMmeterText.SetText("RPM: " + _RPM);
    }
}
