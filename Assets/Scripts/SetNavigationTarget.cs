using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SetNavigationTarget : MonoBehaviour
{
    [SerializeField]
    private Dropdown navigationTargetDropDown;
    [SerializeField]
    private List<Target> navigationTargetObjects = new List<Target>();
    private NavMeshPath path;
    private LineRenderer line;
    private Vector3 targetPosition = Vector3.zero;
    // Start is called before the first frame update
    private void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
    }
    private void Update(){
        NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
        line.positionCount = path.corners.Length;
        line.SetPositions(path.corners);
    }
    public void SetCurrentNavigationTarget(int selectedValue){
        targetPosition = Vector3.zero;
        string selectedText = navigationTargetDropDown.options[selectedValue].text;
        Target currentTarget = navigationTargetObjects.Find(x => x.Name.Equals(selectedText));
        if(currentTarget != null ){
            targetPosition = currentTarget.PositionObject.transform.position;
        }
    }

}
