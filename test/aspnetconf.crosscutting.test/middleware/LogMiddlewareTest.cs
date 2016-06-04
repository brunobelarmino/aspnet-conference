using aspnetconf.crosscutting.helper;
using aspnetconf.crosscutting.middleware;
using Microsoft.AspNetCore.Http;
using Moq;
using Nest;
using System;
using System.Threading.Tasks;
using Xunit;

namespace aspnetconf.crosscutting.test.middleware
{
    public class LogMiddlewareTest
    {
        private readonly Mock<IElasticClient> _logger = new Mock<IElasticClient>();
        private readonly Mock<RequestDelegate> _next = new Mock<RequestDelegate>();
        private readonly RequestLoggerMiddleware _subject;

        public LogMiddlewareTest()
        {
            _logger.Setup(x => x.IndexAsync(It.IsAny<Log>(), It.IsAny<Func<IndexDescriptor<Log>, IIndexRequest>>()))
                .Returns(Task.FromResult<IIndexResponse>(null));

            _subject = new RequestLoggerMiddleware(_next.Object, _logger.Object);
        }

        [Fact]
        public async Task should_log_request()
        {
            var context = new DefaultHttpContext();
            context.Connection.RemoteIpAddress = new System.Net.IPAddress(127001);
            await _subject.Invoke(context);
            _logger.Verify(p => p.IndexAsync(It.IsAny<Log>(), It.IsAny<Func<IndexDescriptor<Log>, IIndexRequest>>()), Times.Once());
        }
    }
}
