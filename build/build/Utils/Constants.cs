namespace Build;

public static class Constants
{
    public const string ToolsDirectory = "./tools";
    public const string DockerHubRegistry = "docker.io";
    public const string GitHubContainerRegistry = "ghcr.io";
    public const string DockerImageName = "gittools/build-images";
    public const string DockerImageDeps = "gittools/deps";

    public static readonly Architecture[] ArchToBuild = [Architecture.Amd64, Architecture.Arm64];
    public static readonly string[] VersionsToBuild = ["8.0", "6.0"];
    public static readonly string VersionForDockerLatest = VersionsToBuild[0];
    public static readonly string[] VariantsToBuild = ["sdk", "runtime"];
    public static readonly string[] DockerDistrosToBuild =
    [
        "alpine.3.17",
        "alpine.3.18",
        "centos.stream.8",
        "debian.11",
        "fedora.37",
        "ubuntu.20.04",
        "ubuntu.22.04",
        "ubuntu.24.04"
    ];
}
