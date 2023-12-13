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

### 弾を発射しよう

1. 弾のスプライトを配置しよう
   ロケットから弾を発射する流れは次のようになります。

   1. 弾を１つだけ表示して画面上方向に移動するようにします。
   1. 作成した弾をもとにして弾のPrefab（設計図）を作ります。
   1. スペースキーを押すたびにPrefabから弾のインスタンスを作ります。

   ロケットを配置した時と同じように、弾のスプライトを画面上に配置しましょう。
   プロジェクトビューから「bullet」を選択し、シーンビューにドラッグ＆ドロップして下さい。
   弾を配置する座標は後ほどスクリプトで指定するので、ここでは適当でかまいません。

   ![Alt text](image-5.png)

   弾が配置できたら、次は弾を上方向に移動させるスクリプトを作成します。
   プロジェクトビューで右クリックし「Create」→「C# Script」でスクリプトを作成し、ファイル名を「BulletController」に変更します。

   ![Alt text](image-6.png)

   作成した「BulletController.cs」を開き、次のスクリプトを入力して下さい。

   ```cs
   using UnityEngine;
   using System.Collections;

   public class BulletController : MonoBehaviour {
      void Update () {
         transform.Translate (0, 0.2f, 0);

         if (transform.position.y > 5) {
            Destroy (gameObject);
         }
      }
   }
   ```
   ここでもロケットを動かしたときと同じようにTranslate関数を使って弾を毎フレーム0.2fづつ上方向（y軸方向）に移動しています。

   ただし、このままだと弾が画面の外にでてからも動き続けることになります。
   見えない場所で動かし続けるのはCPUの無駄使いなので、画面の上端（y=5）をこえた場合にはDestroyメソッドを使って弾を破棄します。

   ファイルを保存できたら、ロケットの時と同様にスクリプトをアタッチしましょう。
   プロジェクトビューの「BulletController」を「bullet」にドラッグ＆ドロップして下さい。

   ![Alt text](image-7.png)

   スクリプトがアタッチできたら、ゲームを実行してみてください。弾が上方向に移動しましたね。

   ![Alt text](image-8.png)

   Prefabが作れたら、画面上に配置した弾は不要です（設計図があればいつでも作れるため）ヒエラルキービューから「bulletPrefab」を選択し、右クリック→「Delete」を選択します。

   ![Alt text](image-9.png)

1. Prefabからインスタンスを作ろう

   次はスペースキーが押されるたび、弾のPrefabをから弾のインスタンス（複製）を作るスクリプトを作成しましょう。

   前回作成した「RocketController.cs」を開いて次のようにスクリプトを修正します。

   ```cs
   using UnityEngine;
   using System.Collections;

   public class RocketController : MonoBehaviour {

      public GameObject bulletPrefab;

      void Update () {
         if (Input.GetKey (KeyCode.LeftArrow)) {
            transform.Translate (-0.1f, 0, 0);
         }
         if (Input.GetKey (KeyCode.RightArrow)) {
            transform.Translate ( 0.1f, 0, 0);
         }
         if (Input.GetKeyDown (KeyCode.Space)) {
            Instantiate (bulletPrefab, transform.position, Quaternion.identity);
         }
      }
   }
   ```

   このスクリプトではGetKeyDown関数を使ってスペースキーが押されたことを検知し、弾のPrefabから弾のインスタンスを作っています。
   GetKeyDown関数はGetKey関数と違って、キーが押下された時に一度だけtrueになる関数です。
   　
   弾のPrefabからインスタンスを作るために、Instantiate関数を使っています。
   Instantiate関数は、第一引数にPrefab、第二引数にインスタンスを生成する位置、第三引数にはインスタンスの回転角を指定します。
   ここではRocketControllerの中でtransform.positionと書いているので、ロケットの位置に弾を生成しています。

   最後に、作成したbulletPrefabとスクリプト内で宣言した変数とを関連付けます。
   ヒエラルキービューからrocketを選択し、インスペクタから「RocketControllerスクリプト」の項目を探し、「bullet Prefab」の欄に、プロジェクトビューから「bulletPrefab」をドラッグ＆ドロップして下さい。

   ![Alt text](image-10.png)

   ここまで出来たら、実行してみましょう。スペースキーを押すたびに弾が発射されるようになりました。

### 隕石を落下させよう
1. テクスチャからスプライトをスライスする
   ここまでに出てきたロケットや弾のテクスチャは、１枚のテクスチャに１つの画像が描かれていました。
   一方、隕石の画像は１枚のテクスチャに８つのスプライトが描かれています。このようなテクスチャをテクスチャアトラスとよび、テクスチャアトラスを使うことで実行時の計算効率が良くなります。

   テクスチャアトラスからスプライトを切り出す方法は次のとおりです。
   まずプロジェクトビューで「Rock」を選択し、インスペクタの「Sprite Mode」を「Multiple」に設定し、「Sprite Editor」ボタンを押して下さい。

   ![Alt text](image-11.png)

   「Sprite Editor」が起動するので、画面左上の「Slice」ボタンをクリックし、「Type」が「Automatic」になっていることを確認してから、「Slice」ボタンを押して下さい。

   ![Alt text](image-12.png)

   スプライトの周辺にうっすらとスライスのための枠線が表示されています。問題なければ画面中央の「Apply」ボタンを押して下さい。

   スライスの範囲を修正したい場合には、修正したいスプライトを選択し、スライス領域を指定します。

   ![Alt text](image-13.png)

