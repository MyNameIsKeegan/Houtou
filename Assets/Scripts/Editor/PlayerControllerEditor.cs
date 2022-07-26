using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShootersController))]
public class PlayerControllerEditor : Editor
{
    private ShootersController shootersController;

    private void OnEnable()
    {
        shootersController = (ShootersController) target;
    }

    // public override void OnInspectorGUI()
	// {
	// 	if (GUILayout.Button("Add Shooter"))
	// 	{
			
	// 	}

    //     if (GUILayout.Button("Remove Shooter"))
    //     {
            
    //     }

	// 	// Draw default inspector after button...
	// 	base.OnInspectorGUI();
	// }
}
