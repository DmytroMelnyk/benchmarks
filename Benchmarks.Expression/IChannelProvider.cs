namespace Benchmarks.Expression
{
    using System;
    using System.IO;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml.Linq;

    public static class Logger
    {
        public static Func<TService, TResult> LogAndCompile<TResult, TService>(this Expression<Func<TService, TResult>> serviceAction, Action<string> logger)
        {
            var contract = serviceAction.Parameters[0].Type.Name;
            var methodCallExpression = serviceAction.Body as MethodCallExpression;
            if (methodCallExpression == null)
            {
                throw new ArgumentException("Wrong service call method. Please check Call calls");
            }

            logger($"Service - [{contract}]");
            logger($"Method - [{methodCallExpression.Method.Name}]");
            foreach (var argument in methodCallExpression.Arguments)
            {
                var type = argument.Type.Name;
                var @object = ExpressionHelper.GetArgumentValue(argument);
                logger($"[{type}] - [{Logger.LogObjectAsXml(@object)}]");
            }

            return serviceAction.Compile();
        }

        public static void Log<TResult, TService>(this Expression<Func<TService, TResult>> serviceAction, Action<string> logger)
        {
            var contract = serviceAction.Parameters[0].Type.Name;
            var methodCallExpression = serviceAction.Body as MethodCallExpression;
            if (methodCallExpression == null)
            {
                throw new ArgumentException("Wrong service call method. Please check Call calls");
            }

            logger($"Service - [{contract}]");
            logger($"Method - [{methodCallExpression.Method.Name}]");
            foreach (var argument in methodCallExpression.Arguments)
            {
                var type = argument.Type.Name;
                var @object = ExpressionHelper.GetArgumentValue(argument);
                logger($"[{type}] - [{Logger.LogObjectAsXml(@object)}]");
            }
        }

        private static string LogObjectAsXml(object input)
        {
            var resultStr = string.Empty;

            // write the object to an XML string

            using (var memoryStream = new MemoryStream())
            {
                var serializer = new DataContractSerializer(input.GetType());
                serializer.WriteObject(memoryStream, input);
                resultStr = Encoding.UTF8.GetString(memoryStream.ToArray());
            }



            return XDocument.Parse(resultStr).ToString();
        }
    }
}