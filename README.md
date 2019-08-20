# [ET地址](https://github.com/egametang/ET)

# Plus 内容

[TOC]

## 1. 自动生成代码

- 原因: 每次都要复制，再改，比较烦

- 备注: 只作用在Hotfix和Model文件夹下创建的脚本

- 1. 补全Entity
  - 使用: 输入名字 `***Entity`

- 2. 补全Component
  - 使用: 输入名字 `***Component`

- 3. 补全Event
  - 使用: 输入名字 `***Event`

- 4. 补全Config
  - 额外: 还会在 `Assets/Res/Config` 生成 txt, 并加到 `Assets/Bundles/Independent/Cofig` 
  - 使用: 输入名字 `***Config`

- 5. 补全命名空间
  - 使用: 输入任意名字

## 2. 永远从`Init`开始游戏

- 原因: 有时候在Map场景编辑时，我想测试游戏，我需要点击`Init`场景，因为游戏都是从这个场景开始的

- 使用方式: 在`Tools/Plus/Start Scene`打开Window, 可以设置每次都开始的场景名和是否启用此功能

## 3. Scp同步资源

- 原因: 不会用 Rsync同步

- 使用: 在`Tools/Plus/Scp Window`打开

- 备注: 每次同步会覆盖原有资源，但不会删除原有资源

## 4. 工具类

- 原因: 简化重复代码

- 4.1 UIUtil
  - 打开: 有一个UILogin, 打开一个Panel: UIUtil.OpenPanel<UILoginComponnet>("UILogin");
  - 获取: UIUtil.GetPanel<UILoginComponent>("UILogin")
  -  关闭: UIUtil.ClosePanel("UILogin")

- 4.2 SceneUtil
  - 加载场景:
```C#
SceneUtil.LoadScene("Map", () =>
				{
					Debug.Log("加载完毕");
				}).Coroutine();
```

- 4.3 ResourceUtil

  - 加载一个叫 click 的 AudioClip

    ```C#
    ResourceUtil.Load<AudioClp>("click");
    ```

  - 卸载 click
  
    ```C#
    ResourceUtil.Unload("click");
    ```
  
- 4.4 ConfigUtil

  - 获取 Config

    ```C#
    UnitConfig unitConfig = ConfigUtil.GetConfig<UnitConfig>(2001);
    ```

  - 获取Json
  
    ```C#
    string json = ConfigUtil.GetJson<TestConfig>(2001);
    ```
  
    

## 5. 事件管理者 (EventMgr)

- 原因: 我以前用过一段时间KBEngine, 这个是我参考KBEngine改的

- 备注: 只需要Register, 不需要Deregister(), 自动Deregister

- 演示: 我想在WorldComponent调用场景所有PlayerComponent的Jump方法

- ```C#
  // Player
  public class PlayerComponent : Component {
      void Awake() {
          this.Register("Jump");
      }
      
      public void Jump() {
          // TODO 跳一跳
      }
  }
  ```

- ```C#
  // World
  public class WorldComponent : Component {
      void Start() {
          this.Send("Jump");
      }
  }
  ```

## 6. 音频管理

- 第一步: 在Hotfix的Init.cs里

  - ```C#
    Game.Scene.AddComponent<AudioEntity>();
    ```

- 第二步:  使用

  - ```C#
    // 设置背景音乐
    Game.Scene.GetComponent<AudioEntity>().SetBGM("bgm_name");
    
    // 播放点击声音
    Game.Scene.GetComponent<AudioEntity>().PlaySound("click");
    ```
    
## 7. 提示信息面板

- 原因: 每次都要做这个UI, 所以我已经做好了

- 使用: UIUtil.OpenPanel<TipPanelEntity>(UIType.TipPanel)?.SetTip("提示信息");

## 8. 额外的资源

### 8.1 字体

- 在 `Res/Font/font_fatman`有个字体，是方正胖娃_GBK，挺好看的，商用需要去购买，这里学习使用是可以的

### 8.2 游戏内控制台

- 作用: 导出到手机或PC端，也可以看到Console的信息（和Unity的Console一样）

- 这个Asset Store插件，从`Res/Prefab/IngameDebugConsole`拖拽到场景里面

### 8.3 Dotween免费版

- 在`Plugins/Demigiant`里，这里是免费版，够我用了

### 8.4 行为树

- 这里用的是商店里面的 `Panda BT Tree`, 免费的行为树里面是比较好使的，行为树在txt文件里面编辑，更多可以看案例，用起来是非常简单的

