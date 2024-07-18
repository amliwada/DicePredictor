using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private DiceRotationsProvider _diceRotationsProvider;

    [SerializeField] private List<Transform> _facesTransformList;
    
    [SerializeField] private Rigidbody _rigibody;
    [SerializeField] private Transform _meshTransform;

    private int _resultFaceIndex;

    public void MoveTo(Vector3 value)
    {
        transform.position = value;
    }

    public void RotateTo(float x, float y, float z)
    {
        Quaternion rotation = Quaternion.Euler(x, y, z);
        transform.rotation = rotation;
    }

    public void RotateTo(Quaternion quaternion)
    {
        transform.rotation = quaternion;
    }

    public void SetVelocity(float x, float y, float z)
    {
        _rigibody.velocity = new Vector3(x, y, z);
    }

    public void SetTorque(float x, float y, float z)
    {
        _rigibody.AddTorque(new Vector3(x, y, z), ForceMode.VelocityChange);
    }

    public bool IsStopped()
    {
        var isVelocityZero = _rigibody.velocity == Vector3.zero;
        var isAngularVelocityZero = _rigibody.angularVelocity == Vector3.zero;
        return isVelocityZero && isAngularVelocityZero;
    }

    public void SetResult()
    {
        _resultFaceIndex = 0;

        for (int i = 1; i < _facesTransformList.Count; i++)
        {
            if (_facesTransformList[_resultFaceIndex].position.y < _facesTransformList[i].position.y)
            {
                _resultFaceIndex = i;
            }
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void RotateToFace(int toFaceIndex)
    {
        if (_resultFaceIndex == toFaceIndex)
        {
            return;
        }

        var faceRotation = _diceRotationsProvider.GetRotationFromToFace(_resultFaceIndex, toFaceIndex);
        RotateTo(faceRotation);
    }

    private void RotateTo(Vector3 value)
    {
        _meshTransform.transform.Rotate(value);
    }
}