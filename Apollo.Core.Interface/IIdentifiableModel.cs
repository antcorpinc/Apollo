using System;

namespace Apollo.Core.Interface
{
    public interface IIdentifiableModel<T>
    {
        T Id { get; set; }
    }
}
