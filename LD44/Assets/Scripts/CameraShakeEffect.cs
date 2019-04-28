using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

/// This effect is made to work with orthographic mode for the moment
public class CameraShakeEffect : MonoBehaviour
{
    [SerializeField] private Cinemachine.NoiseSettings shakeSettings;
    private Cinemachine.CinemachineVirtualCamera cinemachineVirtualCamera;
    private Camera mainCamera;
    private CinemachineBasicMultiChannelPerlin perlin;
    private void Awake() {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        perlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        if(perlin){
            //Debug.LogError("The perlin noise component doesn't exist");
            perlin = cinemachineVirtualCamera.AddCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }
    }
    public void ShakeCamera(float shakeTime){
        Coroutine routine = StartCoroutine(ShakeCameraRoutine(shakeTime));
    }

    public IEnumerator ShakeCameraRoutine(float shakeTime){
        if(perlin){
            perlin.m_NoiseProfile = shakeSettings;
            perlin.m_AmplitudeGain = 0.5f;
            yield return new WaitForSeconds(shakeTime);
            perlin.m_NoiseProfile = null;
        }
        else{
            Debug.LogError("The perlin noise component doesn't exist");
        }

    }
}
