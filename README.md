# 医保异常文件抓取上传

医保异常文件抓取上传这个软件是我在福建中医药大学附属第三人民医院信息科见习的时候写的小软件。当收费处的医保接口出现异常时，信息科人员需要亲自去收费处复制医保异常文件并进行分析。通过医保异常文件抓取上传软件，收费处工作人员可一键抓取医保异常文件并上传至医院信息科提供的远程服务器共享目录中。

软件版本：v1.0

License: MIT

编写日期：2018 年 8 月 8 日

## 简介
该应用采用 C# 语言编写。在使用之前请先配置`config`文件。

主要的功能如下：

- 配置需要抓取的医保异常文件目录及文件名、用户标识等
- 一键抓取指定的医保异常文件
- 一键上传指定的医保异常文件至远程服务器共享目录

## 概览

### 主界面
![](https://github.com/jl223vy/miefcnu/raw/master/Img/mainPage.jpg)


## 使用方法

### 配置 config 文件
![](https://github.com/jl223vy/miefcnu/raw/master/Img/configPage.jpg)

配置内容如下：

|键key|值value|样例|
|---|---|---|
|sourcePath|抓取目录地址|`C:\Users\Lenovo\Desktop\source\`|
|files|抓取的异常文件名，若有多个文件请用分号`;`隔开|`request.txt;reply.txt`|
|host|远程服务器共享目录地址|`\\192.168.1.1\soft\医保\error`|
|username|远程服务器共享目录用户名|`Guest`|
|password|远程服务器共享目录密码|`2333`|
|userID|抓取用户标识|`001`|

### 执行操作

- 创建应用的快捷方式至桌面
- 当医保接口出现异常时打开应用
- 关闭医保接口
- 分别点击“抓取”和“上传”按钮
- 打开医保接口
- 关闭应用


## 下载

[Download](https://github.com/jl223vy/miefcnu/raw/master/App/CatchnUpload-v1.0.zip)

PS：提供 .NET framework 2.0 和 .NET framework 4.0 下载使用。

