using UnityEngine;

public class VampirismAbilityAreaView : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] protected VampirismAbility _vampirismAbility;
    
    private int _steps = 50;
    
    private float _radius;

    private void Awake()
    {
        _radius = _vampirismAbility.Range;
        DrawCircleArea();
        HideArea();
    }

    private void OnEnable()
    {
        _vampirismAbility.StartUsing += ShowArea;
        _vampirismAbility.EndEffect += HideArea;
    }

    private void OnDisable()
    {
        _vampirismAbility.StartUsing -= ShowArea;
        _vampirismAbility.EndEffect -= HideArea;
    }

    private void ShowArea() 
    {
        _lineRenderer.enabled = true;
    }

    private void HideArea() 
    {
        _lineRenderer.enabled = false;    
    }

    private void DrawCircleArea() 
    {
        _lineRenderer.positionCount = _steps;
       
        float radianOffset = 2;

        for (int currentStep = 0; currentStep < _steps; currentStep++) 
        {
            float radiusStep = (float) currentStep/ _steps;
            float currentRadian = radiusStep * radianOffset * Mathf.PI;
            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);
            float x = xScaled * _radius;
            float y = yScaled * _radius; 

            Vector3 currentPosition = new Vector3(x, y, 0);

            _lineRenderer.SetPosition(currentStep,currentPosition);
        }
    }
}
