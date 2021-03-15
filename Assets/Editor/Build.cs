using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class Build : Editor
{
	[MenuItem("Editor/Build")]
    public static void Run()
	{
		BuildPlayerOptions opt = new BuildPlayerOptions();
		opt.scenes = EditorBuildSettings.scenes.Select(scene => scene.path).ToArray();
		opt.locationPathName = "BatBuildTest.apk";
		opt.target = BuildTarget.Android;
		opt.options = BuildOptions.None;
		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "TEST_DEF");
		BuildPipeline.BuildPlayer(opt);
		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "");
	}
}
