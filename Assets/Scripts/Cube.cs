using DG.Tweening;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private bool isInteractive = true;
    private int tileIndex;
    

    public void SetTileIndex(int index)
    {
        tileIndex = index;
    }

    void Start()
    {
        
    }

    void OnMouseDown()
    {
        if (!isInteractive) return;

        
        Transform submitArea = GameObject.Find("SubmitArea").transform;
        Vector3 targetPosition = submitArea.position + Vector3.right * submitArea.childCount;
        transform.DOMove(targetPosition, 0.5f).OnComplete(() =>
        {
            transform.SetParent(submitArea);
            GameManager.Instance.CheckForMatch();
        });

        SetInteractive(false);
    }

    public void SetInteractive(bool interactive)
    {
        isInteractive = interactive;
        
    }
}
