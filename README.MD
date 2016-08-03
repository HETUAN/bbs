# asp.net core mvc test demo

## 使用的技术
1. asp.net core mvc
2. bootstrap+Jquery
3. mysql 数据库
4. Dapper(轻量级ORM)
5. SapientGuardian.MySql.Data一个开源项目用于操作MySql
6. VSCode 编辑器（当然会有各种插件）

## 开发过程

1. 创建一个web项目

``` bash
mkdir webapp
cd webapp
dotnet new -t web
```

2. 创建一个Console控制台程序

``` bash
mkdir consoleApp
cd consoleApp
dotnet new
```

3. 将部分web项目的部分依赖复制到console项目中的dependencies节点中

``` bash

  "dependencies": {
    "Microsoft.AspNetCore.Diagnostics": "1.0.0",
    "Microsoft.AspNetCore.Mvc": "1.0.0",
    "Microsoft.AspNetCore.Server.IISIntegration": "1.0.0",
    "Microsoft.AspNetCore.Server.Kestrel": "1.0.0",
    "Microsoft.AspNetCore.StaticFiles": "1.0.0",
    "Microsoft.Extensions.Logging.Console": "1.0.0",
    "Microsoft.AspNetCore.Razor.Tools": {
      "version": "1.0.0-preview2-final",
      "type": "build"
    },
    "Microsoft.NETCore.App": {
      "type": "platform",
      "version": "1.0.0"
    },
    # 以下为后来添加 如果想添加相应依赖在VSCode中输入相应的引用起始字母便可以出现相应的提示（必须要安装C#插件）
    "System.Data.SqlClient": "4.1.0", # 如果想链接SqlServer数据库需要此依赖即可
    "Dapper": "1.50.0-rc2b", # 轻量级ORM可以与"System.Data.SqlClient"或"SapientGuardian.MySql.Data"依赖相互合作而分别操作SqlServer或MySql数据库
    "System.Drawing":"1.0.0-beta004", # 画图的依赖，此引用只限于Windows平台使用Linux并不支持
    "Microsoft.AspNetCore.Http":"1.0.0",
    "Microsoft.AspNetCore.Http.Abstractions":"1.0.0",
    "Microsoft.AspNetCore.Session": "1.0.0", # Session 记录用户登录状态
    "Microsoft.Extensions.Caching.Memory": "1.0.0", # 好像是与Session配合使用
    "SapientGuardian.MySql.Data": "6.9.8-rc2-007",
    "Newtonsoft.Json": "9.0.1" # Json相关操作
  }

```
执行命令：
``` bash
dotnet restore
```
还原这些项目依赖

4. 创建bower.js文件

相关说明在另一篇文章中
内容是：
``` bash
{
  "name": "ConsoleApp",
  "directory": "wwwroot/lib",
  "private": true,
  "dependencies": {
    "bootstrap": "3.3.6",
    "jquery": "2.2.3",
    "jquery-validation": "1.15.0",
    "jquery-validation-unobtrusive": "3.2.6",
    "vue": "latest" # 解析MarkDown时使用
  }
}

```

5. 相关目录创建

创建Controllers文件夹存放MVC的控制器
创建Models文件夹存放模型
创建Views文件夹存放视图文件
创建Services文件夹存放相关业务逻辑类
创建Respositories文件存放数据库操作相关类
 
## 程序部署
1. Ubuntu 14
2. Nginx请求转发
3. supervisor管理程序

