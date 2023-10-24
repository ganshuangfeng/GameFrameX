﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFrameX;
using GameFrameX.Network;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrameX.Runtime
{
    /// <summary>
    /// 网络组件。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Network")]
    public sealed class NetworkComponent : GameFrameworkComponent
    {
        private INetworkManager m_NetworkManager = null;
        private EventComponent m_EventComponent = null;

        /// <summary>
        /// 获取网络频道数量。
        /// </summary>
        public int NetworkChannelCount => m_NetworkManager.NetworkChannelCount;

        /// <summary>
        /// 游戏框架组件初始化。
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            // new NetworkManager();
            m_NetworkManager = GameFrameworkEntry.GetModule<INetworkManager>();
            if (m_NetworkManager == null)
            {
                Log.Fatal("Network manager is invalid.");
                return;
            }

            m_NetworkManager.NetworkConnected += OnNetworkConnected;
            m_NetworkManager.NetworkClosed += OnNetworkClosed;
            m_NetworkManager.NetworkMissHeartBeat += OnNetworkMissHeartBeat;
            m_NetworkManager.NetworkError += OnNetworkError;
            m_NetworkManager.NetworkCustomError += OnNetworkCustomError;
        }

        private void Start()
        {
            m_EventComponent = GameEntry.GetComponent<EventComponent>();
            if (m_EventComponent == null)
            {
                Log.Fatal("Event component is invalid.");
                return;
            }
        }

        /// <summary>
        /// 检查是否存在网络频道。
        /// </summary>
        /// <param name="channelName">网络频道名称。</param>
        /// <returns>是否存在网络频道。</returns>
        public bool HasNetworkChannel(string channelName)
        {
            return m_NetworkManager.HasNetworkChannel(channelName);
        }

        /// <summary>
        /// 获取网络频道。
        /// </summary>
        /// <param name="channelName">网络频道名称。</param>
        /// <returns>要获取的网络频道。</returns>
        public INetworkChannel GetNetworkChannel(string channelName)
        {
            return m_NetworkManager.GetNetworkChannel(channelName);
        }

        /// <summary>
        /// 获取所有网络频道。
        /// </summary>
        /// <returns>所有网络频道。</returns>
        public INetworkChannel[] GetAllNetworkChannels()
        {
            return m_NetworkManager.GetAllNetworkChannels();
        }

        /// <summary>
        /// 获取所有网络频道。
        /// </summary>
        /// <param name="results">所有网络频道。</param>
        public void GetAllNetworkChannels(List<INetworkChannel> results)
        {
            m_NetworkManager.GetAllNetworkChannels(results);
        }

        /// <summary>
        /// 创建网络频道。
        /// </summary>
        /// <param name="channelName">网络频道名称。</param>
        /// <param name="networkChannelHelper">网络频道辅助器。</param>
        /// <returns>要创建的网络频道。</returns>
        public INetworkChannel CreateNetworkChannel(string channelName, INetworkChannelHelper networkChannelHelper)
        {
            return m_NetworkManager.CreateNetworkChannel(channelName, networkChannelHelper);
        }

        /// <summary>
        /// 销毁网络频道。
        /// </summary>
        /// <param name="channelName">网络频道名称。</param>
        /// <returns>是否销毁网络频道成功。</returns>
        public bool DestroyNetworkChannel(string channelName)
        {
            return m_NetworkManager.DestroyNetworkChannel(channelName);
        }

        private void OnNetworkConnected(object sender, GameFrameX.Network.NetworkConnectedEventArgs e)
        {
            m_EventComponent.Fire(this, NetworkConnectedEventArgs.Create(e));
        }

        private void OnNetworkClosed(object sender, GameFrameX.Network.NetworkClosedEventArgs e)
        {
            m_EventComponent.Fire(this, NetworkClosedEventArgs.Create(e));
        }

        private void OnNetworkMissHeartBeat(object sender, GameFrameX.Network.NetworkMissHeartBeatEventArgs e)
        {
            m_EventComponent.Fire(this, NetworkMissHeartBeatEventArgs.Create(e));
        }

        private void OnNetworkError(object sender, GameFrameX.Network.NetworkErrorEventArgs e)
        {
            m_EventComponent.Fire(this, NetworkErrorEventArgs.Create(e));
        }

        private void OnNetworkCustomError(object sender, GameFrameX.Network.NetworkCustomErrorEventArgs e)
        {
            m_EventComponent.Fire(this, NetworkCustomErrorEventArgs.Create(e));
        }
    }
}