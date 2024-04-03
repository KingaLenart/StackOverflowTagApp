namespace StackOverflowTagApp.Core.Infrastructure.Abstractions;

public interface IMapper<TFrom,TTo>
{
    TTo Map(TFrom source);
}

public interface IMapper<TFrom, TContext, TTo>
{
    TTo Map(TFrom source, TContext context);
}