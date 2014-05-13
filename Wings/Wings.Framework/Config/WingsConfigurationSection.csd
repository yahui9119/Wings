<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="ead7cc33-26fa-4d1c-90e9-1fd66bf8c300" namespace="Wings.Framework.Config" xmlSchemaNamespace="urn:Wings.Framework.Config" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="WingsConfigurationSection" namespace="Wings.Framework.Config" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="wingsConfigurationSection">
      <elementProperties>
        <elementProperty name="EmailClient" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="emailClient" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/EmailClientElement" />
          </type>
        </elementProperty>
        <elementProperty name="PermissionKeys" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="permissionKeys" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/PermissionkeyElementCollection" />
          </type>
        </elementProperty>
        <elementProperty name="Pressentation" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="pressentation" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/PressentationElement" />
          </type>
        </elementProperty>
        <elementProperty name="WebSite" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="webSite" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/WebSiteElement" />
          </type>
        </elementProperty>
        <elementProperty name="ConnectionStrings" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="connectionStrings" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/ConnectionStringsCollection" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElement name="PressentationElement" namespace="Wings.Framework.Config">
      <attributeProperties>
        <attributeProperty name="ProductsPageSize" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="productsPageSize" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElementCollection name="PermissionkeyElementCollection" namespace="Wings.Framework.Config" xmlItemName="permissionkeyElement" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/PermissionkeyElement" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="PermissionkeyElement" namespace="Wings.Framework.Config">
      <attributeProperties>
        <attributeProperty name="RoleName" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="roleName" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="KeyName" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="keyName" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="EmailClientElement" namespace="Wings.Framework.Config">
      <attributeProperties>
        <attributeProperty name="Host" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="host" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Port" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="port" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="UserName" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="userName" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Password" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="password" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="EnableSsl" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="enableSsl" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/Boolean" />
          </type>
        </attributeProperty>
        <attributeProperty name="Sender" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="sender" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="WebSiteElement" namespace="Wings.Framework.Config">
      <attributeProperties>
        <attributeProperty name="ID" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="iD" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Name" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Assembly" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="assembly" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="AdminID" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="adminID" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElementCollection name="ConnectionStringsCollection" namespace="Wings.Framework.Config" xmlItemName="connectionString" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/ConnectionString" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="ConnectionString" namespace="Wings.Framework.Config">
      <attributeProperties>
        <attributeProperty name="Key" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="key" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Value" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="value" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/ead7cc33-26fa-4d1c-90e9-1fd66bf8c300/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>