1. 隕石を表示しよう
   スプライトを個別に切り出すことが出来たので、正しくスライス出来たか確認しましょう。
   プロジェクトビューで「Rock」の「▶」ボタンをクリックすると、スライスされたスプライトが表示されます。
   　
   スライスされた隕石から１つを選択してシーンビューに配置します。
   配置する座標はのちほどスクリプトから決めるのでここでは適当で大丈夫です。

   ![Alt text](image-14.png)

1. 隕石を落下させよう
   隕石が落下してくるようにスクリプトを作成しましょう。
   プロジェクトビューで右クリックから「Create」→「C# Script」を選択し、出来たファイルの名前を「RockController」に変更します。ファイルを開いて次のスクリプトを入力して下さい。

   ```cs
   using UnityEngine;
   using System.Collections;

   public class RockController : MonoBehaviour {

      float fallSpeed;
      float rotSpeed;

      void Start () {
         this.fallSpeed = 0.01f + 0.1f * Random.value;
         this.rotSpeed = 5f + 3f * Random.value;
      }

      void Update () {
         transform.Translate( 0, -fallSpeed, 0, Space.World);
         transform.Rotate(0, 0, rotSpeed );

         if (transform.position.y < -5.5f) {
            Destroy (gameObject);
         }
      }
   }
   ```

   隕石が回転しながら落下するようにTranslate関数とRotate関数を使っています。
   また、Randomメソッドを使って落下速度が隕石ごとに変わるようにしています。
   隕石が画面下端を超えた場合は、Destroyメソッドで自分自身のオブジェクトを破棄しています。

   スクリプトが作成できたら、隕石オブジェクトにアタッチしましょう。
   プロジェクトビューから「RockController.cs」を選択し、ヒエラルキービューの「rock_0」にドラッグ＆ドロップして下さい。

   ![Alt text](image-15.png)

   実行してみて、隕石が回転しながら落下してくるのを確認しましょう。

1. 隕石を時間とともに生成する

   ゲーム中で生成されるオブジェクトは、Prefab化してスクリプトで生成するのが定石です。
   流れとしては弾を作ったときと同様、次のようなステップです。

   1. 生成したいオブジェクトをPrefab化する
   1. スクリプトでPrefabからインスタンスを作る
   1. Prefabの実体とスクリプト内の変数を関連付ける

   まずは隕石のPrefabを作成しましょう。ヒエラルキービューから「rock_0」を選択し、プロジェクトビューにドラッグ＆ドロップします。
   作成したPrefabの名前を「RockPrefab」に変更します。

   ![Alt text](image-16.png)

   Prefabができたら画面上の隕石は不要なので消しておきます。
   ヒエラルキービューの「RockPrefab」を右クリックし「Delete」を選択して下さい。

   ![Alt text](image-17.png)

   弾はスペースキーが押されたタイミングでインスタンスを生成していました。
   今回は、一定時間たつと自動的に隕石のインスタンスを生成するようにしましょう。

   プロジェクトビューで右クリックして「Create」→「C# Script」を選択し、出来たファイルの名前を「RockGenerator」に変更します。
   ファイルを開いて次のスクリプトを入力して下さい。

   ```cs
   using UnityEngine;
   using System.Collections;

   public class RockGenerator : MonoBehaviour {

      public GameObject rockPrefab;

      void Start () {
         InvokeRepeating ("GenRock", 1, 1);
      }

      void GenRock () {
         Instantiate (rockPrefab, new Vector3 (-2.5f + 5 * Random.value, 6, 0), Quaternion.identity);
      }
   }
   ```

   隕石を１秒に１回生成するために、InvokeRepeating関数を使っています。InvokeRepeating関数は第一引数の関数を第二引数の秒数ごとに実行してくれる結構便利な関数です。
   ここではGenRock関数を呼び出し、その中でランダムな位置に隕石を生成しています。

   ファイルが生成できたところでゲームオブジェクトにRockGeneratorスクリプトをアタッチします。
   アタッチする適切なオブジェクトが無いので、ヒエラルキービューの「Create」→「Create Empty」で空のオブジェクトを生成します。

   ![Alt text](image-18.png)

   作成したオブジェクトにスクリプトをアタッチします。ヒエラルキービューの「GameObject」にプロジェクトビューの「RockGenerator」をドラッグ＆ドロップして下さい。

   ![Alt text](image-19.png)

   最後にスクリプト内で宣言したRockPrefab変数に、Prefabの実体を代入します。ヒエラルキービューで「GameObject」を選択して、インスペクタに表示される「Rock Prefab」の欄にプロジェクトビューの「RockPrefab」をドラッグ＆ドロップします。

   ![Alt text](image-20.png)

   ゲームを実行してみて隕石が次々と落ちてくることを確認しましょう。

### 当たり判定をしよう

1. Unityで当たり判定をするには

   Unityで当たり判定をする場合には次の２通りがあります。

   1. 自前でオブジェクトの距離を計算する方法
   1. UnityのPhysicsを使う方法

   今回の記事では②のPhysicsを使った当たり判定の方法を紹介します。

   Physicsで当たり判定をする場合、自前で何かを計算する必要はありません。
   オブジェクト同士が衝突した場合にはUnityが特定の関数を呼び出してくれます。
   具体的には、衝突したオブジェクトにアタッチされているスクリプトのOnCollisionEnter関数が呼びだされます。

   Phsyicsを使って衝突検知をする場合、

   - 両方のオブジェクトにColliderコンポーネントをアタッチ
   - 少なくとも一方にはRigidbodyコンポーネントをアタッチ

   する必要があります。

   今回は隕石と弾の当たり判定をしたいので、両方のオブジェクトにColliderコンポーネントをアタッチし、弾にはRigidbodyコンポーネントをアタッチしましょう。

   Physicsを使った当たり判定についても「Unityの教科書」にイラスト付きで解説しています。是非参考にしてみて下さい。
