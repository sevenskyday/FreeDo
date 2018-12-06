using System;
using System.Collections.Generic;
using System.Text;

namespace BookShare.Service.Models.BaseModels
{
    /// <summary>
    /// 自定义错误结果对象
    /// </summary>
    /// <typeparam name="T">需要返回的类型</typeparam>

    public class ServiceResult<T> : ServiceResult
    {
        /// <summary>
        /// 数据集
        /// </summary>
        public T Entity { get; set; }

        /// <summary>
        /// 生成自定义服务数据集
        /// </summary>
        /// <param name="successd">状态值（true:成功 false：失败）</param>
        /// <param name="message">返回到客户端的消息</param>
        /// <param name="entity">返回到客户端的数据集</param>
        /// <returns>返回信息结果集</returns>
        public static ServiceResult<T> Create(bool successd, string message, T entity)
        {
            return new ServiceResult<T>()
            {
                IsSucceed = successd,
                Message = message,
                Entity = entity
            };
        }


        /// <summary>
        /// 生成成功信息
        /// </summary>
        /// <param name="message">返回客户端的消息</param>
        /// <returns>返回服务数据集</returns>
        public static ServiceResult<T> Success(string message, T entity)
        {
            return new ServiceResult<T>() { Message = message, IsSucceed = true,Entity= entity };
        }
        /// <summary>
        /// 操作成功
        /// </summary>
        /// <returns></returns>
        public static ServiceResult<T> Success(T entity)
        {
            return new ServiceResult<T>() { Message = "操作成功", IsSucceed = true, Entity=entity};
        }

        /// <summary>
        /// 生成错误信息
        /// </summary>
        /// <param name="message">返回客户端的消息</param>
        /// <returns>返回服务数据集</returns>
        public new static ServiceResult<T> Error(string message)
        {
            return new ServiceResult<T>() { Message = message, IsSucceed = false};
        }
        /// <summary>
        /// 操作失败
        /// </summary>
        /// <returns>返回服务数据集</returns>
        public new static ServiceResult<T> Error()
        {
            return new ServiceResult<T>() { Message = "操作失败，请稍后重试", IsSucceed = false };
        }
        /// <summary>
        /// 操作失败,返回错误详情
        /// </summary>
        /// <returns>返回服务数据集</returns>
        public new static ServiceResult<T> Error(Exception ex)
        {
            return new ServiceResult<T>() { Message = "操作失败，请稍后重试", Desc = ex.ToString(), IsSucceed = false };
        }
    }

    public class ServiceResult
    {
        /// <summary>
        /// 生成错误信息
        /// </summary>
        /// <param name="message">返回客户端的消息</param>
        /// <returns>返回服务数据集</returns>
        public static ServiceResult Error(string message)
        {
            return new ServiceResult() { Message = message, IsSucceed = false };
        }
        /// <summary>
        /// 操作失败
        /// </summary>
        /// <returns>返回服务数据集</returns>
        public static ServiceResult Error()
        {
            return new ServiceResult() { Message = "操作失败，请稍后重试", IsSucceed = false };
        }
        /// <summary>
        /// 操作失败,返回错误详情
        /// </summary>
        /// <returns>返回服务数据集</returns>
        public static ServiceResult Error(Exception ex)
        {
            return new ServiceResult() { Message = "操作失败，请稍后重试", Desc = ex.ToString(), IsSucceed = false };
        }

        /// <summary>
        /// 生成成功信息
        /// </summary>
        /// <param name="message">返回客户端的消息</param>
        /// <returns>返回服务数据集</returns>
        public static ServiceResult Success(string message)
        {
            return new ServiceResult() { Message = message, IsSucceed = true };
        }
        /// <summary>
        /// 操作成功
        /// </summary>
        /// <returns></returns>
        public static ServiceResult Success()
        {
            return new ServiceResult() { Message = "操作成功", IsSucceed = true };
        }

        /// <summary>
        /// 生成服务器数据集
        /// </summary>
        /// <param name="success">状态值（true:成功 false：失败）</param>
        /// <param name="successMessage">返回客户端的消息</param>
        /// <param name="errorMessage">错误信息</param>
        /// <returns>返回服务数据集</returns>
        public static ServiceResult Create(bool success, string successMessage = "", string errorMessage = "")
        {
            return new ServiceResult() { Message = success ? successMessage : errorMessage, IsSucceed = success };
        }

        /// <summary>
        /// 构造服务数据集
        /// </summary>
        public ServiceResult()
        {
            IsSucceed = false;
            Message = string.Empty;
        }

        /// <summary>
        /// 状态值
        /// </summary>

        public bool IsSucceed { get; set; }

        /// <summary>
        ///返回客户端的消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 错误描述详情
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 错误码
        /// </summary>
        public int ErrorCode { get; set; }


    }
}
