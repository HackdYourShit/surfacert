﻿<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="SurfaceRTStore" generation="1" functional="0" release="0" Id="31385e68-5df1-49ac-963d-b8765c64e01f" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
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
          <role name="MVCSurfaceRTStore" generation="1" functional="0" release="0" software="C:\Users\Durandal\documents\visual studio 2012\Projects\SurfaceRTStore\SurfaceRTStore\csx\Debug\roles\MVCSurfaceRTStore" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
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
    <implementation Id="c219ac56-3104-4661-8a29-b286f3060a97" ref="Microsoft.RedDog.Contract\ServiceContract\SurfaceRTStoreContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="6cc34f21-8759-4d70-aa54-d8e43bc2a927" ref="Microsoft.RedDog.Contract\Interface\MVCSurfaceRTStore:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/SurfaceRTStore/SurfaceRTStoreGroup/MVCSurfaceRTStore:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>