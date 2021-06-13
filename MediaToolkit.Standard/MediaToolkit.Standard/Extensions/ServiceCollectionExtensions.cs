using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Text;
using MediaToolkit.Standard.Core;
using MediaToolkit.Standard.Core.Interfaces;
using MediaToolkit.Standard.Services;
using MediaToolkit.Standard.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MediaToolkit.Standard.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the MediaToolkit to the service collection.
        /// </summary>
        public static IServiceCollection AddMediaToolkit(this IServiceCollection services, string ffmpegPath, string ffprobePath = null)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var options = new MediaToolkitOptions
            {
                FfMpegPath = ffmpegPath
            };

            if (!string.IsNullOrEmpty(ffprobePath))
            {
                options.FfProbePath = ffprobePath;
            }

            services.TryAddSingleton<IFileSystem, FileSystem>();
            services.AddSingleton(options);
            services.AddSingleton<IFfProcessFactory, FfProcessFactory>();
            services.AddSingleton<IMediaToolkitService, MediaToolkitService>();

            return services;
        }
    }
}
