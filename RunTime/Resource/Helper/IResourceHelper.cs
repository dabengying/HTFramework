﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HT.Framework
{
    /// <summary>
    /// 资源管理器的助手接口
    /// </summary>
    public interface IResourceHelper : IInternalModuleHelper
    {
        /// <summary>
        /// 当前的资源加载模式
        /// </summary>
        ResourceLoadMode LoadMode { get; set; }
        /// <summary>
        /// 是否是编辑器模式
        /// </summary>
        bool IsEditorMode { get; set; }
        /// <summary>
        /// AssetBundle资源加载根路径
        /// </summary>
        string AssetBundleRootPath { get; set; }
        /// <summary>
        /// 是否缓存AB包
        /// </summary>
        bool IsCacheAssetBundle { get; set; }
        /// <summary>
        /// 所有AssetBundle资源包清单的名称
        /// </summary>
        string AssetBundleManifestName { get; set; }
        /// <summary>
        /// 缓存的所有AssetBundle包 <AB包名称、AB包>
        /// </summary>
        Dictionary<string, AssetBundle> AssetBundles { get; set; }
        /// <summary>
        /// 所有AssetBundle资源包清单
        /// </summary>
        AssetBundleManifest AssetBundleManifest { get; set; }
        /// <summary>
        /// 所有AssetBundle的Hash128值 <AB包名称、Hash128值>
        /// </summary>
        Dictionary<string, Hash128> AssetBundleHashs { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        void OnInitialization(ResourceLoadMode loadMode, bool isEditorMode, bool isCacheAssetBundle, string manifestName);
        /// <summary>
        /// 终结
        /// </summary>
        void OnTermination();

        /// <summary>
        /// 设置AssetBundle资源根路径（仅当使用AssetBundle加载时有效）
        /// </summary>
        /// <param name="path">AssetBundle资源根路径</param>
        void SetAssetBundlePath(string path);
        /// <summary>
        /// 通过名称获取指定的AssetBundle
        /// </summary>
        /// <param name="assetBundleName">名称</param>
        /// <returns>AssetBundle</returns>
        AssetBundle GetAssetBundle(string assetBundleName);
        /// <summary>
        /// 加载资源（异步）
        /// </summary>
        /// <typeparam name="T">资源类型</typeparam>
        /// <param name="info">资源信息标记</param>
        /// <param name="loadingAction">加载中事件</param>
        /// <param name="loadDoneAction">加载完成事件</param>
        /// <param name="isPrefab">是否是加载预制体</param>
        /// <param name="parent">预制体加载完成后的父级</param>
        /// <param name="isUI">是否是加载UI</param>
        /// <returns>加载协程迭代器</returns>
        IEnumerator LoadAssetAsync<T>(ResourceInfoBase info, HTFAction<float> loadingAction, HTFAction<T> loadDoneAction, bool isPrefab, Transform parent, bool isUI) where T : Object;
        /// <summary>
        /// 卸载资源（卸载AssetBundle）
        /// </summary>
        /// <param name="assetBundleName">AB包名称</param>
        /// <param name="unloadAllLoadedObjects">是否同时卸载所有实体对象</param>
        void UnLoadAsset(string assetBundleName, bool unloadAllLoadedObjects = false);
        /// <summary>
        /// 卸载所有资源（卸载AssetBundle）
        /// </summary>
        /// <param name="unloadAllLoadedObjects">是否同时卸载所有实体对象</param>
        void UnLoadAllAsset(bool unloadAllLoadedObjects = false);
        /// <summary>
        /// 清理内存，释放空闲内存
        /// </summary>
        void ClearMemory();
    }
}