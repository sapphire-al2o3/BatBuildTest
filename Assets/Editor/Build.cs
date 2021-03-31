using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Threading.Tasks;

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

    [MenuItem("Editor/Build 2")]
    public static void Run2()
    {
        Run2Async();
    }

    static async void Run2Async()
    {
        Debug.Log("Start");
        BuildPlayerOptions opt = new BuildPlayerOptions();
        opt.scenes = EditorBuildSettings.scenes.Select(scene => scene.path).ToArray();
        opt.locationPathName = "BatBuildTest2.apk";
        opt.target = BuildTarget.Android;
        opt.options = BuildOptions.None;
		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "TEST_DEF");
		while (EditorApplication.isCompiling)
        {
            await Task.Delay(1000);
        }
        Debug.Log("Build");
        BuildPipeline.BuildPlayer(opt);
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "");
    }
}
