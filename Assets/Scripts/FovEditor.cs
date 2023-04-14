using UnityEditor;
using UnityEngine;

public class FovEditor : Editor
{


    [CustomEditor(typeof(EnemyFov))]
    private void OnSceneGUI()
    {
        EnemyFov fov = (EnemyFov)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.FovRadius);

        Vector3 viewAngle01 = DirectonFromAngle(fov.transform.eulerAngles.y, -fov.FovAngle / 2);
        Vector3 viewAngle02 = DirectonFromAngle(fov.transform.eulerAngles.y, fov.FovAngle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle01 * fov.FovRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle02 * fov.FovRadius);

        if (fov.canSeePlayer)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fov.transform.position, PlayerMovement.instance.transform.position);
        }
    }

    private Vector3 DirectonFromAngle(float eulerY, float angleIndegrees)
    {
        angleIndegrees += eulerY;

        return new Vector3(Mathf.Sin(angleIndegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleIndegrees * Mathf.Deg2Rad));
    }
}
