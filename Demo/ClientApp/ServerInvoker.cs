﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkSocket;
using NetworkSocket.Fast;
using NetworkSocket.Fast.Attributes;
using System.Threading.Tasks;
using Models;

namespace ClientApp
{
    /// <summary>
    /// 客户端的实现
    /// </summary>
    public class ServerInvoker : FastTcpClientBase
    {
        /// <summary>
        /// 唯一实例
        /// </summary>
        private static readonly Lazy<ServerInvoker> instance = new Lazy<ServerInvoker>(() => new ServerInvoker());

        /// <summary>
        /// 获取唯一实例
        /// </summary>
        public static ServerInvoker Instance
        {
            get
            {
                return instance.Value;
            }
        }

        [Service(Implements.Remote, 100)]
        public Task<Boolean> Login(User user, Boolean ifAdmin)
        {
            return this.InvokeRemote<Boolean>(100, user, ifAdmin);
        }

        [Service(Implements.Remote, 300)]
        public Task<Int32> GetSun(Int32 x, Int32 y, Int32 z)
        {
            return this.InvokeRemote<Int32>(300, x, y, z);
        }

        [Service(Implements.Self, 200)]
        public void WarmingClient(String title, String contents)
        {
            Console.WriteLine(title);
            Console.WriteLine(contents);
        }

        [Service(Implements.Self, 201)]
        public List<Int32> SortByClient(List<Int32> list)
        {
            return list.OrderBy(item => item).ToList();
        }
    }
}