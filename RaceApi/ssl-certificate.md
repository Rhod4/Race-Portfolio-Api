To use SSL in development, you need to create a certificate with a password and trust it. This readme assumes you're using Windows and
and working with Powershell. Everything described here can be done on Linux, MacOS or Windows using CMD, but the commands will differ.

The password for the certificate is passed to the container in the `docker-compose.debug.yml` using an environment variable that needs to be
set on the host machine (your computer). The environment variable is `ASPNETCORE_Kestrel__Certificates__Default__Password` which you'll need
to set to a reasonable value on your machine. You can do this by running the following command in a powershell window, specifying the
password you want to use. If you've already set this, you won't need to do it again.

```powershell
[Environment]::SetEnvironmentVariable("ASPNETCORE_Kestrel__Certificates__Default__Password","YourPasswordHere")
```

The following commands will create a certificate using the password you just set and then trust it on your machine.
You'll need to `cd` into the project folder before running these commands.

```powershell
dotnet dev-certs https -ep $env:USERPROFILE\.aspnet\https\RaceApi.pfx -p $env:ASPNETCORE_Kestrel__Certificates__Default__Password
dotnet dev-certs https --trust
```

The certificate will be placed in the `~/.aspnet/https` folder and then the folder it's stored in will be mapped to a folder in the container
so that the certificate can be used by the application.

**DO NOT** use this method for SSL certificate generation in production.

## Troubleshooting

If the application container exits because the password can't be read, the environment variable might have been set for a different user
than that used by the docker daemon. If this happens, the easiest solution is to set it for all users by running the following command,
although this will require a computer restart to take effect:

```powershell

[Environment]::SetEnvironmentVariable("ASPNETCORE_Kestrel__Certificates__Default__Password", "YourPasswordHere", [System.EnvironmentVariableTarget]::Machine)

```