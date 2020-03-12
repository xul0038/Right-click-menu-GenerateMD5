# Right-click-menu-GenerateMD5
(自用)windows右键菜单计算文件md5

运行环境: Windows + .Net Core 3.1

可添加到右键菜单，也可把文件直接拖进exe，支持多文件同时算

## QA

> Q：用管理员权限运行bat，出现cmd窗口闪退，右键菜单也没生效  
  A：管理员运行powershell，定位到这个文件夹，运行```& '.\(管理员权限)添加.bat'```命令

> Q：多选文件算md5时，出现多个窗口而不是单个窗口  
  A：简单右键菜单的限制，实现多选打开需要更复杂的技术，~~我摸了~~。可以改用多选拖拽到exe的方法

> Q：移动了文件夹之后没办法移除菜单了  
  A：文件夹动了bat就失效了，可手动删除注册表HKEY_CLASSES_ROOT\*\shell\MD5
