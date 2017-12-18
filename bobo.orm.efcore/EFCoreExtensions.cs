using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Linq;

namespace bobo.orm.efcore
{
    public static class EFCoreExtensions
    {
        private static bool IsIEntityTypeConfigurationType(Type typeIntf)
        {
            return typeIntf.IsInterface && typeIntf.IsGenericType && typeIntf.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>);
        }

        public static void ApplyConfigurationsFromAssembly(this ModelBuilder modelBuilder,Assembly assembly)
        {
            var types = assembly.GetTypes().Where(t => !t.IsAbstract && t.GetInterfaces().Any(it => IsIEntityTypeConfigurationType(it)));
            Type typeModelBuilder = modelBuilder.GetType();

            MethodInfo methodNonGenericApplyConfiguration = typeModelBuilder.GetMethod(nameof(ModelBuilder.ApplyConfiguration)); foreach (var type in types)
            {
                var entityTypeConfig = Activator.CreateInstance(type);

                //获取实体的类型                
                Type typeEntity = type.GetInterfaces().First(t => IsIEntityTypeConfigurationType(t)).GenericTypeArguments[0];



                //因为ApplyConfiguration是泛型方法，所以要通过MakeGenericMethod转换为泛 型方法才能调用               
                MethodInfo methodApplyConfiguration = methodNonGenericApplyConfiguration.MakeGenericMethod(typeEntity);
                methodApplyConfiguration.Invoke(modelBuilder, new[] { entityTypeConfig });
            }
        }
    }
}
