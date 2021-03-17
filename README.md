# BatBuildTest

build.batを実行してbatchmodeでビルドすると起動時にクラッシュするapkが作成できる

```
The file '/data/app/com.Test.BatBuildTest-2/base.apk/assets/bin/Data/level0' is corrupted! Remove it and launch unity again!
[Position out of bounds!]
```

`BuildPipeline.BuildPlayer` でビルドする前に `PlayerSettings.SetScriptingDefineSymbolsForGroup` で `TEST_DEF` シンボルを追加すると次のコードようにシリアライズされているデータがおかしくなって起動時のシーン読み込みでクラッシュしてしまう

```csharp
public class Test : MonoBehaviour
{
    public int a;
#if TEST_DEF
    public bool aa;
#endif
    public int b;
#if TEST_DEF
    public byte bb = 100;
#endif
    public int c;
}
```
