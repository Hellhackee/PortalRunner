using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject _base;

    private bool _canRotate = true;

    public void OnRestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnLeftButtonClicked()
    {
        if (_canRotate == true)
        {
            _canRotate = false;
            _base.transform.DORotate(new Vector3(60f, 0f, 0f), 0.2f, RotateMode.LocalAxisAdd).OnComplete(AfterRotation);
        }
    }

    public void OnRIghtButtonClicked()
    {
        if (_canRotate == true)
        {
            _canRotate = false;
            _base.transform.DORotate(new Vector3(-60f, 0f, 0f), 0.2f, RotateMode.LocalAxisAdd).OnComplete(AfterRotation);
        }
    }

    private void AfterRotation()
    {
        _canRotate = true;
    }
}
