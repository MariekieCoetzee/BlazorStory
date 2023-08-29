namespace BlazorSSR.Stories.Tests;

public class CompositeHost : IHost
{
    private readonly IHost testHost;
    private readonly IHost kestrelHost;

    public CompositeHost(IHost testHost, IHost kestrelHost)
    {
        this.testHost = testHost;
        this.kestrelHost = kestrelHost;
    }

    public void Dispose()
    {
        testHost.Dispose();
        kestrelHost.Dispose();
    }

    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        await testHost.StartAsync(cancellationToken);
        await kestrelHost.StartAsync(cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken = default)
    {
        await testHost.StopAsync();
        await kestrelHost.StopAsync();
    }

    public IServiceProvider Services => testHost.Services;
}