using ADotNet.Clients;
using ADotNet.Models.Pipelines.AdoPipelines.AspNets.Tasks.DotNetExecutionTasks;
using ADotNet.Models.Pipelines.AdoPipelines.AspNets.Tasks.UseDotNetTasks;
using ADotNet.Models.Pipelines.AdoPipelines.AspNets;

var adoClient = new ADotNetClient();

var aspNetPipeline = new AspNetPipeline
{
    TriggeringBranches = new List<string>
      {
          "main"
      },

    VirtualMachinesPool = new VirtualMachinesPool
    {
        VirtualMachineImage = VirtualMachineImages.Windows2022
    },

    ConfigurationVariables = new ConfigurationVariables
    {
        BuildConfiguration = BuildConfiguration.Release
    },

    Tasks = new List<BuildTask>
      {
          new UseDotNetTask
          {
              DisplayName = "Use DotNet 6.0",

              Inputs = new UseDotNetTasksInputs
              {
                  Version = "6.0.100",
                  IncludePreviewVersions = true,
                  PackageType = PackageType.sdk
              }
          },

          new DotNetExecutionTask
          {
              DisplayName = "Restore",

              Inputs = new DotNetExecutionTasksInputs
              {
                  Command = Command.restore,
                  FeedsToUse = Feeds.select
              }
          },

          new DotNetExecutionTask
          {
              DisplayName = "Build",

              Inputs = new DotNetExecutionTasksInputs
              {
                  Command = Command.build,
              }
          },

          new DotNetExecutionTask
          {
              DisplayName = "Test",

              Inputs = new DotNetExecutionTasksInputs
              {
                  Command = Command.test,
                  Projects = "**/*Unit*.csproj"
              }
          },

          //new DotNetExecutionTask
          //{
          //    DisplayName = "Publish",

          //    Inputs = new DotNetExecutionTasksInputs
          //    {
          //        Command = Command.publish,
          //        PublishWebProjects = true
          //    }
          //}
      }
};

adoClient.SerializeAndWriteToFile(aspNetPipeline, "../../../../.github/workflows/dotnet.yml");
