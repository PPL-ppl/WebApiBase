# Readme

## 目录结构
跳过SSL认证 git config --global http.sslVerify "false"
Common-公共文件
~~~
BaseController.cs：自定义路由模版

~~~  

Controllers-API接口  
DTO-数据传输对象(Data Transfer Object)  
IRepository-DB 操作接口   
Repository-DB实现接口  
IService-Service服务接口  
Service-Service服务实现接口  
MOdel-与表对应的实例
## 引用说明
1、Contorller层参数传递建议不要使用HashMap，建议使用数据模型定义
2、Controller层里可以做参数校验、异常抛出等操作，但建议不要放太多业务逻辑，业务逻辑尽量放到Service层代码中去做
3、Service层做实际业务逻辑，可以按照功能模块做好定义和区分，相互可以调用
4、功能模块Service之间引用时，建议不要渗透到DAO层，基于Service层进行调用和复用比较合理
5、业务逻辑层Service和数据库DAO层的操作对象不要混用。
Controller层的数据对象不要直接渗透到DAO层（或者mapper层）；
同理数据表实体对象Entity也不要直接传到Controller层进行输出或展示。
## 第三方组件
- orm-freesql 数据库sqlserver   仓储模式可使用自定义或者freeSql提供的
- JSON数据处理-Newtonsoft.Json
- 依赖注入-AutoFac
- AutoMapper实现模型映射
- 认证授权-JWT自定义策略授权
- 提供 Redis 做缓存处理,消息队列
- 使用 Swagger 做api文档
- 使用 MiniProfiler 做接口性能分析 
- 使用 Automapper 处理对象映射
- 使用 AutoFac 做依赖注入容器，并提供批量服务注入 
- 支持 CORS 跨域或使用Nginx实现跨域 
- 使用 Log4Net 日志框架，集成原生 ILogger 接口做日志记录  或者serilog
- 使用 SignalR 双工通讯 
- 添加 IpRateLimiting 做 API 限流处理
- 使用 Quartz.net 做任务调度（目前单机多任务，集群调度暂不支持）
- RabbitMQ 消息队列 