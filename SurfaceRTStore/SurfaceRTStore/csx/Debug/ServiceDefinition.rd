<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="SurfaceRTStore" generation="1" functional="0" release="0" Id="58d537eb-999b-4a83-a6ef-326cee87bbcd" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="SurfaceRTStoreGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="MVCSurfaceRTStore:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/SurfaceRTStore/SurfaceRTStoreGroup/LB:MVCSurfaceRTStore:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="MVCSurfaceRTStore:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/SurfaceRTStore/SurfaceRTStoreGroup/MapMVCSurfaceRTStore:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="MVCSurfaceRTStoreInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/SurfaceRTStore/SurfaceRTStoreGroup/MapMVCSurfaceRTStoreInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:MVCSurfaceRTStore:Endpoint1">
          <toPorts>
            <inPortMoniker name="/SurfaceRTStore/SurfaceRTStoreGroup/MVCSurfaceRTStore/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapMVCSurfaceRTStore:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/SurfaceRTStore/SurfaceRTStoreGroup/MVCSurfaceRTStore/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapMVCSurfaceRTStoreInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/SurfaceRTStore/SurfaceRTStoreGroup/MVCSurfaceRTStoreInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="MVCSurfaceRTStore" generation="1" functional="0" release="0" software="C:\Users\Durandal\Documents\GitHub\surfacert\SurfaceRTStore\SurfaceRTStore\csx\Debug\roles\MVCSurfaceRTStore" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;MVCSurfaceRTStore&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;MVCSurfaceRTStore&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/SurfaceRTStore/SurfaceRTStoreGroup/MVCSurfaceRTStoreInstances" />
            <sCSPolicyUpdateDomainMoniker name="/SurfaceRTStore/SurfaceRTStoreGroup/MVCSurfaceRTStoreUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/SurfaceRTStore/SurfaceRTStoreGroup/MVCSurfaceRTStoreFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="MVCSurfaceRTStoreUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="MVCSurfaceRTStoreFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="MVCSurfaceRTStoreInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="2d5ddb99-e2dd-4e8d-9feb-0ee2eb046172" ref="Microsoft.RedDog.Contract\ServiceContract\SurfaceRTStoreContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="30ddb116-0182-4069-a7b0-3a49a5ded6f5" ref="Microsoft.RedDog.Contract\Interface\MVCSurfaceRTStore:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/SurfaceRTStore/SurfaceRTStoreGroup/MVCSurfaceRTStore:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>