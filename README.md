# NetcoreDBG does not hit breakpoints in xunitv3

## Steps to reproduce

### Checkout xunitv3 commit
``` sh
git checkout 80dc9aa  # xunitv3 commit
```

### Run test in debug mode
Then in two separate windows run the following commands:
```sh
VSTEST_HOST_DEBUG=1 dotnet test
```

### Attach to test
```sh
<path/to/netcoredbg> interpreter=cli --attach <pid-from-dotnet-test-above>
```

### Set breakpoint and run
In the netcoredbg then set a breakpoint and continue:

``` sh
b UnitTest1.cs:10
c
```

You will see that the test will finish and not hit any breakpoint on xunitv3 commit.

However it works fine if you instead use the xunitv2 commit via `git checkout 88dcbcb`

# Versions used to reproduce

```txt
-- netcoredbg --version
NET Core debugger 3.1.2-1 (83214c3, Release)

Copyright (c) 2020 Samsung Electronics Co., LTD
Distributed under the MIT License.
See the LICENSE file in the project root for more information.
```

```txt
-- dotnet --version
9.0.202
```

```txt
-- dotnet --list-runtimes
Microsoft.AspNetCore.App 6.0.36 [/usr/share/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.AspNetCore.App 8.0.14 [/usr/share/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.AspNetCore.App 9.0.3 [/usr/share/dotnet/shared/Microsoft.AspNetCore.App]
Microsoft.NETCore.App 6.0.36 [/usr/share/dotnet/shared/Microsoft.NETCore.App]
Microsoft.NETCore.App 8.0.14 [/usr/share/dotnet/shared/Microsoft.NETCore.App]
Microsoft.NETCore.App 9.0.3 [/usr/share/dotnet/shared/Microsoft.NETCore.App]
```

```txt
-- dotnet --list-sdks
6.0.428 [/usr/share/dotnet/sdk]
8.0.407 [/usr/share/dotnet/sdk]
9.0.202 [/usr/share/dotnet/sdk]
```

