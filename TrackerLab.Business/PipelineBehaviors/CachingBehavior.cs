﻿using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Business.Interfaces;

namespace TrackerLab.Business.PipelineBehaviors
{
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheable
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<CachingBehavior<TRequest, TResponse>> _logger;

        public CachingBehavior(IMemoryCache cache, ILogger<CachingBehavior<TRequest, TResponse>> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = request.GetType().Name;
            TResponse response;

            if (_cache.TryGetValue(request.Key, out response))
            {
                _logger.LogInformation("Returning cached value for {requestName}", requestName);
                return response;
            }

            response = await next();
            if (response == null) return response;

            _logger.LogInformation("Caching {requestName} response with Cache Key: {Key}", requestName, request.Key);
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(3))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(10));

            _cache.Set(request.Key, response, cacheOptions);
            return response;
        }
    }
}
