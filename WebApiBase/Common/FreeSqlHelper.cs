namespace WebApiBase.Common
{
    public class FreeSqlHelper
    {
        public IFreeSql Freesql()
        {
            return new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.SqlServer,
                    AppSettings.app(new string[] {"AppSettings", "ConnectionString"}))
                .UseAutoSyncStructure(true) //自动同步实体结构到数据库，FreeSql不会扫描程序集，只有CRUD时才会生成表。
                .UseLazyLoading(true) //延时加载
                .Build();
        }
    }
}