# Sample Shooting

## Procedure

### ロケットを動かそう
   1. プロジェクトを作成しよう
   画面の設定を行いましょう。今回は縦長の画面レイアウトにするのでGameタブをクリックし、アスペクト比を選択します。
   Unityには縦長のアスペクト比が用意されていないため、一番下の「＋ボタン」をクリックしてTypeに「Aspect Ratio」、Width&Heightに「9:16」と入力して下さい。
   ![Alt text](image.png)

   2. ロケットを配置しよう
   準備が出来たところで、まずはUnityでのゲーム作りの第一歩として画像を画面に出しましょう。
   Unity2Dでは画面上に表示する画像のことを「スプライト」と呼びます。
   今後はスプライトという呼び名を使うので覚えておいて下さいね！

   では先ほどプロジェクトビューに登録したロケットのスプライト（rocket）をシーンビューにドラッグ＆ドロップして下さい。
   ![Alt text](image-1.png)
   シーンビューに配置されたスプライトがヒエラルキービューにも一覧として表示されています。このようにシーンビュー上のスプライトとヒエラルキービューのリストは対応していることを覚えておいて下さい。

   ロケットのスプライトを表示する場所はインスペクタから変更できます。
   ヒエラルキービューで「rocket」を選択すると、Unityエディタ右側のインスペクタにロケットの詳細情報が表示されます。

   ここでは、「Transform」項目のPositionを「0,-4,0」に設定します。
   ![Alt text](image-2.png)

   1. ロケットを動かそう
   左右キーの入力に応じてロケットを動かすために、C#スクリプトを作成します。
   　
   プロジェクトビューで右クリックし、「Create」→「C# Script」を選択して下さい。
   作成したファイル名をRocketControllerに変更しておきましょう。
   ![Alt text](image-3.png)

   RocketControllerをダブルクリックしてエディタを開き、次のスクリプトを入力して下さい。
   ```cs
   using UnityEngine;
   using System.Collections;

   public class RocketController : MonoBehaviour {
      void Update () {
         if (Input.GetKey (KeyCode.LeftArrow)) {
            transform.Translate (-0.1f, 0, 0);
         }
         if (Input.GetKey (KeyCode.RightArrow)) {
            transform.Translate ( 0.1f, 0, 0);
         }
      }
   }
   ```
   Input.GetKey関数を使って引数に指定したキーが押されているかを調べています。
   キーが押されていた場合にはTranslate関数を使ってロケットの位置を移動させています。
   Translate関数は現在の位置から引数に与えたぶんだけ移動させる関数です。引数に与えた座標に動かすのではないことに注意して下さい。

   スクリプトが完成したら、作成したスクリプトをロケットにアタッチしましょう。
   Unityでは、スクリプトをオブジェクトにアタッチすることでオブジェクトがスクリプトどおりに動くようになります。
   　
   プロジェクトビューから「RocketController」を選択し、ヒエラルキービューの「rocket」にドラッグ＆ドロップして下さい。
   ![Alt text](image-4.png)
