using MediatR;

namespace MiniECommerce.Application.Abstractions.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>;