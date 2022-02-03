using System;
using Serilog;

namespace ToAsciiNames {
    public static class LanguageUtils {
        /// <summary>
        /// Runs an operation and ignores any Exceptions that occur.
        /// Returns true or falls depending on whether catch was
        /// triggered
        /// </summary>
        /// <param name="operation">lambda that performs an operation that might throw</param>
        /// <returns></returns>
        public static Tuple<bool, Exception> IgnoreErrors(Action operation, string errorMessage = "Hata oluştu!") {
            if (operation == null)
                return Tuple.Create<bool, Exception>(false, null);
            try {
                operation.Invoke();
            } catch (Exception e) {
                Log.Error(e, errorMessage);
                return Tuple.Create(false, e);
            }
            return Tuple.Create<bool, Exception>(true, null);
        }

        /// <summary>
        /// Runs an function that returns a value and ignores any Exceptions that occur.
        /// Returns true or falls depending on whether catch was
        /// triggered
        /// </summary>
        /// <param name="operation">parameterless lamda that returns a value of T</param>
        /// <param name="defaultValue">Default value returned if operation fails</param>
        public static Tuple<T, Exception> IgnoreErrors<T>(Func<T> operation, T defaultValue = default) {
            if (operation == null)
                return Tuple.Create<T, Exception>(defaultValue, null);

            T result;
            try {
                result = operation.Invoke();
            } catch (Exception e) {
                return Tuple.Create<T, Exception>(default, e);
            }
            return Tuple.Create<T, Exception>(result, null);
        }
    }
}