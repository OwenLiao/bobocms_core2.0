

using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Threading;

namespace bobo.orm.efcore
{
    /// <summary>
    /// 上下文简单工厂
    /// <remarks>
    /// 创建：2014.02.05
    /// </remarks>
    /// </summary>
    public class ContextFactory
    {
        //关于DbContext的单例问题，看了一些文章讲DbContex是轻量级的，创建的开销不大，另一个DbContext并不能保证线程安全。
        //对于DbContext单例化、静态化很多人反对，但每个操作都进行创建和销毁也不合理，实现一个请求内单例还是比较合适。
        //看到@Kencery这么写，我特意查了些资料：MSDN中讲CallContext提供对每个逻辑执行线程都唯一的数据槽，而在WEB程序里，每一个请求就是一个逻辑线程
        //所以使用CallContext来实现单个请求之内的DbContext单例是合理的。


        /// <summary>
        /// 获取当前数据上下文
        /// </summary>
        /// <returns></returns>
        public static MyDbContext GetCurrentContext()
        {

            MyDbContext _nContext = CallContext.GetData("MyContext") as MyDbContext;
            if (_nContext == null)
            {
              //  _nContext = new MyDbContext();
                CallContext.SetData("MyContext", _nContext);
            }
            return _nContext;


        }
        /// <summary>
        /// Provides a way to set contextual data that flows with the call and 
        /// async context of a test or invocation.
        /// </summary>
        public static class CallContext
        {
            static ConcurrentDictionary<string, AsyncLocal<object>> state = new ConcurrentDictionary<string, AsyncLocal<object>>();

            /// <summary>
            /// Stores a given object and associates it with the specified name.
            /// </summary>
            /// <param name="name">The name with which to associate the new item in the call context.</param>
            /// <param name="data">The object to store in the call context.</param>
            public static void SetData(string name, object data) =>
                state.GetOrAdd(name, _ => new AsyncLocal<object>()).Value = data;

            /// <summary>
            /// Retrieves an object with the specified name from the <see cref="CallContext"/>.
            /// </summary>
            /// <param name="name">The name of the item in the call context.</param>
            /// <returns>The object in the call context associated with the specified name, or <see langword="null"/> if not found.</returns>
            public static object GetData(string name) =>
                state.TryGetValue(name, out AsyncLocal<object> data) ? data.Value : null;
        }
    }
}
