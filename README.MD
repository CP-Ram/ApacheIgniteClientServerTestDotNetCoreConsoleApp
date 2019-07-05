
.NET CORE TEST APP
-----------------------
System Dependency:

-Target Framework .NET CORE VERSION 2.2.103

-Apache Ignite VERSION 2.7.5


Step to produce issue:
 
 -Create disk cache store folder for example:D:\ignite
 
 -Clone repo and run project.
 
 -After started server and client perform the following query on sqlline.
 
  select count(*) from "myTenantCache".EMPLOYEE;
 
 Expected Result:10
 
 but
 
 Actual result:1
  
