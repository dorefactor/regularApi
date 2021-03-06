using System.Collections.Generic;
using RegularApi.Domain.Views;
using RegularApi.Domain.Views.Docker;

namespace RegularApi.Tests.Fixtures
{
    public static class ViewFixture
    {
        public static ApplicationSetupView BuildDockerApplicationSetupView(string type)
        {
            return new DockerApplicationSetupView
            {
                Type = type,
                RegistryView = new RegistryView
                {
                    IsPrivate = false,
                    Url = "https://registry.docker.com"
                },
                ImageView = new ImageView
                {
                    Name = "todo-app"
                },
                EnvironmentVariables = new Dictionary<string, string>
                        {
                            {"VARIABLE","VALUE"}
                        },
                Ports = new Dictionary<string, string>
                        {
                            {"8080","80"}
                        }
            };
        }

        public static ApplicationView BuildApplicationView(string name, string type)
        {
            return new ApplicationView
            {
                Name = name,
                ApplicationSetupView = new DockerApplicationSetupView
                {
                    Type = type,
                    RegistryView = new RegistryView
                    {
                        IsPrivate = false,
                        Url = "https://registry.docker.com"
                    },
                    ImageView = new ImageView
                    {
                        Name = "todo-app"
                    },
                    EnvironmentVariables = new Dictionary<string, string>
                        {
                            {"VARIABLE","VALUE"}
                        },
                    Ports = new Dictionary<string, string>
                        {
                            {"8080","80"}
                        }
                }
            };
        }

        public static DeploymentTemplateView BuildDeploymentTemplateView(string name, string type)
        {
            return new DeploymentTemplateView
            {
                Name = name,
                ApplicationView = new ApplicationView
                {
                    Id = "5cce4c0d0722ec669fe60fca",
                    Name = name + "-application",
                    ApplicationSetupView = new DockerApplicationSetupView
                    {
                        Type = type,
                        EnvironmentVariables = new Dictionary<string, string>
                        {
                            {"APP_NAME","todo-app"}
                        }
                    }
                },
                HostSetupViews = new List<HostSetupView>
                {
                    new HostSetupView
                    {
                        Tag = "QA",
                        HostViews = new List<HostView>
                        {
                            new HostView{
                                Ip = "192.168.99.1",
                                Username = "root",
                                Password = "****"
                            }
                        }
                    }
                }
            };
        }

        public static DeploymentOrderView BuildDeploymentOrderView(string type)
        {
            return new DeploymentOrderView
            {
                DeploymentTemplateId = "5cce4c0d0722ec669fe60fcb",
                ApplicationView = new ApplicationView
                {
                    Name = "test-application",
                    ApplicationSetupView = new DockerApplicationSetupView
                    {
                        Type = type,
                        ImageView = new ImageView
                        {
                            Tag = "1.0"
                        }
                    }
                },
                HostSetupViews = new List<HostSetupView>
                {
                    new HostSetupView
                    {
                        Tag = "QA",
                        HostViews = new List<HostView>
                        {
                            new HostView{
                                Ip = "192.168.99.1"
                            }
                        }
                    }
                }
            };
        }
    }
}