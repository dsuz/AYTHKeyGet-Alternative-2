==========================
AYTHKeyGet Alternative 2
==========================

【説明】

AYTHKeyGet AlternativeのReadMeに記載していた「既知の問題」1.に対応するためのものです。
PACファイルを使っていない、あるいはAYTHKeyGet Alternativeで特に問題ない場合はこちらを使う必要はありません。

【セットアップ】

1. RadikaがインストールされているフォルダのAYTHKeyGet.exeのファイル名をAYTHKeyGet.original.exeに変更します。

2. 以下のファイルをRadikaがインストールされているフォルダにコピーします。

AYTHKeyGet.exe
csExWB.dll
Interop.ComUtilitiesLib.dll
ComUtilities.dll

3. コマンドプロンプトを起動し、Radikaをインストールされているパスに移動して、次のコマンドを入力します。
regsvr32 ComUtilities.dll

【アンインストール】

1. コマンドプロンプトを起動し、Radikaをインストールされているパスに移動して、次のコマンドを入力します。
regsvr32 /u ComUtilities.dll

2. 以下のファイルをRadikaがインストールされているフォルダから削除します。

AYTHKeyGet.exe
csExWB.dll
Interop.ComUtilitiesLib.dll
ComUtilities.dll

3. 名前を変更していたAYTHKeyGet.original.exeのファイル名をAYTHKeyGet.exeに戻します。

【使っているライブラリ】

csexwb2(The most complete .NET Webbrowser control wrapper)というライブラリを使っています。

csexwb2
https://code.google.com/p/csexwb2/