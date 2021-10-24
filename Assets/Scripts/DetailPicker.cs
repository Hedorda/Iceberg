using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailPicker : MonoBehaviour
{
    [SerializeField] private Material selectedMaterial;
    
    private Renderer selectedDetailRenderer;
    private GameObject currentDetail;
    private Material oldMaterial;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(selectedDetailRenderer!=null) selectedDetailRenderer.material = oldMaterial;
                var selectedDetail = hit.collider.gameObject;
                if ( currentDetail!=selectedDetail)
                {
                    currentDetail = selectedDetail;
                    selectedDetailRenderer = selectedDetail.GetComponent<MeshRenderer>();
                    oldMaterial = selectedDetailRenderer.material;
                    selectedDetailRenderer.material = selectedMaterial;
                }
                
            }
        }
    }
}
