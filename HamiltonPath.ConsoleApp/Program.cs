using System;
using System.Linq;
using Autofac;
using HamiltonPath.ConsoleApp.Command;
using HamiltonPath.ConsoleApp.Common;
using log4net;

namespace HamiltonPath.ConsoleApp
{
    /// <summary>
    /// Console Application
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// Main Function - resolves input command 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            GlobalContext.Properties[Consts.Comments.LogName] = args.Length > 0 ? args[0] : string.Empty;
            var logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            logger.Debug(Consts.Comments.JobStarted);
            logger.Debug(Consts.Comments.Parameters + string.Join(Consts.Comments.Space, args));
            var container = Bootstrapper.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                try
                {
                    var parameters = args.Skip(1).ToList();
                    if (args.Length > 0)
                    {
                        var commandName = args[0];
                        if (scope.IsRegisteredWithName(commandName, typeof(ICommand)))
                        {
                            scope.ResolveNamed<ICommand>(commandName).Execute(parameters);
                        }
                        else
                        {
                            scope.ResolveNamed<ICommand>(Consts.Commands.Help).Execute(parameters);
                        }
                    }
                    else
                    {
                        scope.ResolveNamed<ICommand>(Consts.Commands.Help).Execute(parameters);
                        logger.Error(Consts.Comments.NoCommand);
                    }
                }
                catch (Exception e)
                {
                    logger.ErrorFormat(Consts.Comments.Exception + e.StackTrace + Environment.NewLine + e.Message + Environment.NewLine + e.InnerException?.Message);
                    throw;
                }
                finally
                {
                    logger.Debug(Consts.Comments.JobEnded);
                }
            }
        }
    }
}
