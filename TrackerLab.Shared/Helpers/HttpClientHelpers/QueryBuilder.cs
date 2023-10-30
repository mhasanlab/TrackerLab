﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLab.Shared.Helpers.HttpClientHelpers
{
    public class QueryBuilder : IKeyValueBuilder
    {
        private readonly StringBuilder _sb;

        protected QueryBuilder(string uri)
        {
            _sb = new StringBuilder(uri);
        }

        public IKeyValueBuilder WithParam(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return this;
            Append(key, value);
            return this;
        }

        public IKeyValueBuilder WithParam<T>(string key, T value)
        {
            if (EqualityComparer<T>.Default.Equals(value, default)) return this;
            Append(key, $"{value}");
            return this;
        }

        private void Append(string key, string value)
        {
            if (_sb[^1] != '?') _sb.Append('&');

            _sb.Append(key)
                .Append('=')
                .Append(Uri.EscapeDataString(value));
        }

        public static IKeyValueBuilder Use(string uri)
        {
            return new QueryBuilder(uri.EndsWith('?') ? uri : $"{uri}?");
        }

        public string Build()
        {
            return _sb.ToString();
        }
    }
}
