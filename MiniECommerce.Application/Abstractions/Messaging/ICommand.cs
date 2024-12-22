using MediatR;

namespace MiniECommerce.Application.Abstractions.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse>;