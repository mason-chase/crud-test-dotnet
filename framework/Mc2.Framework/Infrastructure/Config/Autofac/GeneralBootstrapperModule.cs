using Autofac;
using Autofac.Builder;
using Mc2.Framework.Application;
using Mc2.Framework.Domain;
using Mc2.Framework.Domain.Events;
using Mc2.Framework.Domain.Utils;
using Mc2.Framework.Infrastructure.EF;

namespace Mc2.Framework.Infrastructure.Config.Autofac;

public class GeneralBootstrapperModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CommandBus>().As<ICommandBus>().InstancePerLifetimeScope().OnRelease<CommandBus, ConcreteReflectionActivatorData, SingleRegistrationStyle>((Action<CommandBus>) (x => { }));
        builder.RegisterType<SystemClock>().As<IClock>().SingleInstance();
        builder.RegisterType<EfUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        builder.RegisterType<EventAggregator>().As<IEventPublisher>().As<IEventListener>().InstancePerLifetimeScope().OnRelease<EventAggregator, ConcreteReflectionActivatorData, SingleRegistrationStyle>((Action<EventAggregator>) (x => { }));
    }
}