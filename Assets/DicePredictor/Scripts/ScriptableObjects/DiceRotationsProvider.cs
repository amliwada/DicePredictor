using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DiceRotationsProvider", menuName = "DicePredictor/DiceRotationsProvider")]
public class DiceRotationsProvider : ScriptableObject
{
    [Serializable]
    private class ToFaceRotation
    {
        [SerializeField] private Vector3 _rotation;

        public Vector3 Rotation { get => _rotation; }
    }

    [Serializable]
    private class FromFaceRotationsProvider
    {
        [SerializeField] private List<ToFaceRotation> _faceRotations;

        public Vector3 GetRotationToFaceWithIndex(int faceIndex)
        {
            return _faceRotations[faceIndex].Rotation;
        }
    }

    [SerializeField] private List<FromFaceRotationsProvider> _rotationProviders;

    public Vector3 GetRotationFromToFace(int fromFaceIndex, int toFaceIndex)
    {
        return _rotationProviders[fromFaceIndex].GetRotationToFaceWithIndex(toFaceIndex);
    }
}