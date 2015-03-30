using System;

namespace Core
{
    /// <summary>
    /// 迷惑函数抽象类
    /// </summary>
    public abstract class IPuzzle
    {
        /// <summary>
        /// 被使用次数
        /// </summary>
        protected int useCount;
        /// <summary>
        /// 创建时间
        /// </summary>
        protected DateTime createTime;
        /// <summary>
        /// 最后被使用时间
        /// </summary>
        public DateTime lastUseTime { get; protected set; }

        /// <summary>
        /// 将发送至前端的代码
        /// </summary>
        public string StringSendToFrantEnd { get; protected set; }

        /// <summary>
        /// 是否还在可用次数之内
        /// 为单元测试而作，常规代码请勿override
        /// </summary>
        public virtual bool IsInUseCount()
        {
            return useCount <= 50;
        }

        /// <summary>
        /// 自增使用次数
        /// </summary>
        public void IncUseCount()
        {
            useCount++;
        }

        public IPuzzle(DateTime now)
        {
            this.lastUseTime = now;
            this.createTime = now;
        }

        /// <summary>
        /// 为单元测试而做，常规代码请勿调用
        /// </summary>
        internal IPuzzle() { }

        /// <summary>
        /// 获取运算结果，将和前端发回来进行比对验证
        /// </summary>
        public abstract string GetResult();
    }
}
