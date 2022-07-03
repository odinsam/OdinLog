# OdinLog

[![Nuget](https://img.shields.io/nuget/v/OdinLog)](https://www.nuget.org/packages/OdinLog/) ![Nuget](https://img.shields.io/nuget/dt/OdinLog) ![](https://img.shields.io/badge/version-1.0.6-brightgreen.svg) [![Build Status](https://travis-ci.com/odinsam/OdinLog.svg?branch=master)](https://travis-ci.com/odinsam/OdinLog) ![](https://img.shields.io/github/issues/odinsam/OdinLog) ![](https://img.shields.io/github/forks/odinsam/OdinLog) ![](https://img.shields.io/github/stars/odinsam/OdinLog) ![](https://img.shields.io/badge/platform-.Net_Core_5.0-brightgreen.svg) ![](https://img.shields.io/github/license/odinsam/OdinLog) [![](https://img.shields.io/badge/Blog-odinsam.com-blue.svg)](https://odinsam.com)

**简介:**

> OdinLog 简单日志组件

### changelog

v1.0.2

-   添加依赖注入，增加保存数据库 [详细介绍](https://odinsam.com/articles/86b2.html)

v1.0.1

-   添加 log 返回类型 LogResponse { LogId,LogLevel }

v1.0.0

-   按照 Info Waring Error 生成对应文件夹
-   按照 日期 归类文件夹
-   每个日志文件超过 5M，生成新的日志文件
