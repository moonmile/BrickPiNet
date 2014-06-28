all: ../lib/libbrickpinet.so ../lib/BrickPiNet.dll

# sample.exe: libbrickpinet.so BrickPi.dll sample.cs
#	gmcs /out:sample.exe -sdk:4.5 /r:BrickPi.dll sample.cs 
#sampleCs.exe: libbrickpinet.so BrickPi.dll sampleCs.cs
#	gmcs /out:sampleCs.exe -sdk:4.5 /r:BrickPi.dll sampleCs.cs 
#sampleF.exe: libbrickpinet.so BrickPi.dll
#	fsharpc /out:sampleF.exe /r:BrickPi.dll sampleF.fs 
#sampleF2.exe: libbrickpinet.so BrickPi.dll
#	fsharpc /out:sampleF.exe /r:BrickPi.dll sampleF2.fs 

../lib/libbrickpinet.so: libbrickpinet/brickpinet.c 
	gcc -fPIC -shared -o ../lib/libbrickpinet.so libbrickpinet/brickpinet.c -lrt -lm -L/usr/local/lib -lwiringPi

../lib/BrickPiNet.dll: BrickPiNet/BrickPi.cs BrickPiNet/BPi.cs
	gmcs /target:library /out:../lib/BrickPi.dll \
	-sdk:4.5 \
	BrickPiNet/BindableBase.cs  \
	BrickPiNet/BrickPi.cs \
	BrickPiNet/BPi.cs

clean:
	rm *.o *.dll *.so *.exe
