﻿namespace FirstApp.Shared.Common;

public interface IVM<T>
    where T : IEquatable<T>
{
    T Id { get; set; }
}
public interface IVM:IVM<int> { }
