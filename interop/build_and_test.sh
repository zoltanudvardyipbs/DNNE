cd InteroperabilityTest
dotnet build InteroperabilityTest.csproj
cd ..
clang -Wl,-ldl,-lpthread -I ./InteroperabilityTest/bin/Debug/net6.0 ./ANSI-C_DNNE.c -o ./InteroperabilityTest/bin/Debug/net6.0/main ./InteroperabilityTest/bin/Debug/net6.0/InteroperabilityTestNE.so
./InteroperabilityTest/bin/Debug/net6.0/main