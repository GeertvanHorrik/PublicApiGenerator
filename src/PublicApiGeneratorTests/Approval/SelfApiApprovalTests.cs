#if NET9_0

using PublicApiGenerator;
using Shouldly;

namespace PublicApiGeneratorTests;

public class SelfApiApprovalTests
{
    [Fact]
    public void PublicApi_Should_Not_Change_Unintentionally()
    {
        var assembly = typeof(ApiGeneratorOptions).Assembly;
        var publicApi = assembly.GeneratePublicApi(
            new()
            {
                IncludeAssemblyAttributes = false,
                ExcludeAttributes = ["System.Diagnostics.DebuggerDisplayAttribute"],
            });

        publicApi.ShouldMatchApproved(options => options.NoDiff().WithFilenameGenerator((_, _, fileType, fileExtension) => $"{assembly.GetName().Name!}.{fileType}.{fileExtension}"));
    }
}

#endif
