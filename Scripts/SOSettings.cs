using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Create new settings", menuName = "Create new setting", order = 51)]
public class SOSettings : ScriptableObject
{
    [SerializeField] private List<Barrier> _barrierPrefabs;
    [SerializeField] private Material _full;
    [SerializeField] private Material _parts;
    [SerializeField] private Material _ice;
    [SerializeField] private float _speed;

    [SerializeField] private Material _portal;
    [SerializeField, ColorUsage(showAlpha: true, hdr: true)] private Color _portalColor;

    [Header("Crystal material settings:")]  
    [SerializeField, ColorUsage(showAlpha: true, hdr: true)] private Color _baseColor;
    [SerializeField, ColorUsage(showAlpha: true, hdr: true)] private Color _topColor;
    [SerializeField, ColorUsage(showAlpha: true, hdr: true)] private Color _botColor;
    [SerializeField] private float _metallic;
    [SerializeField] private float _smoothness;
    [SerializeField] private float _topLine;
    [SerializeField] private float _botLine;
    [SerializeField] private float _alpha;
    [SerializeField] private float _alphaParts;

    [Header("Ice material settings:")]
    [SerializeField] private float _metallicIce;
    [SerializeField] private float _smoothnessIce;
    [SerializeField] private float _normalIce;
    [SerializeField] private Texture2D _textureIce;
    [SerializeField, ColorUsage(showAlpha: true, hdr: true)] private Color _baseColorIce;
    [SerializeField, ColorUsage(showAlpha: true, hdr: true)] private Color _fresnelColor;

    [Header("Player material settings:")]
    [SerializeField] private Material _wear;
    [SerializeField] private Material _hat;
    [SerializeField] private Material _boots;
    [SerializeField, ColorUsage(showAlpha: true, hdr: true)] private Color _playerWear;
    [SerializeField, ColorUsage(showAlpha: true, hdr: true)] private Color _playerHat;
    [SerializeField, ColorUsage(showAlpha: true, hdr: true)] private Color _playerBoots;
    public List<Barrier> BarrierPrefabs => _barrierPrefabs;

    public void InitMaterials(float offsetIceSpeed)
    {
        InitMaterial(_full, _alpha);
        InitMaterial(_parts, _alphaParts);
        InitIce(_ice, offsetIceSpeed);
        InitPlayer();
        InitPortal();
    }

    private void InitMaterial(Material material, float alpha)
    {
        material.DOColor(_baseColor, "_BaseColorCrystal", 1.5f);
        material.DOColor(_topColor, "_TopColorCrystal", 1.5f);
        material.DOColor(_botColor, "_BottomColorCrystal", 1.5f);
        material.DOFloat(_metallic, "_MetallicCrystal", 1.5f);
        material.DOFloat(_smoothness, "_SmoothnessCrystel", 1.5f);
        material.DOFloat(_topLine, "_TopLineCrystal", 1.5f);
        material.DOFloat(_botLine, "_BottomLineCrystal", 1.5f);
        material.DOFloat(alpha, "_AlphaCrystal", 1.5f);
    }

    private void InitIce(Material material, float offsetIceSpeed)
    {
        material.DOFloat(_metallicIce, "_MetallicIce", 1.5f);
        material.DOFloat(_smoothnessIce, "_SmoothnessIce", 1.5f);
        material.DOColor(_fresnelColor, "_FresnelColorIce", 1.5f);
        material.DOColor(_baseColorIce, "_BaseColorIce", 1.5f);
        material.DOFloat(_normalIce, "_NormalIce", 1.5f);
        material.DOFloat(offsetIceSpeed, "_OffsetIceY", 1.5f);
        material.SetTexture("_IceTexture", _textureIce);
    }

    private void InitPlayer()
    {
        _wear.DOColor(_playerWear,  1.5f);
        _hat.DOColor(_playerHat, 1.5f);
        _boots.DOColor(_playerBoots, 1.5f);
    }

    private void InitPortal()
    {
        _portal.SetColor("_BaseColorPortal", _portalColor);
    }
}
