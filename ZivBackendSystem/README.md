# APIMZone

API Management helps organizations publish APIs to external, partner and internal developers to unlock the potential of their data and services. 
Businesses everywhere are looking to extend their operations as a digital platform, creating new channels, finding new customers and driving 
deeper engagement with existing ones. 
API Management provides the core competencies to ensure a successful API program through developer engagement, business insights, analytics, security and protection.

[![Alt text for your video](http://img.youtube.com/vi/goIrkRzvQ3k/0.jpg)](http://www.youtube.com/watch?v=goIrkRzvQ3k)


![alt tag](https://raw.githubusercontent.com/zivshtaeinberg/APIMZone/master/ArcFile.PNG)

## APIs and operations
APIs are the foundation of an API Management service instance. 
Each API represents a set of operations available to developers. 
Each API contains a reference to the back-end service that implements the API, and its operations map to the operations implemented by the back-end service. 
Operations in API Management are highly configurable, with control over URL mapping, query and path parameters, request and response content, and operation response caching. 
Rate limit, quotas, and IP restriction policies can also be implemented at the API or individual operation level.

## Requirements
* Azure Function App
* VMSS
* [Register](https://docs.microsoft.com/en-us/azure/active-directory/active-directory-app-registration) a new application in Azure Active Directory (need to be global admin in order to do that)
* Create application Key, save this secret, you will need that later for deployment
* Give the application "Owner" role on VMSS
* Install [Visual Studio Tools for Azure Functions](https://blogs.msdn.microsoft.com/webdev/2016/12/01/visual-studio-tools-for-azure-functions/)
* Create SQL Database and/or ServiceBus Topics or and Q.

## Scaling Logic Parameters
* These paramters decides if input data is X & Y will the scaling will be up with Z VM'S or down.
* Please decide where to store the scaling logic parameters to be store, the options are Database or File.

## Deployment
* Open solution in visual studio 2015 update 3
* Build solution
* Publish Azure Function project named "vmssAutoScale" into your Azure Function App
* Set Azure Function App settings:
```XML
  <appSettings>
    <add key="MaxScale" value="maximum server capacity limit"/>
    <add key="MinScale" value="minimum server capacity limit"/>
    <add key="MaxThreshold" value="maximum threshold for auto scale, above this value autoscaler will add one server to vmss"/>
    <add key="MinThreshold" value="minimum threshold for auto scale, below this value autoscaler will remove one server to vmss"/>
    <add key="SQLConnectionString" value="sql server connection string which holds logic for autoscale"/>
    <add key="ClientId" value="application key in azure active directory"/>
    <add key="ClientSecret" value="application secret in azure active directory"/>
    <add key="TenantId" value="active directory id"/>
    <add key="SubscriptionId" value="azure subscription id which holds vmss"/>
    <add key="ResourceGroup" value="vmss resource group"/>
    <add key="VmssName" value="vmss name"/>
    <add key="AzureArmApiBaseUrl" value="https://management.azure.com/"/>
    <add key="VmssApiVersion" value="2016-03-30"/>
  </appSettings>
