﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Business.Helpers
{
    public static class Guard
    {
        public static void NotFound<TInput, TId>(TInput input, string inputName, TId id)
        {
            _ = input ?? throw new KeyNotFoundException($"The requested {inputName} with an id of {id} was not found");
        }

        public static void NotFound<TInput>(IEnumerable<TInput> inputs, string inputsName = null, string message = null)
        {
            if (string.IsNullOrWhiteSpace(message)) message = $"The requested {inputsName ?? "items"} were not found";
            if (inputs == null || !inputs.Any()) throw new KeyNotFoundException(message);
        }

        public static void NotFound<TInput>(TInput input, string inputTitle)
        {
            _ = input ?? throw new KeyNotFoundException($"{inputTitle} was not found");
        }

        public static void NotFound<T>(bool input, string inputName, T id)
        {
            if (!input) throw new KeyNotFoundException($"The requested {inputName} with an id of {id} was not found");
        }

        public static void NullOrWhitespace(string input, string inputName, string message = null)
        {
            Null(input, inputName, message);

            if (string.IsNullOrWhiteSpace(input)) throw new ArgumentException(message ?? $"{inputName} was empty");
        }

        public static T Null<T>(T input, string parameterName, string message = null)
        {
            if (input is not null) return input;

            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(parameterName);

            throw new ArgumentNullException(message);
        }
    }
}
