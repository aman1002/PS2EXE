# Powershell Script for copying file from local machine to sftp server.
# Load WinSCP .NET assembly
Add-Type -Path "C:\Program Files (x86)\WinSCP\WinSCPnet.dll"

# Setup session options
$sessionOptions = New-Object WinSCP.SessionOptions -Property @{
    Protocol = [WinSCP.Protocol]::Sftp
    HostName = "ftp.xxxxx.com"
    UserName = "username"
    Password = "password"
    SshHostKeyFingerprint = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
}

$session = New-Object WinSCP.Session

try
{
    # Connect
    $session.Open($sessionOptions)

    # Download files
    $session.PutFiles("C:\Users\aman\Desktop\test.txt", "/xxx/yyy/").Check()
}
finally
{
    # Disconnect, clean up
    $session.Dispose()
}