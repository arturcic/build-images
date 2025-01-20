using DockerBuildXBuildSettings = Build.Cake.Docker.DockerBuildXBuildSettings;
using DockerBuildXImageToolsCreateSettings = Build.Cake.Docker.DockerBuildXImageToolsCreateSettings;

namespace Build;

[TaskName(nameof(DockerBuildDeps))]
[TaskDescription("Builds the docker images dependencies")]
public sealed class DockerBuildDeps : BaseDockerBuild
{
    public override void Run(BuildContext context)
    {
        // build/push images
        foreach (var dockerImage in context.DepsImages)
        {
            DockerImage(context, dockerImage);
        }

        if (!context.PushImages)
            return;

        // build/push manifests
        // foreach (var group in context.DepsImages.GroupBy(x => new { x.Distro }))
        // {
        //     var dockerImage = group.First();
        //     DockerManifest(context, dockerImage);
        // }
    }

    protected override DirectoryPath GetWorkingDir(DockerDepsImage dockerImage) =>
        DirectoryPath.FromString($"./src/linux/{dockerImage.Distro}");

    protected override DockerBuildXBuildSettings GetBuildSettings(DockerDepsImage dockerImage, string registry)
    {
        var buildSettings = base.GetBuildSettings(dockerImage, registry);
        var (distro, arch) = dockerImage;

        var workDir = GetWorkingDir(dockerImage);
        buildSettings.File = $"{workDir}/Dockerfile";
        buildSettings.Label =
        [
            .. buildSettings.Label,
            $"{Prefix}.description=GitTools deps images ({distro}-{arch.ToSuffix()})"
        ];
        buildSettings.Annotation =
        [
            .. buildSettings.Annotation,
            $"{Prefix}.description=GitTools deps images ({distro}-{arch.ToSuffix()})"
        ];

        return buildSettings;
    }
}
