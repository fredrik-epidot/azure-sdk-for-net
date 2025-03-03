// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Containers.ContainerRegistry
{
    internal partial class RepositoryRestClient
    {
        private string url;
        private ClientDiagnostics _clientDiagnostics;
        private HttpPipeline _pipeline;

        /// <summary> Initializes a new instance of RepositoryRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="url"> Registry login URL. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="url"/> is null. </exception>
        public RepositoryRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            this.url = url;
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        internal HttpMessage CreateGetListRequest(string last, int? n)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/acr/v1/_catalog", false);
            if (last != null)
            {
                uri.AppendQuery("last", last, true);
            }
            if (n != null)
            {
                uri.AppendQuery("n", n.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> List repositories. </summary>
        /// <param name="last"> Query parameter for the last item in previous query. Result set will include values lexically after last. </param>
        /// <param name="n"> query parameter for max number of items. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<ResponseWithHeaders<Repositories, RepositoryGetListHeaders>> GetListAsync(string last = null, int? n = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetListRequest(last, n);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            var headers = new RepositoryGetListHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Repositories value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = Repositories.DeserializeRepositories(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> List repositories. </summary>
        /// <param name="last"> Query parameter for the last item in previous query. Result set will include values lexically after last. </param>
        /// <param name="n"> query parameter for max number of items. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public ResponseWithHeaders<Repositories, RepositoryGetListHeaders> GetList(string last = null, int? n = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateGetListRequest(last, n);
            _pipeline.Send(message, cancellationToken);
            var headers = new RepositoryGetListHeaders(message.Response);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        Repositories value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = Repositories.DeserializeRepositories(document.RootElement);
                        return ResponseWithHeaders.FromValue(value, headers, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGetAttributesRequest(string name)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/acr/v1/", false);
            uri.AppendPath(name, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Get repository attributes. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public async Task<Response<RepositoryProperties>> GetAttributesAsync(string name, CancellationToken cancellationToken = default)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var message = CreateGetAttributesRequest(name);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RepositoryProperties value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = RepositoryProperties.DeserializeRepositoryProperties(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Get repository attributes. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public Response<RepositoryProperties> GetAttributes(string name, CancellationToken cancellationToken = default)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var message = CreateGetAttributesRequest(name);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RepositoryProperties value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = RepositoryProperties.DeserializeRepositoryProperties(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateDeleteRequest(string name)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/acr/v1/", false);
            uri.AppendPath(name, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        /// <summary> Delete the repository identified by `name`. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public async Task<Response<DeletedRepository>> DeleteAsync(string name, CancellationToken cancellationToken = default)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var message = CreateDeleteRequest(name);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 202:
                    {
                        DeletedRepository value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DeletedRepository.DeserializeDeletedRepository(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Delete the repository identified by `name`. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public Response<DeletedRepository> Delete(string name, CancellationToken cancellationToken = default)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var message = CreateDeleteRequest(name);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 202:
                    {
                        DeletedRepository value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DeletedRepository.DeserializeDeletedRepository(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateUpdateAttributesRequest(string name, ContentProperties value)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(url, false);
            uri.AppendPath("/acr/v1/", false);
            uri.AppendPath(name, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            if (value != null)
            {
                request.Headers.Add("Content-Type", "application/json");
                var content = new Utf8JsonRequestContent();
                content.JsonWriter.WriteObjectValue(value);
                request.Content = content;
            }
            return message;
        }

        /// <summary> Update the attribute identified by `name` where `reference` is the name of the repository. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="value"> Repository attribute value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public async Task<Response> UpdateAttributesAsync(string name, ContentProperties value = null, CancellationToken cancellationToken = default)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var message = CreateUpdateAttributesRequest(name, value);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Update the attribute identified by `name` where `reference` is the name of the repository. </summary>
        /// <param name="name"> Name of the image (including the namespace). </param>
        /// <param name="value"> Repository attribute value. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public Response UpdateAttributes(string name, ContentProperties value = null, CancellationToken cancellationToken = default)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            using var message = CreateUpdateAttributesRequest(name, value);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    return message.Response;
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
