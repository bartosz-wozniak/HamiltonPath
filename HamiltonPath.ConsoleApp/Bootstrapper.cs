using System.Reflection;
using Autofac;
using HamiltonPath.BusinessLogic.Algorithm;
using HamiltonPath.BusinessLogic.Serialization;
using HamiltonPath.BusinessLogic.TaskGenerator;
using HamiltonPath.ConsoleApp.Command;
using HamiltonPath.ConsoleApp.Common;

namespace HamiltonPath.ConsoleApp
{
    /// <summary>
    /// Bootsrapper class for Autofac, dependency injection
    /// </summary>
    internal static class Bootstrapper
    {
        /// <summary>
        /// Registers types and configures container
        /// </summary>
        /// <returns>Container</returns>
        public static IContainer Configure()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var builder = new ContainerBuilder();      
            builder.RegisterType<Serializer>().As<ISerializer>();
            builder.RegisterType<AlgorithmProvider>().As<IAlgorithmProvider>();
            builder.RegisterType<TaskGenerator>().As<ITaskGenerator>();
            builder.RegisterAssemblyTypes(assembly).Where(CommandHelper.IsCommand).Named<ICommand>(a => CommandHelper.GetCommandName(a).Name);
            return builder.Build();
        }
    }
}
