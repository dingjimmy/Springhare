// Copyright (c) James C Dingle. All rights reserved.

using System.Collections.Concurrent;

namespace Springhare.Actions.Poc.Service.Model
{
    /// <summary>
    /// Represents a period of time that an action is active and persists state between multiple invokations.
    /// </summary>
    public class Session<TAction> where TAction : IAction
    {
        /// <summary>
        /// Gets a value which uniquley identifies this session.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the action this session is responsible for.
        /// </summary>
        public TAction Action { get; }

        /// <summary> 
        /// 
        /// </summary>
        public ConcurrentDictionary<Guid, dynamic> Data { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="action"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public Session(Guid id, TAction action)
        {
            Id = id;
            Action = action ?? throw new ArgumentNullException(nameof(action));
        }
    }

    public interface IAction
    {
        Result Setup();

        Result Invoke();

        Result Teardown();
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class ActionBase<TConfig, TState, TData> : IAction
    {
        public TConfig Configuration { get; }

        public TState State { get; }

        public ActionBase(TConfig configuration, TState startingState)
        {
            Configuration = configuration;
            State = startingState;
        }

        public virtual Result Setup()
        {
            return Result.Success();
        }

        public virtual Result<TData?> Invoke()
        {
            return Result.Success(default(TData));
        }

        public virtual Result Teardown()
        {
            return Result.Success();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Result
    {
        public bool IsFailure { get; }

        public string ErrorMessage { get; }

        protected Result()
        {
            IsFailure = false;
            ErrorMessage = string.Empty;
        }

        protected Result(bool isFailure, string errorMessage)
        {
            IsFailure = isFailure;
            ErrorMessage = errorMessage;
        }

        public static Result Success()
        {
            return new Result();
        }

        public static Result<T> Success<T>(T data)
        {
            return new Result<T>(data);
        }

        public static Result Failure(string errorMessage)
        {
            return new Result(true, errorMessage);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T> : Result
    {
        public T Data { get; }

        public Result(T data) : base()
        {
            Data = data;
        }
    }
}
